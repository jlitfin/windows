using System;
using System.Linq;
using System.Collections.Generic;

using Board;

namespace Pgn
{
    public class Pgn
    {
        private string _source;
        private string[] _lines;
        private Board.GameState _board;

        public static readonly HashSet<string> HeaderKeys = new HashSet<string>(new string[]
        {
        "Event",
        "Site",
        "Date",
        "Round",
        "White",
        "Black",
        "Result"
        });
        public Dictionary<string, string> Headers { get; set; }
        public List<Ply> MoveList { get; set; }

        public string GetMoveListString()
        {
            if (MoveList != null && MoveList.Count > 0)
            {
                return string.Join(" ", MoveList.Select(x => $"{x.MoveNumber}. {x.White} {x.Black}"));
            }
            return string.Empty;
        }


        public Pgn(string source)
        {
            _source = source;
            Parse();

            _board = new Board.GameState();
            _board.StartPosition();
        }

        private void Parse()
        {
            var lineNumber = ParseHeaders();
            ParseMoveListString(lineNumber);
        }

        private int ParseHeaders()
        {
            Headers = new Dictionary<string, string>();
            _lines = _source.Split('\n');
            for (int i = 0; i < _lines.Length; ++i)
            {
                if (_lines[i].Trim().StartsWith("["))
                {
                    var valStart = _lines[i].IndexOf('"');
                    var key = _lines[i].Substring(1, valStart - 1).Trim();
                    var value = _lines[i].Substring(valStart + 1, _lines[i].IndexOf('"', valStart + 1) - (valStart + 1)).Trim();

                    if (HeaderKeys.Contains(key) && !Headers.ContainsKey(key))
                    {
                        Headers.Add(key, value);
                    }
                }
                else
                {
                    return i;
                }
            }
            return 0;
        }

        private void ParseMoveListString(int startingLineNumber)
        {
            MoveList = new List<Ply>();
            var currentMove = new Ply { MoveNumber = 0 };
            var currentToken = 0;
            for (int i = startingLineNumber; i < _lines.Length; ++i)
            {
                var line = _lines[i];
                for (int j = 0; j < line.Length; ++j)
                {
                    if (line[j] == '{')
                    {
                        j = ReadUntil(line, j, '}');
                        continue;
                    }
                    if (line[j] == ';')
                    {
                        break;
                    }

                    var ndx = MoveToNext(line, j);
                    var edx = MoveToEnd(line, ndx);
                    var token = line.Substring(ndx, edx - ndx);
                    j = edx;

                    if (!string.IsNullOrEmpty(token))
                    {
                        switch (currentToken)
                        {
                            case 0:
                                currentMove = new Ply { MoveNumber = currentMove.MoveNumber + 1 };
                                ++currentToken;
                                break;
                            case 1:
                                currentMove.White = token;
                                ++currentToken;
                                break;
                            case 2:
                                currentMove.Black = token;
                                MoveList.Add(currentMove);
                                currentToken = 0;
                                break;
                        }
                    }
                }
            }
        }

        private int ReadUntil(string source, int start, char ch)
        {
            var i = start;
            while (i < source.Length && source[i] != ch)
            {
                ++i;
            }
            return i;
        }

        private int MoveToNext(string source, int start)
        {
            var i = start;
            while (i < source.Length && Char.IsWhiteSpace(source[i]))
            {
                ++i;
            }
            return i;
        }

        private int MoveToEnd(string source, int start)
        {
            var i = start;
            while (i < source.Length && !Char.IsWhiteSpace(source[i]))
            {
                ++i;
            }
            return i;
        }
    }
}
