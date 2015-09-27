using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using ObjectModel;
using CustomControls;

namespace ExifDiscover.ProcessingViews
{
    public partial class ProcessFiles : Form
    {
        Dictionary<string, string> __newNames;
        Dictionary<string, string> __badNames;
        string __browsePath = string.Empty;
        string __rememberedPath = string.Empty;

        public ProcessFiles()
        {
            InitializeComponent();

            var fi = new FileInfo("settings.txt");
            if (fi.Exists)
            {
                using (var sr = new StreamReader("settings.txt"))
                {
                    __rememberedPath = sr.ReadLine();
                }
            }
        }

        private List<string> GetWorkingFileList(string path, string filter)
        {
            FileManager fm = new FileManager();
            fm.SourcePath = path;
            List<FileInfo> infos = fm.GetFileList(filter);
            List<string> retColl = new List<string>();

            if (infos != null && infos.Count > 0)
            {
                foreach (FileInfo info in infos)
                {
                    retColl.Add(info.FullName);
                }
            }

            return retColl;
        }

        private int PrintF(string toPrint)
        {
            this.txtOutput.AppendText(toPrint);
            this.txtOutput.AppendText("\r\n");
            return toPrint.Length;
        }

        private int PrintF(string toPrint, bool newLine)
        {
            if (newLine)
            {
                return PrintF(toPrint);
            }
            else
            {
                this.txtOutput.AppendText(toPrint);
                return toPrint.Length;
            }
        }

        private void btnProcessFiles_Click(object sender, EventArgs e)
        {
            dlgBrowsForFolder.ShowNewFolderButton = false;
            if (!string.IsNullOrEmpty(__rememberedPath))
            {
                dlgBrowsForFolder.SelectedPath = __rememberedPath;
            }
            DialogResult result = dlgBrowsForFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                __browsePath = dlgBrowsForFolder.SelectedPath;
                if (__browsePath != __rememberedPath)
                {
                    using (var sr = new StreamWriter("settings.txt"))
                    {
                        sr.WriteLine(__browsePath);
                    }
                    __rememberedPath = __browsePath;
                }
                List<string> fileList = GetWorkingFileList(__browsePath, "*.*");
                __newNames = new Dictionary<string, string>();
                __badNames = new Dictionary<string, string>();

                StringBuilder sb = null;
                if (fileList != null && fileList.Count > 0)
                {
                    PrintF("Inspecting files...");
                    PrintF(fileList.Count.ToString() + " files found.");

                    int count = 0;
                    int errorCount = 0;
                    foreach (string fileName in fileList)
                    {
                        ++count;
                        sb = new StringBuilder();
                        sb.Append(count.ToString());
                        sb.Append(".) ");

                        ExifReader reader = new ExifReader(fileName);
                        string newName = string.Empty;
                        try
                        {
                            newName = reader.GetPhotoFileName();
                        }
                        catch
                        {
                            errorCount++;
                            sb.Append(fileName);
                            sb.Append(" - has no EXIF DATA.");
                        }

                        if (newName != null && newName.Length > 0)
                        {
                            if (!__newNames.ContainsKey(newName))
                            {
                                __newNames.Add(newName, fileName);

                                sb.Append(fileName);
                                sb.Append(" >> ");
                                sb.Append(newName);
                            }
                            else
                            {
                                __badNames.Add(fileName, newName + " == Duplicate of " + __newNames[newName]);
                                sb.Append("Bad Name Found: ");
                                sb.Append(fileName);
                                sb.Append(" wants to become ");
                                sb.Append(newName);
                                sb.AppendLine("");
                                sb.AppendLine("--- DETAILS ---");
                                sb.AppendLine("--- Taken: " + reader.DateTimeTaken.ToLongDateString());
                                sb.AppendLine("--- Orig.: " + reader.DateTimeOriginal.ToLongDateString());
                                

                            }
                        }

                        PrintF(sb.ToString());
                        Application.DoEvents();
                    }

                    PrintF("");
                    PrintF("Process completed.");
                    PrintF(count.ToString() + " files processed.");
                    PrintF(errorCount.ToString() + " files with errors (missing EXIF data).");
                }
            }
        }

        private void btnViewBadNames_Click(object sender, EventArgs e)
        {
            if (__badNames != null && __badNames.Count > 0)
            {
                foreach (string badname in __badNames.Keys)
                {
                    PrintF(badname + " > " + __badNames[badname]);

                }
            }
            else
            {
                PrintF("No bad names found.");
            }
        }

