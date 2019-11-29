using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pgn
{
    public class PgnReader
    {
        private string _sourcePath;

        public static readonly HashSet<string> ResultOptions = new HashSet<string> { "1-0", "1/2-1/2", "0-1", "*" };
        public PgnReader(string path)
        {
            _sourcePath = path;
        }

        public IEnumerable<Pgn> SelectPGN()
        {
            if (!string.IsNullOrEmpty(_sourcePath) && File.Exists(_sourcePath))
            {
                using (var sr = new StreamReader(_sourcePath))
                {
                    var sb = new StringBuilder();
                    var line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        while (line != null && line.Length == 0)
                        {
                            line = sr.ReadLine();
                        }

                        if (line != null)
                        {
                            sb.AppendLine(line);
                            if (ResultOptions.Contains(line.Split(' ').Last()))
                            {
                                var ret = new Pgn(sb.ToString());
                                sb.Clear();
                                yield return ret;
                            }
                        }
                    }
                }
            }
            else
            {
                throw new Exception($"File not found. [{_sourcePath}])");
            }
        }
    }
}
