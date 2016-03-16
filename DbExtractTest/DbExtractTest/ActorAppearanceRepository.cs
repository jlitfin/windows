using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class ActorAppearanceRepository
    {
        public static ActorAppearance Get(string key, string source)
        {
            var tokens = ParseToTokens(source);
            //
            // this file doesn't contain the final year token so add an empty to make
            // the list the correct shape
            //
            tokens.Add(Constants.NullFieldValue);
            var movieItem = new MovieListItem(tokens);
            var appearance = new ActorAppearance
            {
                ActorListItemId = key,
                MovieListItemId = movieItem.Id,
            };

            using (var db = new MdbContext())
            {
                var existing =
                    db.ActorAppearances.SingleOrDefault(
                        a => a.ActorListItemId == appearance.ActorListItemId
                             && a.MovieListItemId == appearance.MovieListItemId);

                if (existing != null)
                {
                    return existing;
                }
            }

            return appearance;
        }

        public static List<string> ParseToTokens(string source)
        {
            return FileItemRepository.ParseMovieItemKey(source);
        }
    }
}
