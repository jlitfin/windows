using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class AlbumTrack
    {

        #region private members

        private int __albumTrackId;
        private int __albumId;
        private int __artistId;
        private int __genreId;
        private int __itunesTrackId;
        private int __kindTypeId;
        private bool __manualUpdate;
        private string __name;
        private string __persistentId;
        private string __totalTimeString;
        private int __trackNumber;

        #endregion

        #region public accessors

        public int AlbumTrackId
        {
            get
            {
                return __albumTrackId;
            }
            set
            {
                __albumTrackId = value;
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


        public int ArtistId
        {
            get
            {
                return __artistId;
            }
            set
            {
                __artistId = value;
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


        public bool ManualUpdate
        {
            get
            {
                return __manualUpdate;
            }
            set
            {
                __manualUpdate = value;
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


        public string PersistentId
        {
            get
            {
                return __persistentId;
            }
            set
            {
                __persistentId = value;
            }
        }


        public string TotalTimeString
        {
            get
            {
                if (string.IsNullOrEmpty(__totalTimeString))
                {
                    return "00:00";
                }
                return __totalTimeString;
            }
            set
            {
                __totalTimeString = value;
            }
        }


        public int TrackNumber
        {
            get
            {
                return __trackNumber;
            }
            set
            {
                __trackNumber = value;
            }
        }


        #endregion
    }


}
