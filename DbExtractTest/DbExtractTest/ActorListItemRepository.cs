using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class ActorListItemRepository : FileItemRepository
    {
        public override IFileItem AddOrUpdate(int fileId, string source)
        {
            ActorListItem item = null;
            if (string.IsNullOrWhiteSpace(source)) return null;
            var tokens = ParseToTokens(source);

            using (var db = new MdbContext())
            {
                var id = tokens[(int) ActorListItemFieldIndex.ActorListItemId];
                item = db.ActorListItems.SingleOrDefault(a => a.Id == id);
                if (item == null)
                {
                    item = new ActorListItem
                    {
                        Id = id,
                        FirstName = tokens[(int) ActorListItemFieldIndex.FirstName],
                        LastName = tokens[(int) ActorListItemFieldIndex.LastName]
                    };
                }
                else
                {
                    item.FirstName = tokens[(int) ActorListItemFieldIndex.FirstName];
                    item.LastName = tokens[(int) ActorListItemFieldIndex.LastName];
                }

                for (var i = (int) ActorListItemFieldIndex.Appearances; i < tokens.Count; ++i)
                {
                    var appearance = ActorAppearanceRepository.Get(id, tokens[i]);
                    if (appearance.Id == 0)
                    {
                        //
                        // add if new and not a dupe by our columns
                        //
                        if (item.AppearanceList == null) item.AppearanceList = new List<ActorAppearance>();
                        if (!item.AppearanceList.Any(a => a.ActorListItemId == appearance.ActorListItemId
                                 && a.MovieListItemId == appearance.MovieListItemId
                                 && a.Title == appearance.Title
                                 && a.Season == appearance.Season
                                 && a.Episode == appearance.Episode))
                        {
                            item.AppearanceList.Add(appearance);
                        }
                    }
                }

                db.ActorListItems.AddOrUpdate(item);
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
