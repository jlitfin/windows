using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class DirectorListItemRepository : FileItemRepository
    {
        public override IFileItem AddOrUpdate(int fileId, string source)
        {
            DirectorListItem item = null;
            if (string.IsNullOrWhiteSpace(source)) return null;
            var tokens = ParseToTokens(source);

            using (var db = new MdbContext())
            {
                var id = tokens[(int)DirectorListItemFieldIndex.DirectorListItemId];
                item = db.DirectorListItems.SingleOrDefault(a => a.Id == id);
                if (item == null)
                {
                    item = new DirectorListItem
                    {
                        Id = id,
                        FirstName = tokens[(int)DirectorListItemFieldIndex.FirstName],
                        LastName = tokens[(int)DirectorListItemFieldIndex.LastName]
                    };
                }
                else
                {
                    item.FirstName = tokens[(int)DirectorListItemFieldIndex.FirstName];
                    item.LastName = tokens[(int)DirectorListItemFieldIndex.LastName];
                }

                for (var i = (int)DirectorListItemFieldIndex.Credits; i < tokens.Count; ++i)
                {
                    var credit = DirectorCreditRepository.Get(id, tokens[i]);
                    if (credit.Id == 0)
                    {
                        //
                        // add if new and not a dupe by our columns
                        //
                        if (item.Credits == null) item.Credits = new List<DirectorCredit>();
                        if (!item.Credits.Any(a => a.DirectorListItemId == credit.DirectorListItemId
                                 && a.MovieListItemId == credit.MovieListItemId
                                 && a.Title == credit.Title
                                 && a.Season == credit.Season
                                 && a.Episode == credit.Episode))
                        {
                            item.Credits.Add(credit);
                        }
                    }
                }

                db.DirectorListItems.AddOrUpdate(item);
                db.SaveChanges();
            }
            return item;
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
