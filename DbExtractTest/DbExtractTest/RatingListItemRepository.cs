using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;


namespace DbExtractTest
{
    public class RatingListItemRepository : FileItemRepository
    {
        public override IFileItem AddOrUpdate(int fileId, string source)
        {
            var tokens = ParseToTokens(source);
            using (var db = new MdbContext())
            {
                var keyTokens = ParseMovieItemKey(tokens[(int) RatingListItemFieldIndex.Key]);
                var item = new RatingListItem
                {
                    Distribution = tokens[(int) RatingListItemFieldIndex.Distribution],
                    Rank = Decimal.Parse(tokens[(int) RatingListItemFieldIndex.Rank]),
                    Votes = Int64.Parse(tokens[(int) RatingListItemFieldIndex.Votes]),
                    //MovieListItemId = keyTokens[(int) MovieKeyFieldIndex.MovieListItemId],
                    //Title = keyTokens[(int) MovieKeyFieldIndex.Title],
                    //Season = keyTokens[(int) MovieKeyFieldIndex.Season],
                    //Episode = keyTokens[(int) MovieKeyFieldIndex.Episode]
                };

                var check =
                    db.RatingListItems.SingleOrDefault(
                        r => r.Id == item.Id);

                if (check == null)
                {
                    db.RatingListItems.AddOrUpdate(item);
                    db.SaveChanges();
                    return item;
                }

                check.Distribution = item.Distribution;
                check.Rank = item.Rank;
                check.Votes = item.Votes;
                db.RatingListItems.AddOrUpdate(check);
                db.SaveChanges();
                return check;
            }

        }

        public override List<string> ParseToTokens(string source)
        {
            List<string> tokens = source.Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return tokens;
        }
    }
}
