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
            var appearance = new ActorAppearance
            {
                ActorListItemId = key,
                MovieListItemId = tokens[(int)ActorAppearanceFieldIndex.MovieListItemId],
                Title = tokens[(int)ActorAppearanceFieldIndex.Title],
                Season = tokens[(int)ActorAppearanceFieldIndex.Season],
                Episode = tokens[(int)ActorAppearanceFieldIndex.Episode]
            };

            using (var db = new MdbContext())
            {
                var existing =
                    db.ActorAppearances.SingleOrDefault(
                        a => a.ActorListItemId == appearance.ActorListItemId 
                            && a.MovieListItemId == appearance.MovieListItemId 
                            && a.Title == appearance.Title
                            && a.Season == appearance.Season 
                            && a.Episode == appearance.Episode);

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
