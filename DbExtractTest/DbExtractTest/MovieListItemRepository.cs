using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class MovieListItemRepository : FileItemRepository
    {
        public override IFileItem AddOrUpdate(int fileId, string source)
        {
            MovieListItem item = null;
            if (string.IsNullOrEmpty(source)) return null;
            var tokens = ParseToTokens(source);
            using (var db = new MdbContext())
            {
                var id = tokens[(int)MovieListItemFieldIndex.Id];
                item = db.MovieListItems.SingleOrDefault(m => m.Id == id);
                if (item != null)
                {
                    var season = tokens[(int)MovieListItemEpisodeFieldIndex.Season];
                    if (!season.Equals(Constants.NullFieldValue))
                    {
                        var title = tokens[(int)MovieListItemEpisodeFieldIndex.Title];
                        var episode = tokens[(int)MovieListItemEpisodeFieldIndex.Episode];
                        if (!item.Episodes.Any(x => x.MovieListItemId == id && x.Season == season && x.Episode == episode))
                        {
                            item.Episodes.Add(new MovieListItemEpisode
                            {
                                Title = title.Equals(Constants.NullFieldValue) ? null : title,
                                Season = season,
                                Episode = episode
                            });
                        }
                    }
                }
                else
                {
                    item = new MovieListItem();
                    item.FileDataDetailId = fileId;
                    item.Source = source;
                    item.Id = tokens[(int)MovieListItemFieldIndex.Id];
                    item.Title = tokens[(int)MovieListItemFieldIndex.Title];
                    item.Year = tokens[(int)MovieListItemFieldIndex.Year] == Constants.NullFieldValue
                        ? ParseKeyDate(0, item.Id)
                        : tokens[(int) MovieListItemFieldIndex.Year];

                    var code = tokens[(int) MovieListItemFieldIndex.MovieListItemType];
                    var type = db.MovieListItemTypes.SingleOrDefault(it => it.Code == code);
                    item.MovieListItemTypeId = type.Id;

                    item.Episodes = new List<MovieListItemEpisode>();
                    var season = tokens[(int) MovieListItemEpisodeFieldIndex.Season];
                    if (!season.Equals(Constants.NullFieldValue))
                    {
                        var title = tokens[(int) MovieListItemEpisodeFieldIndex.Title];
                        var episode = tokens[(int) MovieListItemEpisodeFieldIndex.Episode];

                        item.Episodes.Add(new MovieListItemEpisode
                        {
                            Title = title.Equals(Constants.NullFieldValue) ? null : title,
                            Season = season,
                            Episode = episode
                        });

                    }
                }

                db.MovieListItems.AddOrUpdate(item);
                db.SaveChanges();
            }

            return item;
        }

        public override List<string> ParseToTokens(string source)
        {
            var ret = new List<string>();
            var ndx = FindKeyDate(0, source);
            var key = source.Substring(0, ++ndx);
            ret.Add(key);

            var title = key.Substring(0, key.IndexOf("(")).Trim();
            ret.Add(title);

            ndx = NextCharacter(ndx, source);
            if (ndx < source.Length)
            {
                if (source[ndx].Equals('{'))
                {
                    //
                    // add empty code token
                    //
                    ret.Add(Constants.NullFieldValue);

                    // series segment
                    var odx = source.IndexOf("(#", ++ndx);

                    if (odx > 0)
                    {
                        //
                        // check for stupid title segment contains key string
                        //
                        var qdx = source.IndexOf("(#", odx + 2);
                        if (qdx > 0) odx = qdx;

                        // title segment
                        if (odx != ndx)
                        {
                            ret.Add(source.Substring(ndx, odx - ndx).Trim());
                        }
                        else
                        {
                            ret.Add(Constants.NullFieldValue);
                        }

                        // season / episode segment
                        ndx = source.IndexOf(")", odx);
                        var pdx = source.IndexOf(".", odx);

                        ret.Add(source.Substring(odx + 2, pdx - (odx + 2)).Trim());
                        ret.Add(source.Substring(pdx + 1, ndx - (pdx + 1)).Trim());
                        ret.Add(source.Substring(ndx + 2).Trim());
                    }
                    else
                    {
                        ret.Add(Constants.NullFieldValue);
                        ret.Add(Constants.NullFieldValue);
                        ret.Add(Constants.NullFieldValue);
                        ret.Add(Constants.NullFieldValue);
                    }
                }
                else if (source[ndx].Equals('('))
                {
                    // code token
                    var odx = source.IndexOf(")", ndx);
                    ret.Add(source.Substring(ndx, ++odx - ndx).Trim());
                    //
                    // add empty series segments
                    //
                    ret.Add(Constants.NullFieldValue);
                    ret.Add(Constants.NullFieldValue);
                    ret.Add(Constants.NullFieldValue);

                    // year terminal token
                    ret.Add(source.Substring(odx).Trim());
                }
                else
                {
                    //
                    // add empty code token
                    //
                    ret.Add(Constants.NullFieldValue);
                    //
                    // add empty series segment
                    //
                    ret.Add(Constants.NullFieldValue);
                    ret.Add(Constants.NullFieldValue);
                    ret.Add(Constants.NullFieldValue);

                    // year terminal token
                    ret.Add(source.Substring(ndx).Trim());
                }
            }
            return ret;
        }


    }
}
