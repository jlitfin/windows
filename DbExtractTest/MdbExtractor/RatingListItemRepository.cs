using System;
using System.Collections.Generic;
using System.Linq;

namespace MdbExtractor
{
    public class RatingListItemRepository : FileItemRepository
    {
        public override IFileItem AddOrUpdate(int fileId, string source)
        {
            var tokens = ParseToTokens(source);
            using (var db = new MdbContext())
            {
                var movieItem =
                    new MovieListItem(MovieListItemRepository.ParseToTokens(tokens[(int) RatingListItemFieldIndex.Key]));
                var item = new RatingListItem
                {
                    Distribution = tokens[(int) RatingListItemFieldIndex.Distribution],
                    Rank = Decimal.Parse(tokens[(int) RatingListItemFieldIndex.Rank]),
                    Votes = Int64.Parse(tokens[(int) RatingListItemFieldIndex.Votes]),
                    MovieListItemId = movieItem.Id
                };

                var check =
                    db.RatingListItems.SingleOrDefault(
                        r => r.Id == item.Id);

                if (check == null)
                {
                    db.RatingListItems.Add(item);
                    db.SaveChanges();
                    return item;
                }

                check.Distribution = item.Distribution;
                check.Rank = item.Rank;
                check.Votes = item.Votes;
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
