using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
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

        public ProcessFiles()
        {
            InitializeComponent();
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
            DialogResult result = dlgBrowsForFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                __browsePath = dlgBrowsForFolder.SelectedPath;
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
                        sb.Append(reader.DateTimeTaken.Year.ToString());
                        sb.Append("-");
                        sb.Append(padDateInt(reader.DateTimeTaken.Month));
                        sb.Append("-");
                        sb.Append(padDateInt(reader.DateTimeTaken.Day));

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
            var path = @"C:\Users\jlitfin\Pictures\Photos\";
            var root = new DirectoryInfo(path);

            var dirs = root.GetDirectories();
            for (int i = 0; i < dirs.Length; ++i)
            {
                var newDirName = string.Empty;
                if (dirs[i].Name.Contains("-"))
                {
                    var arr = dirs[i].Name.Split('-');
                    if (arr.Length == 3)
                    {
                        newDirName = string.Format("{3}{0}-{1}-{2}", arr[0], padDateInt(Int32.Parse(arr[1])), padDateInt(Int32.Parse(arr[2])), path);
                        if (!dirs[i].FullName.Equals(newDirName))
                        {
                            dirs[i].MoveTo(newDirName); 
                        }       
                    }
                }
            }
        }
    }
}