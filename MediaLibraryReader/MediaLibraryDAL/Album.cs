using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class Album
    {

        #region private members

        private int __albumId;
        private string __imdb_id;
        private bool __manualUpdate;
        private string __name;
        private int __year;

        #endregion

        #region public accessors

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

        public string ImdbId
        {
            get
            {
                return __imdb_id;
            }
            set
            {
                __imdb_id = value;
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


        public int Year
        {
            get
            {
                return __year;
            }
            set
            {
                __year = value;
            }
        }



        #endregion
    }




}
