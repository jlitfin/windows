using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class SearchResult
    {
        public string BestMove { get; set; }
        public List<Variation> Variations { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{BestMove}");
            foreach (var v in Variations.OrderBy(v => v.VariationId))
            {
                sb.AppendLine($" > {v.ToString()}");
            }
            return sb.ToString();
        }

        public string Move
        {
            get
            {
                var tokens = BestMove.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return tokens[1].Trim();
            }
        }
    }
}

