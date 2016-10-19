using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


namespace ImageSearch
{
    public class WebImageSource
    {

        private string __key;
        private string __imageUrl;
        private Image __imageOriginal;

        public WebImageSource()
        {
            __key = Guid.NewGuid().ToString();
        }

        public string ImageRefUrl { get; set; }

        public string ImageUrl
        {
            get
            {
                return __imageUrl;
            }
            set
            {
                __imageUrl = value;
                CleanUrlToSuffix();
            }
        }

        public string Key
        {
            get
            {
                return __key;
            }
        }

        public Image OriginalImage
        {
            get
            {
                if (__imageOriginal == null)
                {
                    RequestImage();
                }

                return __imageOriginal;
            }
        }

        public int OriginalImageHeight
        {
            get
            {
                return OriginalImage.Height;
            }
        }

        public int OriginalImageWidth
        {
            get
            {
                return OriginalImage.Width;
            }
        }

        public Image GetImage(int width, int height)
        {
            if (__imageOriginal == null)
            {
                RequestImage();
            }

            Bitmap bmp = new Bitmap(__imageOriginal, new Size(width, height));
            return bmp;
        }

        private void RequestImage()
        {
            if (__imageUrl != null && __imageUrl.Length > 0)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(__imageUrl);

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

                    __imageOriginal = Image.FromStream(receiveStream);
                }
                catch
                {
                    //
                    // set default image in the case the url is not valid
                    //
                    Stream s = this.GetType().Assembly.GetManifestResourceStream("ImageSearch.no_resource.jpg");
                    __imageOriginal = Image.FromStream(s);
                }
            }
        }

        private void CleanUrlToSuffix()
        {

            if (__imageUrl != null && __imageUrl.Length > 0)
            {
                int index = __imageUrl.IndexOf(ImageFileSuffix.Jpeg);
                if (index > 0)
                {
                    if (index + ImageFileSuffix.Jpeg.Length < __imageUrl.Length)
                    {
                        __imageUrl = __imageUrl.Substring(0, index + ImageFileSuffix.Jpeg.Length);
                    }

                    return;
                }


                index = __imageUrl.IndexOf(ImageFileSuffix.Jpg);
                if (index > 0)
                {
                    if (index + ImageFileSuffix.Jpg.Length < __imageUrl.Length)
                    {
                        __imageUrl = __imageUrl.Substring(0, index + ImageFileSuffix.Jpg.Length);
                    }

                    return;
                }


            }
        }

        public struct ImageFileSuffix
        {
            public static string Jpeg = ".jpeg";
            public static string Jpg = ".jpg";
            public static string Png = ".png";
            public static string Bmp = ".bmp";
        }
    }
}
