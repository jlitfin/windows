using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class KindType
    {

        #region private members

        private int __kindTypeId;
        private string __kindTypeMap;
        private string __kindTypeText;
        private DateTime __updatedDate;

        #endregion

        #region public accessors

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


        public string KindTypeMap
        {
            get
            {
                return __kindTypeMap;
            }
            set
            {
                __kindTypeMap = value;
            }
        }


        public string KindTypeText
        {
            get
            {
                return __kindTypeText;
            }
            set
            {
                __kindTypeText = value;
            }
        }


        public DateTime UpdatedDate
        {
            get
            {
                return __updatedDate;
            }
            set
            {
                __updatedDate = value;
            }
        }



        #endregion
    }

}
