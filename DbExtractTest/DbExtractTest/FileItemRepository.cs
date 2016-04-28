using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Odbc;
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

        public static int NextDelimiter(int startIndex, string source, char delimiter, int afterAtLeastCount, bool reverseOrder = false)
        {
            var spacer = "".PadRight(afterAtLeastCount, delimiter);
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
            if (!ValidateMovieItemKeyString(source))
            {
                throw new Exception(string.Format("Invalid movie key format: {0}", source));
            }

            var tokens = new List<string>();
            try
            {   
                // movie item key
                var ndx = 0;
                var str = source.Trim();
                var odx = FindKeyDate(0, str);
                var key = str.Substring(ndx, odx - ndx + 1).Trim();
                tokens.Add(key);

                ndx = NextCharacter(odx + 1, str);
                // check for type code and skip it
                if (ndx < str.Length && str[ndx].Equals('('))
                {
                    odx = str.IndexOf(')', ndx + 1);
                    ndx = NextCharacter(odx + 1, str);
                }

                // check for episode
                if (ndx < str.Length && str[ndx].Equals('{'))
                {
                    // series segment
                    odx = str.IndexOf("(#", ++ndx);
                    var rdx = str.IndexOf("}", ndx);
                    if (odx >= ndx && odx < rdx)
                    {
                        //
                        // check for title segment contains key string
                        //
                        var qdx = str.IndexOf("(#", odx + 2);
                        if (qdx > odx && qdx < rdx) odx = qdx;

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
            }
            catch (Exception)
            {

                throw new Exception(string.Format("Could not parse movie item key: {0}", source));
            }

            return tokens;
        }

        public static bool ValidateMovieItemKeyString(string source)
        {
            var openParenCount  = 0;
            var closeParenCount = 0;
            var openBracketCount = 0;
            var closeBracketCount = 0;
            for (var i = 0; i < source.Length; ++i)
            {
                if (source[i] == '(')
                {
                    if (closeParenCount > openParenCount) return false;

                    openParenCount++;
                }
                if (source[i] == ')')
                {
                    closeParenCount++;
                }

                if (source[i] == '{')
                {
                    if (closeBracketCount > openBracketCount) return false;

                    openBracketCount++;
                }
                if (source[i] == '}')
                {
                    closeBracketCount++;
                }
            }

            if (openParenCount != closeParenCount) return false;



            return true;
        }

        public void Dispose()
        {
            
        }
    }
}
