using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.WebContent
{
    public class SkipWord
    {

        #region private members

        private int __id;
        private string __skipWord;

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


        public string Value
        {
            get
            {
                return __skipWord;
            }
            set
            {
                __skipWord = value;
            }
        }



        #endregion
    }

}
