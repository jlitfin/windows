using System;
using System.Text;

namespace Core
{
    public class Variation
    {
        private string _info;

        public Variation(string info)
        {
            _info = info;
            Parse();
        }

        public int VariationId { get; set; }

        public int Depth { get; set; }

        public int? Score { get; set; }

        public int? MateIn { get; set; }

        public string Line { get; set; }

        private void Parse()
        {
            if (!string.IsNullOrEmpty(_info) && _info.StartsWith("info"))
            {
                var tokens = _info.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < tokens.Length; ++i)
                {
                    var t = tokens[i].Trim();
                    if (string.Equals(t, "depth", StringComparison.OrdinalIgnoreCase))
                    {
                        var v = tokens[i + 1].Trim();
                        Depth = int.Parse(v);
                    }

                    if (string.Equals(t, "multipv", StringComparison.OrdinalIgnoreCase))
                    {
                        var v = tokens[i + 1].Trim();
                        VariationId = int.Parse(v);
                    }

                    if (string.Equals(t, "score", StringComparison.OrdinalIgnoreCase))
                    {
                        var v = tokens[i + 1].Trim();
                        if (string.Equals(v, "mate", StringComparison.OrdinalIgnoreCase))
                        {
                            MateIn = int.Parse(tokens[i + 2].Trim());
                            Score = null;
                        }
                        else if (string.Equals(v, "cp", StringComparison.OrdinalIgnoreCase))
                        {
                            Score = int.Parse(tokens[i + 2].Trim());
                            MateIn = null;
                        }
                        
                    }

                    if (string.Equals(t, "pv", StringComparison.OrdinalIgnoreCase))
                    {
                        var sb = new StringBuilder();
                        for (int j = i + 1; j < tokens.Length; ++j)
                        {
                            sb.Append(tokens[j]).Append(" ");
                        }
                        Line = sb.ToString();
                    }
                }
            }
        }
    }
}
