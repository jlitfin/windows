using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImageManagement;

namespace PhotoImport
{
    class Program
    {
        private static int _counter = 0;
        private static int _fileCount = 0;
        private static int _dupeErrorCount = 0;
        private static int _fileOpErrorCount = 0;
        private static int _maxLineLength = 0;
        private static bool _ignoreDupeErrors = false;
        private static DirectoryInfo _importDirectory;


        static void Main(string[] args)
        {
            
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: PhotoImport.exe [Source Directory]");
                return;
            }

            using (var errorLog = new StreamWriter(ErrorManager.ErrorLogFile, false))
            {
                errorLog.WriteLine("Batch: {0}", DateTime.Now.ToLongDateString());
            }

            var browsePath = args[0];
            _importDirectory = new DirectoryInfo(browsePath);
            if (_importDirectory.Exists)
            {
                var fileList = GetWorkingFileList(browsePath, "*.*");
                
                PrintF(string.Format("Found {0} files to process at {1}", fileList.Count, browsePath));
                PrintF(string.Format("Press any key to continue or {0} to quit.", "Q"));
                var info = Console.ReadKey();
                if (info.Key == ConsoleKey.Q) return;

                PrintF();
                ProcessFiles(fileList);

                Spin("Process completed.");
                PrintF();
                PrintF("  " + _fileCount.ToString() + " files processed.");
                PrintF("  " + _dupeErrorCount.ToString() + " duplicates.");

                if (_fileOpErrorCount > 0)
                {
                    PrintError("See Error log file for file issues.");
                }
            }
            else
            {
                Console.WriteLine("Fuck you, get a directory.");
            }

            Console.ReadKey();
        }

        private static List<string> GetWorkingFileList(string path, string filter)
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

        private static void PrintError(string toPrint)
        {
            PrintF();
            var fg = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            PrintF(toPrint);
            PrintF("Press any key to continue processing, or 'q' to quit: ", false);
            
            var info = Console.ReadKey();
            Console.ForegroundColor = fg;
            if (info.Key == ConsoleKey.Q) Environment.Exit(1);

            
            PrintF();

        }

        private static int PrintF(string toPrint = null)
        {
            if (toPrint == null) toPrint = string.Empty;
            return PrintF(toPrint, true);
        }

        private static int PrintF(string toPrint, bool newLine)
        {
            Console.Write(toPrint);
            if (newLine)
            {
                Console.WriteLine();
            }
            return toPrint.Length;
        }

