using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace JPL.Lib.MediaLibraryReader
{
    public static class IMDBService
    {
        private static ImdbSearchRepository __searchRepository;
        private static SystemLogRepository __log;

        public static string GetIMDBInfoJson(string searchString)
        {
            //
            // check search cache
            //
            if (__searchRepository == null) __searchRepository = new ImdbSearchRepository();
            if (__log == null) __log = new SystemLogRepository();

            ImdbSearch result = __searchRepository.Read(searchString);
            bool update = false;
            if (result.ImdbSearchId != 0)
            {
                update = true;
                if (!result.JsonResult.Contains("code\":99"))
                {
                    return result.JsonResult;
                }
            }
            //
            // clatworthy search options 11.29.2013
            //
            // Required
            // 1. q (movie title)
            //
            // Optional
            // 2. type (json [default], jsonp, xml, text) 
            // 3. year  defaults to current
            // 4. yg (1,0) submit 0 to prevent year guess is current
            // 5. token (delimiter for text type return)
            // 6. callback (for jsonp)
            //
            // sample:  url/?q=the+bourne+identity&type=json&yg=0
            //
            StringBuilder sb = new StringBuilder();
            StringBuilder query = new StringBuilder();
            query.Append(Constants.IMDB_API_URL);
            query.Append("?q=");
            query.Append(searchString.Replace(' ', '+'));
            if (update)
            {
                // try alternate search if previous failed
                query.Append("&type=json");
            }
            else
            {
                query.Append("&type=json&yg=0");
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(query.ToString());
            //
            // Set some reasonable limits on resources used by this request
            //
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            request.AllowAutoRedirect = true;
            //
            // Set credentials to use for this request.
            //
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //
            // Get the stream associated with the response.
            //
            Stream receiveStream = response.GetResponseStream();
            //
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            //
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            //
            // view the raw response
            //
            sb.AppendLine(readStream.ReadToEnd());
            string raw = sb.ToString();
            //
            // record this search
            //
            result.SearchString = searchString;
            if (!string.IsNullOrEmpty(raw))
            {
                result.JsonResult = raw;
            }
            else
            {
                result.JsonResult = "{}";
            }
            if (update)
            {
                __searchRepository.Write(result, Environment.UserName);
            }
            else
            {
                __searchRepository.WriteNew(result, Environment.UserName);
            }
            __log.Log("imdb search", string.Format("new clatworthy search for {0}", searchString.ToLower()), Environment.UserName);

            return raw;           
        }

        public static string GetIMDBSeriesInfoJson(string searchString)
        {
            //
            // check search cache
            //
            if (__searchRepository == null) __searchRepository = new ImdbSearchRepository();
            if (__log == null) __log = new SystemLogRepository();

            ImdbSearch result = __searchRepository.Read(searchString);
            if (result.ImdbSearchId != 0)
            {
                return result.JsonResult;
            }
            //
            // poromenos search options 11.29.2013
            //
            // Required
            // 1. name (series title)
            //
            // sample:  url/?name=the+blue+planet
            //
            StringBuilder sb = new StringBuilder();
            StringBuilder query = new StringBuilder();
            query.Append(Constants.IMDB_API_URL_SERIES);
            query.Append("?name=");
            query.Append(searchString.Replace(' ', '+'));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(query.ToString());
            //
            // Set some reasonable limits on resources used by this request
            //
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            request.AllowAutoRedirect = true;
            //
            // Set credentials to use for this request.
            //
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //
            // Get the stream associated with the response.
            //
            Stream receiveStream = response.GetResponseStream();
            //
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            //
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            //
            // view the raw response
            //
            sb.AppendLine(readStream.ReadToEnd());
            string raw = sb.ToString();
            //
            // record this search
            //
            result.SearchString = searchString;
            if (!string.IsNullOrEmpty(raw) && !raw.StartsWith("null"))
            {
                result.JsonResult = raw;
            }
            else
            {
                result.JsonResult = "{}";
            }
            __searchRepository.WriteNew(result, Environment.UserName);
            __log.Log("imdb search", string.Format("new poromenos search for {0}", searchString.ToLower()), Environment.UserName);

            return raw;
        }
    }
}
