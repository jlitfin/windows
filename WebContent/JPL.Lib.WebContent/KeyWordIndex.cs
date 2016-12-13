using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.WebContent
{
    public class KeyWordIndex
    {

        #region private members

        private int __id;
        private string __keyWord;
        private int __postId;
        private int __count;

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


        public string KeyWord
        {
            get
            {
                return __keyWord;
            }
            set
            {
                __keyWord = value;
            }
        }


        public int PostId
        {
            get
            {
                return __postId;
            }
            set
            {
                __postId = value;
            }
        }


        public int Count
        {
            get
            {
                return __count;
            }
            set
            {
                __count = value;
            }
        }



        #endregion
    }


}
