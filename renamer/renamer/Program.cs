using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace renamer
{
    class Program
    {
        static int W_RESOLUTION = 1920;

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Specify Source and Destination directories.  Exiting with no-op.");
                return;
            }

            var sourceDirPath = args[0];
            var destDirPath = args[1];

            Console.WriteLine("Copy and Rename all images from source to destination?");
            var response = Console.ReadLine();
            if (response.ToUpper().StartsWith("Y"))
            {
                var sourceDir = new DirectoryInfo(sourceDirPath);
                var destinationDir = new DirectoryInfo(destDirPath);
                var destFiles = destinationDir.GetFiles().ToList();
                var sourceFiles = sourceDir.GetFiles().ToList();
                var exisiting = from f in destFiles
                                select f.Name.Substring(0, f.Name.IndexOf(f.Extension) > 0 ? f.Name.IndexOf(f.Extension) : f.Name.Length);
                var toCheck = sourceFiles.Where(f => !exisiting.Contains(f.Name));
                var toMove = new List<FileInfo>();
                foreach (var f in toCheck)
                {
                    try
                    {
                        using (var i = Image.FromFile(f.FullName))
                        {
                            if (i != null && i.Width >= W_RESOLUTION)
                            {
                                toMove.Add(f);
                            }
                        }
                    }
                    catch (OutOfMemoryException)
                    {
                        // this wasn't a valid image file, continue
                    }
                }

                foreach (var f in toMove)
                {
                    File.Copy(f.FullName, string.Format("{0}\\{1}.jpg", destinationDir.FullName, f.Name));
                }
            }
            Console.WriteLine("Processing complete.");
            Console.ReadLine();
        }
    }
}
