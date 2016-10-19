using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JPL.Lib.WebContent
{
    public class Thread
    {

        #region private members

        private int __id;
        private string __title;
        private List<ThreadStats> __stats;

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

        public List<int> PostGroups
        {
            get
            {
                List<int> grps = new List<int>();
                int group_max = 0;
                int group_top = Constants.POST_GROUP_COUNT;
                for (int i = 0; i < Statistics.Count; ++i)
                {
                    group_max = i + 1;
                    if (group_max == group_top)
                    {
                        grps.Add(group_top);
                        group_top += Constants.POST_GROUP_COUNT;
                    }
                }
                if (group_max != Statistics.Count)
                {
                    grps.Add(group_max);
                }

                return grps;
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
        public List<ThreadStats> Statistics
        {
            get
            {
                if (__stats == null)
                {
                    __stats = new List<ThreadStats>();
                }

                return __stats;
            }
            set
            {
                __stats = value;
            }
        }

        #endregion

        #region public methods

        #endregion
    }

}
