using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class Video
    {

        #region private members

        private int __videoId;
        private int __directorId;
        private int __albumId;
        private int __genreId;
        private int __itunesTrackId;
        private int __kindTypeId;
        private string __name;
        private string __totalTimeString;

        #endregion

        #region public accessors

        public int VideoId
        {
            get
            {
                return __videoId;
            }
            set
            {
                __videoId = value;
            }
        }

        public int DirectorId
        {
            get
            {
                return __directorId;
            }
            set
            {
                __directorId = value;
            }
        }

        public int AlbumId
        {
            get
            {
                return __albumId;
            }
            set
            {
                __albumId = value;
            }
        }

        public int GenreId
        {
            get
            {
                return __genreId;
            }
            set
            {
                __genreId = value;
            }
        }

        public int ItunesTrackId
        {
            get
            {
                return __itunesTrackId;
            }
            set
            {
                __itunesTrackId = value;
            }
        }

        public int KindTypeId
        {
            get
            {
                return __kindTypeId;
            }
            set
            {
                __kindTypeId = value;
            }
        }

        public string Name
        {
            get
            {
                return __name;
            }
            set
            {
                __name = value;
            }
        }

        public string TotalTimeString
        {
            get
            {
                return __totalTimeString;
            }
            set
            {
                __totalTimeString = value;
            }
        }



        #endregion
    }

}
