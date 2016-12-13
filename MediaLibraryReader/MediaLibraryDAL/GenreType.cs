using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class GenreType
    {

        #region private members

        private int __genreTypeId;
        private string __genreTypeMap;
        private string __genreTypeText;

        #endregion

        #region public accessors

        public int GenreTypeId
        {
            get
            {
                return __genreTypeId;
            }
            set
            {
                __genreTypeId = value;
            }
        }

        public string GenreTypeMap
        {
            get
            {
                if (__genreTypeMap == null || __genreTypeMap == string.Empty)
                {
                    return Constants.UNMAPPED_VALUE;
                }

                return __genreTypeMap;
            }
            set
            {
                __genreTypeMap = value;
            }
        }

        public string GenreTypeText
        {
            get
            {
                return __genreTypeText;
            }
            set
            {
                __genreTypeText = value;
            }
        }

        #endregion
    }

}
