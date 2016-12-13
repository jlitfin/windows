using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using HtmlAgilityPack;

namespace ImageSearch
{
    public class WebImageSearch
    {
        private string __currentSearchString = string.Empty;

        private HtmlAgilityPack.HtmlDocument BuildSearchResultDocument(HttpWebResponse response)
        {
            if (response != null)
            {
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
                string rawPage = new StringBuilder().AppendLine(readStream.ReadToEnd()).ToString();
                //
                // create the document from the raw page
                //
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(rawPage);

                return doc;
            }

            return null;
        }

        private List<WebImageSource> GetGoogleImageSources(HtmlNode node)
        {
            StringBuilder sb = new StringBuilder();
            List<WebImageSource> lines = new List<WebImageSource>();
            string refSearch = "IMGREFURL=";
            string srcSearch = "IMGURL=";

            if (node.NodeType == HtmlNodeType.Element && node.Name.ToUpper().Equals("A"))
            {
                if (node.HasAttributes && node.Attributes.Contains("href"))
                {
                    WebImageSource imgSource = new WebImageSource();
                    string search = node.Attributes["href"].Value.ToString();
                    int sIndex = search.ToUpper().IndexOf(refSearch);
                    if (sIndex > 0)
                    {
                        sIndex += refSearch.Length;
                        int eIndex = search.ToUpper().IndexOf("&AMP", sIndex);
                        if (eIndex > sIndex)
                        {
                            imgSource.ImageRefUrl = search.Substring(sIndex, eIndex - sIndex);
                        }
                    }

                    sb = new StringBuilder();
                    sIndex = search.ToUpper().IndexOf(srcSearch);
                    if (sIndex > 0)
                    {

                        sIndex += srcSearch.Length;
                        int eIndex = search.ToUpper().IndexOf("&AMP", sIndex);
                        if (eIndex > sIndex)
                        {
                            imgSource.ImageUrl = search.Substring(sIndex, eIndex - sIndex);

                            lines.Add(imgSource);
                        }
                    }


                }
            }

            foreach (HtmlNode n in node.ChildNodes)
            {
                lines.AddRange(GetGoogleImageSources(n));
            }

            return lines;
        }

        private HttpWebResponse SearchGoogleImages(List<string> searchTerms)
        {
            return SearchGoogleImages(searchTerms, 0);
        }

        private HttpWebResponse SearchGoogleImages(List<string> searchTerms, int startValue)
        {
            //
            // build our search URL with query terms
            //
            StringBuilder query = new StringBuilder();
            query.Append(Constants.GOOGLE_IMAGE_SEARCH_BASE);

            bool firstTerm = true;
            foreach (string str in searchTerms)
            {
                if (firstTerm)
                {
                    query.Append(str);
                    firstTerm = false;
                }
                else
                {
                    query.Append("+");
                    query.Append(str);
                }
            }
            //
            // capture current search string in case Next() functionality is used
            //
            __currentSearchString = query.ToString();

            if (startValue > 0)
            {
                query.Append("&start=");
                query.Append(startValue.ToString());
            }

            //
            // try to make the request
            //
            try
            {
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

                return response;
            }
            catch
            {
                return null;
            }

        }

        public List<WebImageSource> Search(List<string> searchTerms)
        {
            return Search(searchTerms, 0);
        }

        public List<WebImageSource> Search(List<string> searchTerms, int startValue)
        {
            HtmlAgilityPack.HtmlDocument doc = BuildSearchResultDocument(SearchGoogleImages(searchTerms, startValue));
            List<WebImageSource> list = new List<WebImageSource>();
            if (doc != null)
            {
                list.AddRange(GetGoogleImageSources(doc.DocumentNode));
            }

            return list;
        }
    }
}
