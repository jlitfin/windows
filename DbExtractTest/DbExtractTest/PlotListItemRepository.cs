using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class PlotListItemRepository : FileItemRepository
    {

        public IFileItem AddOrUpdate(int id, string source)
        {
            throw new NotImplementedException();
        }

        public override List<string> ParseToTokens(string source)
        {
            var tokens = new List<string>();
            if (source.StartsWith("MV: "))
            {
                tokens = new List<string>();
                var ndx = FileItemRepository.FindKeyDate(4, source);
                if (ndx > 0)
                {
                    var key = source.Substring(4, ndx - 3).Trim();
                    tokens.Add(key);

                    //
                    // check for episode
                    //
                    ndx = FileItemRepository.NextCharacter(ndx, source);
                    var odx = source.IndexOf("(#", ++ndx);
                    if (odx > 0)
                    {
                        var qdx = source.IndexOf("(#", odx + 2);
                        if (qdx > 0) odx = qdx;

                        // season / episode segment
                        ndx = source.IndexOf(")", odx);
                        var pdx = source.IndexOf(".", odx);

                        tokens.Add(source.Substring(odx + 2, pdx - (odx + 2)).Trim());
                        tokens.Add(source.Substring(pdx + 1, ndx - (pdx + 1)).Trim());
                    }
                    else
                    {
                        tokens.Add(Constants.NullFieldValue);
                        tokens.Add(Constants.NullFieldValue);
                    }

                    tokens.Add(source.Substring(ndx));
                }
            }
            return tokens;
        }
    }
}
