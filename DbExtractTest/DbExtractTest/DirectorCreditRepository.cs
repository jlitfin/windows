using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class DirectorCreditRepository
    {
        public static DirectorCredit Get(string key, string source)
        {
            var tokens = ParseToTokens(source);
            var credit = new DirectorCredit()
            {
                DirectorListItemId = key,
                MovieListItemId = tokens[(int)ActorAppearanceFieldIndex.MovieListItemId],
                Title = tokens[(int)ActorAppearanceFieldIndex.Title],
                Season = tokens[(int)ActorAppearanceFieldIndex.Season],
                Episode = tokens[(int)ActorAppearanceFieldIndex.Episode]
            };

            using (var db = new MdbContext())
            {
                var existing =
                    db.DirectorCredits.SingleOrDefault(
                        a => a.DirectorListItemId == credit.DirectorListItemId
                            && a.MovieListItemId == credit.MovieListItemId
                            && a.Title == credit.Title
                            && a.Season == credit.Season
                            && a.Episode == credit.Episode);

                if (existing != null)
                {
                    return existing;
                }
            }

            return credit;
        }

        public static List<string> ParseToTokens(string source)
        {
            var tokens = new List<string>();
            // movie item key
            var ndx = 0;
            var str = source.Trim();
            var odx = FileItemRepository.FindKeyDate(0, str);
            tokens.Add(str.Substring(ndx, odx - ndx + 1).Trim());

            // check for episode
            ndx = FileItemRepository.NextCharacter(odx + 1, str);
            if (ndx < str.Length && str[ndx].Equals('{'))
            {
                // series segment
                odx = str.IndexOf("(#", ++ndx);
                if (odx > 0)
                {
                    //
                    // check for title segment contains key string
                    //
                    var qdx = str.IndexOf("(#", odx + 2);
                    if (qdx > 0) odx = qdx;

                    // title segment
                    if (odx != (ndx + 1))
                    {
                        tokens.Add(str.Substring(ndx, odx - ndx).Trim());
                    }
                    else
                    {
                        tokens.Add(Constants.NullFieldValue);
                    }

                    // season / episode segment
                    ndx = str.IndexOf(")", odx);
                    var pdx = str.IndexOf(".", odx);

                    tokens.Add(str.Substring(odx + 2, pdx - (odx + 2)).Trim());
                    tokens.Add(str.Substring(pdx + 1, ndx - (pdx + 1)).Trim());
                }
                else if (str[ndx] == '(')
                {
                    odx = str.IndexOf(")", ndx);
                    if (odx > 0 && odx > ndx)
                    {
                        var val = str.Substring(ndx + 1, odx - (ndx + 1));
                        tokens.Add(val);
                    }
                    tokens.Add(Constants.NullFieldValue);
                    tokens.Add(Constants.NullFieldValue);
                }
                else
                {
                    odx = str.IndexOf("}");
                    tokens.Add(str.Substring(ndx + 1, odx - (ndx + 1)));
                    tokens.Add(Constants.NullFieldValue);
                    tokens.Add(Constants.NullFieldValue);
                }
            }
            else
            {
                tokens.Add(Constants.NullFieldValue);
                tokens.Add(Constants.NullFieldValue);
                tokens.Add(Constants.NullFieldValue);
            }

            return tokens;
        }
    }

}
