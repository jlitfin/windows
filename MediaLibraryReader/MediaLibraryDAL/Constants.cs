using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class Constants
    {
        public const string AUDIO_TYPE = "audio";
        public const string VIDEO_TYPE = "video";

        public const string IMDB_API_URL = @"http://deanclatworthy.com/imdb/";
        public const string IMDB_API_URL_SERIES = @"http://imdbapi.poromenos.org/json/";

        public static readonly DateTime NULL_DATE = new DateTime(1900, 1, 1);

        public const string UNKNOWN_VALUE = "Unknown Value";
        public const string UNMAPPED_VALUE = "Unmapped";
    }
}
