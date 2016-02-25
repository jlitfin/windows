using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class PlotListItemRepository : FileItemRepository
    {

        public override IFileItem AddOrUpdate(int fileId, string source)
        {
            PlotListItem item = null;
            if (string.IsNullOrWhiteSpace(source)) return null;
            var tokens = ParseToTokens(source);

            var id = tokens[(int)PlotListItemFieldIndex.Id];
            using (var db = new MdbContext())
            {
                var target = db.MovieListItems.SingleOrDefault(m => m.Id == id);
                var season = tokens[(int)PlotListItemFieldIndex.Season];
                var episode = tokens[(int)PlotListItemFieldIndex.Episode];
                if (target != null)
                {
                    item =
                        db.PlotListItems.SingleOrDefault(
                            p => p.MovieListItemId == target.Id && p.Season == season && p.Episode == episode) ??
                        new PlotListItem
                            {
                                MovieListItemId = target.Id,
                                Season = season,
                                Episode = episode
                            };

                    item.Plot = tokens[(int) PlotListItemFieldIndex.Plot];
                    db.PlotListItems.AddOrUpdate(item);
                    db.SaveChanges();
                }
                //else
                //{
                //    throw new ArgumentException("No record of this plot target.");
                //}
            }
            return item;
        }

        public override List<string> ParseToTokens(string source)
        {
            var tokens = new List<string>();
            if (source.StartsWith("MV: "))
            {
                tokens = new List<string>();
                var targetLine = source.Substring(0, source.IndexOf(Environment.NewLine));
                var ndx = FindKeyDate(4, targetLine);
                if (ndx > 0)
                {
                    var key = targetLine.Substring(4, ndx - 3).Trim();
                    tokens.Add(key);

                    //
                    // check for episode
                    //
                    ndx = NextCharacter(ndx, targetLine);
                    var odx = targetLine.IndexOf("(#", ++ndx);
                    if (odx > 0)
                    {
                        var qdx = targetLine.IndexOf("(#", odx + 2);
                        if (qdx > 0) odx = qdx;
                        //
                        // season / episode segment
                        //
                        ndx = targetLine.IndexOf(")", odx);
                        var pdx = targetLine.IndexOf(".", odx);

                        tokens.Add(targetLine.Substring(odx + 2, pdx - (odx + 2)).Trim());
                        tokens.Add(targetLine.Substring(pdx + 1, ndx - (pdx + 1)).Trim());
                    }
                    else
                    {
                        tokens.Add(Constants.NullFieldValue);
                        tokens.Add(Constants.NullFieldValue);
                    }

                    var txt = source.Substring(targetLine.Length);
                    var sb = new StringBuilder();
                    string[] lines = txt.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (var l in lines)
                    {
                        if (l.StartsWith("PL: "))
                        {
                            sb.Append((l.Substring(4).PadRight(l.Length - 3, ' ')));
                            
                        }
                    }
                    tokens.Add(sb.ToString());
                }
            }
            return tokens;
        }
    }
}
