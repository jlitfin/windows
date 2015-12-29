using System;
using System.Collections.Generic;
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
            //using (var sr = new StreamReader("actors.list.gz"))
            //using (var sw = new StreamWriter("actors.dat"))
            using (var sr = new StreamReader("movies.list.gz"))
            using (var sw = new StreamWriter("movies.dat"))
            {
                
                for (int i = 0; i < 564046; ++i)
                {
                    if (i >= 564042)
                    {
                        sw.WriteLine(sr.ReadLine());
                    }
                    else
                    {
                        sr.ReadLine();
                    }
                }
                
            }


            Console.WriteLine("Done.");
            Console.Read();
        }
    }
}
