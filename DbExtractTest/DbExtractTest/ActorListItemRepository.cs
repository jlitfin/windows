using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class ActorListItemRepository : FileItemRepository
    {
        public const string _file = "actorlistrepository.error.txt";
        public override IFileItem AddOrUpdate(int fileId, string source)
        {
            if (string.IsNullOrWhiteSpace(source)) return null;
            var tokens = ParseToTokens(source);
            var item = new ActorListItem(tokens);
            using (var db = new MdbContext())
            {
                var existing = db.ActorListItems.SingleOrDefault(a => a.Id == item.Id);
                var appearances = new List<ActorAppearance>();
                for (var i = (int)ActorListItemFieldIndex.Appearances; i < tokens.Count; ++i)
                {
                    var chk = ActorAppearanceRepository.Get(item.Id, tokens[i]);
                    if (chk != null)
                    {
                        appearances.Add(chk);
                    }
                }
                var appearancesToInsert = existing == null
                    ? appearances
                    : (from a in appearances
                        where !existing.AppearanceList.Contains(a) 
                        select a);
                appearancesToInsert = appearancesToInsert.GroupBy(a => a.MovieListItemId).Select(g => g.First()).ToList();

                using (var sw = new StreamWriter(_file, true))
                {
                    try
                    {
                        if (existing == null)
                        {
                            item.AppearanceList.AddRange(appearancesToInsert);
                            db.ActorListItems.Add(item);
                            db.SaveChanges();
                            return item;
                        }
                        else
                        {
                            existing.AppearanceList.AddRange(appearancesToInsert);
                            db.SaveChanges();
                            return existing;
                        }
                    }
                    catch (Exception ex)
                    {
                        var sb = new StringBuilder();
                        var tmp = ex;
                        while (tmp != null)
                        {
                            sb.AppendLine(tmp.Message);
                            sb.AppendLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                            tmp = tmp.InnerException;
                        }
                        var msg = string.Format("{0}: {1}{2}{3}{2}{4}", 
                            DateTime.Now.ToString(), _file, Environment.NewLine,
                            "-----------------------------------------------",
                            sb.ToString());

                        sw.WriteLine(msg);

                        throw;
                    }
                }
            }
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
            tokens.Add(name.ToUpper());
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
