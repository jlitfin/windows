using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace MediaLibraryReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Building Library ...");
            LibraryReader rdr = new LibraryReader("iTunes Music Library.xml");

            List<Album> albums = rdr.GetAlbums();
            int count = 0;
            foreach (Album a in albums)
            {
                Console.WriteLine(a.Name + " :: " + a.AlbumArtist + " :: " + a.TotalTimeString);
                foreach (Track t in a.Tracks)
                {
                    Console.WriteLine("  " + t.TrackNumber.ToString() + ". " + t.Name + "  " + t.TotalTimeString);
                }

                count++;

                if (count > 4)
                    break;
            }

            Console.ReadLine();

            //Console.WriteLine("Enter Select Field:");
            //string command = Console.ReadLine();
            //while (!command.Equals("quit"))
            //{
            //    Console.WriteLine("Search for (" + command + "):");
            //    //RespondToCommand(command, allTracks);
            //    Console.WriteLine("Enter Select Field:");
            //    command = Console.ReadLine();
            //}
        }

        static void RespondToCommand(string command, List<Track> tracks)
        {
            if (tracks != null && tracks.Count > 0)
            {
                Track t = tracks[0];
                PropertyInfo[] props = t.GetType().GetProperties();

                Dictionary<string, string> resultSet = new Dictionary<string, string>();
                string result = string.Empty;
                foreach (PropertyInfo pi in props)
                {
                    if (command.Equals(pi.Name))
                    {
                        foreach (Track trk in tracks)
                        {
                            object val = pi.GetValue(trk, null);
                            switch (pi.PropertyType.ToString())
                            {
                                case "System.String":
                                    result = (string)val;
                                    break;

                                case "System.Int32":
                                    result = ((int)val).ToString();
                                    break;

                                case "System.DateTime":
                                    result = ((DateTime)val).ToLongDateString();
                                    break;

                            }

                            if (!resultSet.ContainsKey(result))
                            {
                                resultSet.Add(result, result);
                            }
                            
                        }
                        break;
                    }
                }

                foreach (string key in resultSet.Keys)
                {
                    Console.WriteLine(resultSet[key]);
                }
                Console.WriteLine(resultSet.Count.ToString() + " results.");
            }
        }
    }
}
