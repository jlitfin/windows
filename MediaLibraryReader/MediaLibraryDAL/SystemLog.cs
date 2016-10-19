using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class SystemLog
    {

        #region private members

        private string __activity;
        private string __description;
        private int __id;
        private string __updatedBy;
        private DateTime __updatedDate;

        #endregion

        #region public accessors

        public string Activity
        {
            get
            {
                return __activity;
            }
            set
            {
                __activity = value;
            }
        }


        public string Description
        {
            get
            {
                return __description;
            }
            set
            {
                __description = value;
            }
        }


        public int Id
        {
            get
            {
                return __id;
            }
            set
            {
                __id = value;
            }
        }


        public string UpdatedBy
        {
            get
            {
                return __updatedBy;
            }
            set
            {
                __updatedBy = value;
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
