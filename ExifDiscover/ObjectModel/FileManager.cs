using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectModel
{
    public class FileManager
    {
        private string __sourcePath;
        private string __destinationPath;

        #region Constructor

        public FileManager()
        {
        }

        public FileManager(string sourcePath, string destinationPath)
        {
            __sourcePath = sourcePath;
            __destinationPath = destinationPath;
        }

        #endregion

        #region Properties

        public string DestinationPath
        {
            get
            {
                return __destinationPath;
            }
            set
            {
                __destinationPath = value;
            }
        }

        public string SourcePath
        {
            get
            {
                return __sourcePath;
            }
            set
            {
                __sourcePath = value;
            }
        }

        #endregion

        #region Public Methods

        public List<FileInfo> GetFileList(string filter)
        {
            List<FileInfo> list = null;
            if (ValidateSourcePath())
            {
                list = new List<FileInfo>();
                GetAllFilesForFilter(list, new DirectoryInfo(__sourcePath), filter);
            }

            return list;
        }

        public string RenameAndFolder(string oldFileName, string newFileName)
        {
            StringBuilder msgString = new StringBuilder();
            try
            {
                DirectoryInfo sourceDir = new DirectoryInfo(__sourcePath);
                DirectoryInfo destDir = new DirectoryInfo(__destinationPath);
                if (!destDir.Exists)
                {
                    destDir.Create();
                }

                //
                // check and see if this file already exists and DO NOT overwrite it
                //
                bool fileExists = false;
                FileInfo[] files = destDir.GetFiles();
                if (files != null && files.Length > 0)
                {
                    for (int i = 0; i < files.Length; ++i)
                    {
                        if (files[i].Name.Equals(newFileName))
                        {
                            fileExists = true;
                            break;
                        }
                    }
                }

                //
                // if this file exists report and skip
                //
                if (!fileExists)
                {
                    FileInfo fileToMove = null;
                    FileInfo[] sourceFiles = sourceDir.GetFiles();
                    for (int i = 0; i < sourceFiles.Length; ++i)
                    {
                        if (sourceFiles[i].Name.Equals(oldFileName))
                        {
                            fileToMove = sourceFiles[i];
                            break;
                        }
                    }

                    if (fileToMove != null)
                    {
                        string newFile = destDir.FullName + "\\" + newFileName;
                        fileToMove.MoveTo(newFile);
                        msgString.Append(oldFileName);
                        msgString.Append(" >> ");
                        msgString.Append(destDir.Name);
                        msgString.Append("\\");
                        msgString.Append(newFileName);
                    }
                }
                else
                {
                    msgString.Append("File Skipped: ");
                    msgString.Append(oldFileName);
                    msgString.Append(" >> ");
                    msgString.Append(newFileName);
                    msgString.Append(" because this file already exists.");
                }
            }
            catch (Exception ex)
            {
                ErrorManager.Instance().Publish(ex.Message);
            }

            return msgString.ToString();

        }

        #endregion

        #region Private Methods

        private void GetAllFilesForFilter(List<FileInfo> appendTo, DirectoryInfo srcDir, string filter)
        {
            if (appendTo != null)
            {
                DirectoryInfo[] subDirs = srcDir.GetDirectories();
                if (subDirs != null && subDirs.Length > 0)
                {
                    for (int i = 0; i < subDirs.Length; ++i)
                    {
                        GetAllFilesForFilter(appendTo, subDirs[i], filter);
                    }
                }

                //to leaf nodes
                FileInfo[] leafNodes = srcDir.GetFiles(filter);
                if (leafNodes != null && leafNodes.Length > 0)
                {
                    for (int i = 0; i < leafNodes.Length; ++i)
                    {
                        appendTo.Add(leafNodes[i]);
                    }
                }
            }
        }

        private bool ValidateDestinationPath()
        {
            bool validPaths = true;
            if (__destinationPath != null && __destinationPath.Length > 0)
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(__destinationPath);
                    if (!dir.Exists)
                    {
                        validPaths = false;
                    }

                    //make sure we can write files here
                    using (StreamWriter test = new StreamWriter(dir.FullName + @"\" + "jphoto.access"))
                    {
                        if (test != null)
                        {
                            test.WriteLine(DateTime.Now.ToString());
                        }
                        else
                        {
                            validPaths = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorManager.Instance().Publish(ex.Message);
                    validPaths = false;
                }
            }
            else
            {
                validPaths = false;
            }

            return validPaths;
        }

        private bool ValidateSourcePath()
        {
            bool validPaths = true;
            if (__sourcePath != null && __sourcePath.Length > 0)
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(__sourcePath);
                    if (!dir.Exists)
                    {
                        validPaths = false;
                    }
                }
                catch (Exception ex)
                {
                    ErrorManager.Instance().Publish(ex.Message);
                    validPaths = false;
                }
            }
            else
            {
                validPaths = false;
            }

            return validPaths;

        }

        private bool ValidatePaths()
        {
            return (ValidateDestinationPath() && ValidateSourcePath());
        }

        #endregion
    }

}
