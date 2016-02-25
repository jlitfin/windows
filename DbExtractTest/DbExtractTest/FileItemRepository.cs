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

        public void Dispose()
        {
            
        }
    }
}
