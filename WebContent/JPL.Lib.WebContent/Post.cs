using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JPL.Lib.WebContent
{
    public class Post
    {

        #region private members

        private int __id;
        private string __author;
        private string __content;
        private DateTime __postDate;
        private int __threadId;
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


        public string Author
        {
            get
            {
                return __author;
            }
            set
            {
                __author = value;
            }
        }

        [XmlIgnoreAttribute]
        public string Caption
        {
            get
            {
                if (Content.Length > 120)
                {
                    return Content.Substring(0, 119) + "...";
                }
                else
                {
                    return Content;
                }
            }
        }


        public string Content
        {
            get
            {
                return __content;
            }
            set
            {
                __content = value;
            }
        }


        public DateTime PostDate
        {
            get
            {
                return __postDate;
            }
            set
            {
                __postDate = value;
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
