using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class Thread
    {

        #region private members

        private int __id;
        private string __title;

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


        public string Title
        {
            get
            {
                return __title;
            }
            set
            {
                __title = value;
            }
        }



        #endregion
    }

}
