using System;
using System.Collections.Generic;
using System.Linq;

namespace MdbExtractor
{
    public class DirectorListItemRepository : FileItemRepository
    {
        public override IFileItem AddOrUpdate(int fileId, string source)
        {
            if (string.IsNullOrWhiteSpace(source)) return null;
            var tokens = ParseToTokens(source);

            using (var db = new MdbContext())
            {
                var item = new DirectorListItem(tokens);
                var existing = db.DirectorListItems.SingleOrDefault(d => d.Id == item.Id);

                db.SaveChanges();
            }
            return null;
        }

        public override List<string> ParseToTokens(string source)
        {
            var tokens = new List<string>();
            string[] lines = source.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var headLine = lines[0];
            var ndx = headLine.IndexOf("\t");
            //
            // name id [0]
            //
            var name = headLine.Substring(0, ndx).Trim();
            tokens.Add(name);
            var cdx = name.IndexOf(',');
            if (cdx > 0 && cdx < ndx)
            {
                var fname = name.Substring(0, cdx).Trim();
                var lname = name.Substring(cdx + 1).Trim();

                tokens.Add(fname); // [1]
                tokens.Add(lname); // [2]
            }
            else
            {
                tokens.Add(Constants.NullFieldValue);
                tokens.Add(Constants.NullFieldValue);
            }

            lines[0] = headLine.Substring(NextCharacter(ndx, headLine));
            tokens.AddRange(lines);
            return tokens;
        }

    }
}
