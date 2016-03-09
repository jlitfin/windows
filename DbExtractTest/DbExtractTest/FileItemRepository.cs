using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public class FileItemRepository : IFileItemRepository
    {
        public virtual IFileItem AddOrUpdate(int fileId, string source)
        {
            throw new NotImplementedException();
        }

        public virtual List<string> ParseToTokens(string source)
        {
            throw new NotImplementedException();
        }

        public static int NextCharacter(int startIndex, string source)
        {
            while (startIndex < source.Length && char.IsWhiteSpace(source, startIndex))
            {
                startIndex++;
            }
            return startIndex;
        }

        public static int NextDelimiter(int startIndex, string source, int afterAtLeastCount, bool reverseOrder = false)
        {
            var spacer = "".PadRight(afterAtLeastCount, ' ');
            int index = -1;
            if (reverseOrder)
            {
                index = source.LastIndexOf(spacer, startIndex);
            }
            else
            {
                index = source.IndexOf(spacer, startIndex); 
            }

            if (index < 0) return source.Length;
            return index;
        }

        public static int FindKeyDate(int startIndex, string source)
        {
            while (startIndex < source.Length)
            {
                var ndx = source.IndexOf("(", startIndex);
                var odx = source.IndexOf(")", ndx >= 0 ? ndx : source.Length);
                var pdx = source.IndexOf("/", ndx);
                if (ndx < 0 || odx < 0)
                {
                    throw new Exception(string.Format("Improperly formatted data: {0}", source));
                }
                //
                // all keys have a date in this file, but may have other parens so, validate it is a date
                //
                var testString = source.Substring(ndx + 1, (pdx > 0 && pdx > ndx && pdx < odx) ? pdx - (ndx + 1) : odx - (ndx + 1));
                int result;
                if (Int32.TryParse(testString, out result) || testString.Equals("????")) return odx;

                startIndex = odx + 1;
            }

            throw new Exception(string.Format("Improperly formatted data: {0}", source));
        }

        public static string ParseKeyDate(int startIndex, string source)
        {
            while (startIndex < source.Length)
            {
                var ndx = source.IndexOf("(", startIndex);
                var odx = source.IndexOf(")", ndx > 0 ? ndx : source.Length);
                var pdx = source.IndexOf("/", ndx);
                if (ndx < 0 || odx < 0) throw new Exception(string.Format("Improperly formatted data: {0}", source));
                //
                // all keys have a date in this file, but may have other parens so, validate it is a date
                //
                var testString = source.Substring(ndx + 1, (pdx > 0 && pdx > ndx && pdx < odx) ? pdx - (ndx + 1) : odx - (ndx + 1));
                int result;
                if (Int32.TryParse(testString, out result) || testString.Equals("????")) return testString;

                startIndex = odx + 1;
            }

            throw new Exception(string.Format("Improperly formatted data: {0}", source));

        }

        public static List<string> ParseMovieItemKey(string source)
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

        public void Dispose()
        {
            
        }
    }
}
