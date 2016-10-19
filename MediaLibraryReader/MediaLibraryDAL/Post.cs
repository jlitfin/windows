using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JPL.Lib.MediaLibraryReader
{
    public class Post
    {

        #region private members

        private int __id;
        private string __author;
        private string __content;
        private string __dateString;
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


        public string DateString
        {
            get
            {
                return __dateString;
            }
            set
            {
                __dateString = value;
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

        [XmlIgnoreAttribute]
        public string WebContent 
        {
            get
            {
                if (!string.IsNullOrEmpty(__content))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<p>");
                    sb.Append(__content.Replace(Environment.NewLine, "</p><p>"));
                    sb.Append("</p>");
                    return sb.ToString();
                }

                return __content;
            }
        }

        #endregion
    }



}
