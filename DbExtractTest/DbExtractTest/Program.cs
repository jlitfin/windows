using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    internal class Program
    {
        private static int _counter = 0;

        private static void Main(string[] args)
        {
            //ProcessFiles();
            //InspectFile("actors.list.gz");
            //InspectFile("actresses.list.gz");
            //InspectFile("directors.list.gz");
            //InspectFile("writers.list.gz");
            //InspectFile("ratings.list.gz");
            InspectFile("plot.list.gz");
        }

        private static void ProcessFiles()
        {
            DateTime runtTime = DateTime.Now;
            using (var db = new MdbContext())
            {
                foreach (var fileDetail in db.FileDataDetails.Where(f => f.Active))
                {
                    int errorCount = 0;
                    using (var sr = new StreamReader(fileDetail.FileName))
                    {
                        var str = string.Empty;
                        var skipLines = long.MaxValue;
                        while (skipLines > 0)
                        {
                            str = sr.ReadLine();
                            if (str == null)
                            {
                                throw new ArgumentException("Invalid file structure:  EOF reached before begin flag.");
                            }
                            else
                            {
                                if (str.StartsWith(fileDetail.OpenFlag))
                                {
                                    skipLines = fileDetail.LinesAfterFlag;
                                }
                            }
                            --skipLines;
                        }
                        var i = 0;

                        while ((str = sr.ReadLine()) != null)
                        {
                            try
                            {
                                using (var repo = FileItemRepositoryFactory.GetInstance(fileDetail.ItemClassName))
                                {
                                    repo.AddOrUpdate(fileDetail.Id, str);
                                }
                            }
                            catch (Exception ex)
                            {
                                errorCount++;
                                using (
                                    var ew = new StreamWriter(string.Format("errorLog.{0}.txt", runtTime.Ticks),
                                        true))
                                {
                                    ew.WriteLine(
                                        string.Format("ERROR - [{6}] File: {0} Source: {1}{2}{3}{4}{5}{7}{8}",
                                            fileDetail.FileName, str,
                                            Environment.NewLine, ex.Message,
                                            Environment.NewLine, ex.StackTrace,
                                            DateTime.Now.ToLongTimeString(),
                                            Environment.NewLine,
                                            ex.InnerException == null
                                                ? "No Inner Exception"
                                                : ex.InnerException.Message));
                                }

                                if (errorCount >= 10)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Exiting due to error count.");
                                    Console.Read();
                                    return;
                                }
                            }
                            if (i%10 == 0)
                            {
                                Console.Write(Spin(i));
                            }
                            if (++i > 10000) break;
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Done.");
            Console.Read();

        }

        private static void InspectFile(string fileName)
        {
            DateTime runtTime = DateTime.Now;
            var i = 0;
            using (var db = new MdbContext())
            {
                var fileDetail = db.FileDataDetails.SingleOrDefault(f => f.FileName == fileName);
                if (fileDetail != null)
                {
                    using (var sr = new StreamReader(fileDetail.FileName))
                    {
                        var source = string.Empty;
                        var skipLines = long.MaxValue;
                        while (skipLines > 0)
                        {
                            source = sr.ReadLine();
                            if (source == null)
                            {
                                throw new ArgumentException("Invalid file structure:  EOF reached before begin flag.");
                            }
                            else
                            {
                                if (source.StartsWith(fileDetail.OpenFlag))
                                {
                                    skipLines = fileDetail.LinesAfterFlag;
                                }
                            }
                            --skipLines;
                        }

                        using (var sw = new StreamWriter(fileDetail.FileName + "_inspect.dat"))
                        using (var sl = new StreamWriter("inspect.dat"))
                        {
                            using (var repo = FileItemRepositoryFactory.GetInstance(fileDetail.ItemClassName))
                            {
                                var tokens = new List<string>();
                                var peek = string.Empty;
                                try
                                {
                                    while ((peek = sr.ReadLine()) != null)
                                    {
                                        var sb = new StringBuilder();
                                        sb.AppendLine(peek);

                                        if (fileDetail.ReadAheadFor != null)
                                        {
                                            while ((source = sr.ReadLine()) != null &&
                                                   !source.StartsWith(fileDetail.ReadAheadFor))
                                            {
                                                sb.AppendLine(source);
                                            }
                                        }

                                        tokens = repo.ParseToTokens(sb.ToString());
                                        sw.WriteLine(TokensToString(tokens));
                                        sl.WriteLine(sb.ToString());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    using (
                                        var ew = new StreamWriter(
                                            string.Format("errorLog.{0}.log", runtTime.Ticks), true))
                                    {
                                        ew.WriteLine(
                                            string.Format("ERROR - [{6}] File: {0} Source: {1}{2}{3}{4}{5}{7}{8}",
                                                fileDetail.FileName, source,
                                                Environment.NewLine, ex.Message,
                                                Environment.NewLine, ex.StackTrace,
                                                DateTime.Now.ToLongTimeString(),
                                                Environment.NewLine,
                                                ex.InnerException == null
                                                    ? "No Inner Exception"
                                                    : ex.InnerException.Message));
                                    }
                                }
                                if (i%10 == 0)
                                {
                                    Console.Write(Spin(i));
                                }
                                if (++i > 10000) break;
                            }
                        }
                    }
                }
                else
                {
                    using (var sr = new StreamReader(fileName))
                    {
                        using (var sw = new StreamWriter("inspect.dat"))
                        {
                            var source = string.Empty;
                            while ((source = sr.ReadLine()) != null)
                            {
                                try
                                {
                                    sw.WriteLine(source);
                                }
                                catch (Exception ex)
                                {
                                    using (
                                        var ew = new StreamWriter(string.Format("errorLog.{0}.log", runtTime.Ticks),
                                            true))
                                    {
                                        ew.WriteLine(ex.Message);
                                    }
                                }
                                if (i%10 == 0)
                                {
                                    Console.Write(Spin(i));
                                }
                                if (++i > 10000) break;
                            }
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Done.");
            Console.Read();
        }

        public static string TokensToString(List<string> t)
        {
            var sb = new StringBuilder();
            foreach (var s in t)
            {
                sb.Append(s).Append("|");
            }
            sb.AppendLine();
            return sb.ToString();
        }

        public static string Spin(long id)
        {
            _counter++;
            string fan = string.Empty;
            switch (_counter%4)
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

            var pad = (int) (id%10);

            return string.Format("\r{0} Record: {1}{2}", fan, id, "".PadRight(pad, ' '));
        }
    }
}