        private static void ProcessFiles(List<string> fileList)
        {
            var newNames = new Dictionary<string, LibraryFile>();
            var dupeNames = new Dictionary<string, LibraryFile>();

            if (fileList != null && fileList.Count > 0)
            {
                foreach (string fileName in fileList)
                {
                    try
                    {
                        var reader = new ExifReader(fileName);
                        var newName = reader.GetPhotoFileName();
                        var sourceDirectory = new DirectoryInfo(fileName.Substring(0, fileName.LastIndexOf("\\")));
                        var lFile = new LibraryFile
                        {
                            SourceDirectory = sourceDirectory.FullName,
                            SourceName = fileName.Substring(fileName.LastIndexOf("\\") + 1),
                            TargetDirectory = _importDirectory.Parent.FullName + "\\" + reader.GetPhotoDirectoryName(),
                            TargetName = newName
                        };

                        if (!newNames.ContainsKey(newName))
                        {
                            ++_fileCount;
                            newNames.Add(newName, lFile);
                            Spin(newName, _fileCount, fileList.Count);
                        }
                        else
                        {
                            ++_dupeErrorCount;
                            if (!dupeNames.ContainsKey(newName))
                            {
                                dupeNames.Add(newName, lFile);
                            }
                            if (!_ignoreDupeErrors)
                            {
                                Spin();
                                PrintError(string.Format("Duplicate file found, source: {0} duplicates {1}", lFile.SourceName, newNames[newName].SourceName));
                                PrintF();
                                PrintF("Do you want to ignore future duplicate warnings? (dupes will be moved to duplicate folder) (y/n): ", false);
                                var info = Console.ReadKey();
                                if (info.Key == ConsoleKey.Y) _ignoreDupeErrors = true;
                                PrintF();
                                PrintF();
                            }
                        }                        
                    }
                    catch (Exception ex)
                    {
                        PrintError(ex.Message);
                    }
                }

                Spin(string.Format("File Found Summary: "));
                PrintF();
                PrintF(string.Format("  {0} files inspected", fileList.Count));
                PrintF(string.Format("  {0} new images staged", newNames.Count));
                PrintF(string.Format("  {0} duplicates to be staged", dupeNames.Count));
                PrintF(string.Format("  {0} files will be left in import", fileList.Count - (newNames.Count + dupeNames.Count)));
                PrintF();
                PrintF("Do want to proceed with the rename and move? (y/n): ", false);
                var confirm = Console.ReadKey();
                if (confirm.Key != ConsoleKey.Y) 
                {
                    PrintF();
                    PrintF("Exiting without processing.");
                    Environment.Exit(0);
                }
                else
                {
                    PrintF();
                    PrintF("Continuing with rename and move.");
                }
                PrintF();
                PrintF();

                var fm = new FileManager();        
                var moveCount = 0;
                foreach (var kv in newNames)
                {
                    fm.SourcePath = kv.Value.SourceDirectory;
                    fm.DestinationPath = kv.Value.TargetDirectory;
                    var response = fm.RenameAndFolder(kv.Value.SourceName, kv.Value.TargetName);
                    if (response.SuccessFlag)
                    {
                        Spin(kv.Value.SourceName + " staged to new directory", ++moveCount, newNames.Count + dupeNames.Count);
                    }
                    else
                    {
                        _fileOpErrorCount++;
                        ErrorManager.Instance().Publish(string.Format("[{0}]: {1}", _fileOpErrorCount, response.Message));
                    }
                }

                foreach (var kv in dupeNames)
                {
                    var dupeDir = new DirectoryInfo(_importDirectory.Parent.FullName + "\\0_Duplicates");
                    if (!dupeDir.Exists)
                    {
                        dupeDir.Create();
                    }
                    fm.SourcePath = kv.Value.SourceDirectory;
                    fm.DestinationPath = dupeDir.FullName;
                    var response = fm.RenameAndFolder(kv.Value.SourceName, kv.Value.TargetName);
                    if (response.SuccessFlag)
                    {
                        Spin(kv.Value.SourceName + " staged to duplicates", ++moveCount, newNames.Count + dupeNames.Count);
                    }
                    else
                    {
                        _fileOpErrorCount++;
                        ErrorManager.Instance().Publish(string.Format("[{0}]: {1}", _fileOpErrorCount, response.Message));
                    }
                }
            }
        }

        public static void Spin(string message = null, int? index = null, int? total = null)
        {
            if (message != null && index != null && total != null)
            {
                _counter++;
                string fan = string.Empty;
                switch (_counter % 4)
                {
                    case 0:
                        fan = "/";
                        _counter = 0;
                        break;
                    case 1:
                        fan = "-";
                        break;
                    case 2:
                        fan = "\\";
                        break;
                    case 3:
                        fan = "|";
                        break;
                }

                int pad = total.Value;
                while (pad > 10)
                {
                    pad /= 10;
                }

                var printString = string.Format("\r {0} {1} [{2} of {3}] {4} ", fan, "", index.ToString().PadLeft(pad, ' '), total, message);
                if (printString.Length > _maxLineLength) _maxLineLength = printString.Length;
                Console.Write(printString.PadRight(_maxLineLength, ' '));
            }
            else
            {
                if (message == null) message = " ";
                Console.Write("\r {0}", message.PadRight(_maxLineLength + 5, ' '));
            }

        }
    }
}
