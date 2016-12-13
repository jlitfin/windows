using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;

using JPL.Lib.MediaLibraryReader;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Update Library

            //LibraryReader reader = new LibraryReader(@"C:\Users\jlit\Documents\My Dropbox\Docs\iTunes Music Library.xml");
            //reader.TransformToDb();

            //Console.WriteLine(reader.DebugString);

            #endregion

            #region test IMDB search

            //string str = "The Bourne Identity";
            //string result = IMDBService.GetIMDBInfoJson(str);

            //Console.WriteLine(result);

            //string str = "The Blue Planet";
            //string result = IMDBService.GetIMDBSeriesInfoJson(str);

            //Console.WriteLine(result);

            #endregion

            #region json tests

            testObj o = GetTO();
            StringBuilder sb = new StringBuilder();
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            oSerializer.Serialize(o, sb);

            object obj = oSerializer.Deserialize(sb.ToString(), Type.GetType("System.Object"));
            
            Console.WriteLine(sb.ToString());

            #endregion

            Console.WriteLine("press a key to end ... ");
            Console.Read();
            
        }

        public static testObj GetTO()
        {
            testObj o = new testObj();
            o.ihateyou.year = "2012";
            worst w = new worst();
            w.name = "n1";
            w.number = "1";
            o.ihateyou.episodes.Add(w);
            w = new worst();
            w.name = "n2";
            w.number = "2";
            o.ihateyou.episodes.Add(w);

            return o;

        }

    }

}
