using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class Artist
    {

        #region private members

        private int __artistId;
        private string __baseName;
        private string __name;

        #endregion

        #region public accessors

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


        public string BaseName
        {
            get
            {
                if (__baseName == null || __baseName == string.Empty)
                {
                    return __name;
                }

                return __baseName;
            }
            set
            {
                __baseName = value;
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



        #endregion
    }

}