        private void btnDataManagement_Click(object sender, EventArgs e)
        {
            DialogResult result = this.dlgOpenFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                Photo testPhoto = new Photo(this.dlgOpenFile.FileName);
                testPhoto.OpenPhoto();

                JPL_BaseForm frm = new PhotoViews.InputView(testPhoto);
                frm.Size = new Size(800, 400);
                frm.Tag = Constants.Views.InputView;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void btnMoveFiles_Click(object sender, EventArgs e)
        {
            PrintF("");
            PrintF("Beginning move process ...");
            if (__newNames != null && __newNames.Count > 0)
            {
                if (__badNames != null && __badNames.Count == 0)
                {
                    foreach (string newName in __newNames.Keys)
                    {
                        ExifReader reader = new ExifReader(__newNames[newName]);

                        //
                        // create the folder name required for this new photo
                        //
                        StringBuilder sb = new StringBuilder();
                        if (reader.HasExifInfo)
                        {
                            sb.Append(reader.DateTimeTaken.Year.ToString());
                            sb.Append("-");
                            sb.Append(padDateInt(reader.DateTimeTaken.Month));
                            sb.Append("-");
                            sb.Append(padDateInt(reader.DateTimeTaken.Day));
                        }
                        else
                        {
                            sb.Append(DateTime.Now.Year.ToString());
                            sb.Append("-");
                            sb.Append(padDateInt(DateTime.Now.Month));
                            sb.Append("-");
                            sb.Append(padDateInt(DateTime.Now.Day));
                        }

                        DirectoryInfo browseDir = new DirectoryInfo(__browsePath);
                        DirectoryInfo targetDir = new DirectoryInfo(browseDir.Parent.FullName);

                        FileManager fm = new FileManager(browseDir.FullName, targetDir.FullName + "\\" + sb.ToString());
                        FileInfo currentFile = new FileInfo(__newNames[newName]);
                        string outString = fm.RenameAndFolder(currentFile.Name, newName);

                        PrintF(outString);

                    }
                }
                else
                {
                    PrintF("Can not process move due to bad names found.");
                    foreach (string badname in __badNames.Keys)
                    {
                        PrintF(badname + " > " + __badNames[badname]);
                    }
                }
            }

            PrintF("Move process completed.");
        }

        private string padDateInt(int i)
        {
            if (i > 9) return i.ToString();
            return string.Format("0{0}", i);
        }

        private void btnOneTime_Click(object sender, EventArgs e)
        {
            var path = @"C:\Users\jlitfin\Pictures\Photos Backup\";
            var root = new DirectoryInfo(path);
            var temp = new DirectoryInfo(@"C:\Users\jlitfin\Pictures\Rename\");
            var dupes = new DirectoryInfo(@"C:\Users\jlitfin\Pictures\Dupes\");
            var video = new DirectoryInfo(@"C:\Users\jlitfin\Pictures\Video\");
            temp.Create();
            dupes.Create();
            video.Create();

            var dirs = root.GetDirectories();
            for (int i = 0; i < dirs.Length; ++i)
            {
                
                var files = dirs[i].GetFiles();
                PrintF(string.Format("Directory {0} of {1} : {2} : {3} files", i.ToString().PadLeft(4, ' '), dirs.Length, dirs[i].Name.PadLeft(15, ' '), files.Length), true);
                foreach (var file in files)
                {
                    string extension = file.Name.Substring(file.Name.LastIndexOf('.'));
                    if (file.Name.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || file.Name.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                        file.Name.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) || file.Name.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        file.Name.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)|| file.Name.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase) || 
                        file.Name.EndsWith(".tif", StringComparison.OrdinalIgnoreCase)) 
                    
                    {
                        string name = string.Empty;
                        
                        using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
                        {
                            var fn = file.DirectoryName + "\\" + file.Name;
                            var bytes = File.ReadAllBytes(fn);
                            var hash = Convert.ToBase64String(sha1.ComputeHash(bytes));
                            var exp = new Regex("[/]");
                            name = exp.Replace(hash, "_") + extension;
                        }
                        var tmpName = temp.FullName + "\\" + name;
                        var check = new FileInfo(tmpName);
                        if (!check.Exists)
                        {
                            file.MoveTo(temp.FullName + "\\" + name);

                        }
                        else
                        {
                            var dupeName = dupes.FullName + "\\" + name;
                            check = new FileInfo(dupeName);
                            if (!check.Exists)
                            {
                                PrintF(string.Format("Duping {0}", file.Name), true);
                                file.MoveTo(dupeName);
                            }
                            else
                            {
                                PrintF(string.Format("Skipping {0}", file.Name), true);
                            }
                        }
                    }
                    else if (file.Name.EndsWith(".mov", StringComparison.OrdinalIgnoreCase))
                    {
                        file.MoveTo(video.FullName + file.Name);
                    }
                    Application.DoEvents();
                }

            }
            PrintF(string.Format("Complete."), true);
        }
    }
}