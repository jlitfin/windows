using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.WebContent
{
    public class KeyWord
    {

        #region private members

        private string __word;

        #endregion

        #region public accessors

        public string Word
        {
            get
            {
                return __word;
            }
            set
            {
                __word = value;
            }
        }



        #endregion
    }

}
