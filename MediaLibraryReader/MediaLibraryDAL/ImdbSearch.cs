using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class ImdbSearch
    {

        #region private members

        private int __imdbSearchId;
        private string __jsonResult;
        private string __searchString;

        #endregion

        #region public accessors

        public int ImdbSearchId
        {
            get
            {
                return __imdbSearchId;
            }
            set
            {
                __imdbSearchId = value;
            }
        }


        public string JsonResult
        {
            get
            {
                return __jsonResult;
            }
            set
            {
                __jsonResult = value;
            }
        }


        public string SearchString
        {
            get
            {
                return __searchString;
            }
            set
            {
                __searchString = value;
            }
        }


        #endregion
    }

}
