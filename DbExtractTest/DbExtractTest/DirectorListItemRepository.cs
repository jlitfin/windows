using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class DirectorListItemRepository : FileItemRepository
    {
        public override IFileItem AddOrUpdate(int id, string source)
        {
            throw new NotImplementedException();
        }

        public override List<string> ParseToTokens(string source)
        {
            var tokens = new List<string>();
            var ndx = source.IndexOf("\t");

            if (ndx > 0)
            {
                // name id
                var name = source.Substring(0, ndx).Trim();
                tokens.Add(name);
                var cdx = name.IndexOf(',');
                if (cdx > 0 && cdx < ndx)
                {
                    var fname = name.Substring(0, cdx);
                    var lname = name.Substring(cdx + 1);
                    tokens.Add(fname);
                    tokens.Add(lname);
                }
                else
                {
                    tokens.Add(Constants.NullFieldValue);
                    tokens.Add(Constants.NullFieldValue);
                }
                ndx = NextCharacter(ndx, source);
            }
            else
            {
                tokens.Add(Constants.NullFieldValue);
                tokens.Add(Constants.NullFieldValue);
                tokens.Add(Constants.NullFieldValue);
            }

            // movie item key
            var odx = FindKeyDate(ndx, source);
            tokens.Add(source.Substring(ndx, odx - ndx + 1).Trim());

            // check for episode
            ndx = NextCharacter(odx + 1, source);
            if (ndx < source.Length && source[ndx].Equals('{'))
            {
                // series segment
                odx = source.IndexOf("(#", ++ndx);
                if (odx > 0)
                {
                    //
                    // check for stupid title segment contains key string
                    //
                    var qdx = source.IndexOf("(#", odx + 2);
                    if (qdx > 0) odx = qdx;

                    // title segment
                    if (odx != (ndx + 1))
                    {
                        tokens.Add(source.Substring(ndx, odx - ndx).Trim());
                    }
                    else
                    {
                        tokens.Add(Constants.NullFieldValue);
                    }

                    // season / episode segment
                    ndx = source.IndexOf(")", odx);
                    var pdx = source.IndexOf(".", odx);

                    tokens.Add(source.Substring(odx + 2, pdx - (odx + 2)).Trim());
                    tokens.Add(source.Substring(pdx + 1, ndx - (pdx + 1)).Trim());
                }
                else if (source[ndx] == '(')
                {
                    odx = source.IndexOf(")", ndx);
                    if (odx > 0 && odx > ndx)
                    {
                        var val = source.Substring(ndx + 1, odx - (ndx + 1));
                        tokens.Add(val);
                    }
                }
            }

            while (tokens.Count < 7)
            {
                tokens.Add(Constants.NullFieldValue);
            }

            return tokens;
        }

    }
}
