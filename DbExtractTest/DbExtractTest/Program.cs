using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const int LINES_AFTER_FLAG = 3;
            var series = new Dictionary<string, Indexable>();

            using (var context = new MdbContext())
            {

            }

            using (var sr = new StreamReader("movies.list.gz"))
            using (var sw = new StreamWriter("movies.dat"))
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
                        if (str.StartsWith("MOVIES LIST"))
                        {
                            skipLines = LINES_AFTER_FLAG;
                        }
                    }
                    --skipLines;
                }

                var i = 0;
                while ((str = sr.ReadLine()) != null)
                {
                    if (i % 1000 == 0 || i < 100)
                    {
                        var indexable = Indexable.Parse(str);
                        if (indexable.IndexableType.Code.Equals("(SERIES)"))
                        {
                            if (!series.ContainsKey(indexable.Title))
                            {
                                series.Add(indexable.Title, indexable);
                            }
                            else
                            {
                                if (series[indexable.Title].Episodes == null) series[indexable.Title].Episodes = new List<IndexLeaf>();
                                series[indexable.Title].Episodes.Add(indexable.Episodes[0]);
                            }

                        }
                        //sw.WriteLine(string.Format("{0} source => {1}", indexable.Title, str));

                    }
                    ++i;
                }
                if (series != null && series.Count > 0)
                {
                    foreach (var val in series.Values)
                    {
                        sw.WriteLine(val.ToString());
                    }
                }
                
            }


            Console.WriteLine("Done.");
            Console.Read();
        }
    }
}
