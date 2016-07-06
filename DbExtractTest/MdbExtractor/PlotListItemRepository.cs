using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MdbExtractor
{
    public class PlotListItemRepository : FileItemRepository
    {

        public override IFileItem AddOrUpdate(int fileId, string source)
        {
            if (string.IsNullOrWhiteSpace(source)) return null;
            var tokens = ParseToTokens(source);
            using (var db = new MdbContext())
            {
                var item = new PlotListItem(tokens);
                var existing = db.PlotListItems.SingleOrDefault(p => p.Id == item.Id);
                if (existing == null)
                {
                    db.PlotListItems.Add(item);
                    db.SaveChanges();
                    return item;
                }

                existing.Plot = item.Plot;
                db.SaveChanges();
                return existing;

            }
        }

        public override List<string> ParseToTokens(string source)
        {
            var tokens = new List<string>();
            if (source.StartsWith("MV: "))
            {
                tokens = new List<string>();
                var targetLine = source.Substring(4, source.IndexOf(Environment.NewLine));
                tokens.Add(new MovieListItem(ParseMovieItemKey(targetLine)).Id);

                var txt = source.Substring(targetLine.Length);
                var sb = new StringBuilder();
                string[] lines = txt.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var l in lines)
                {
                    if (l.StartsWith("PL: "))
                    {
                        sb.Append((l.Substring(4).PadRight(l.Length - 3, ' ')));

                    }
                }
                tokens.Add(sb.ToString());
            }
            return tokens;
        }
    }
}
