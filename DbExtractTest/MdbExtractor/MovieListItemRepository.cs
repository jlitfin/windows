using System.Collections.Generic;
using System.Linq;

namespace MdbExtractor
{
    public class MovieListItemRepository : FileItemRepository
    {
        public override IFileItem AddOrUpdate(int fileId, string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                using (var db = new MdbContext())
                {
                    var item = new MovieListItem(ParseToTokens(source));
                    var existing = db.MovieListItems.SingleOrDefault(m => m.Id == item.Id);
                    if (existing == null)
                    {
                        db.MovieListItems.Add(item);
                        db.SaveChanges();
                        return item;
                    }
                }
            }
            return null;
        }


        public static List<string> ParseToTokens(string source)
        {
            var ret = new List<string>();
            var ndx = NextDelimiter(source.Length - 1, source, '\t', 1, true);
            if (ndx < source.Length)
            {
                ret.AddRange(ParseMovieItemKey(source.Substring(0, ndx).Trim()));
                ret.Add(source.Substring(ndx).Trim());
            }
            return ret;
        }
    }
}
