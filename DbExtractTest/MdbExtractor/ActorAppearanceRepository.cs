using System.Collections.Generic;
using System.Linq;

namespace MdbExtractor
{
    public class ActorAppearanceRepository
    {
        public static ActorAppearance Get(string key, string source)
        {
            var tokens = ParseToTokens(source);
            if (tokens != null)
            {
                var movieItem = new MovieListItem(tokens);
                var appearance = new ActorAppearance(movieItem.Id, key);
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

            return null;
        }

        public static List<string> ParseToTokens(string source)
        {
            try
            {
                return FileItemRepository.ParseMovieItemKey(source);
            }
            catch 
            {
                return null;
            }
        }
    }
}
