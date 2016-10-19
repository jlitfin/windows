using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class ThreadUserMap
    {

        #region private members

        private int __id;
        private int __threadId;
        private string __userName;

        #endregion

        #region public accessors

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


        public int ThreadId
        {
            get
            {
                return __threadId;
            }
            set
            {
                __threadId = value;
            }
        }


        public string UserName
        {
            get
            {
                return __userName;
            }
            set
            {
                __userName = value;
            }
        }



        #endregion
    }


}
