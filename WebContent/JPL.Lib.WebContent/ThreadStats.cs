using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPL.Lib.WebContent
{
    public class ThreadStats
    {
        public int ThreadId { get; set; }
        public int ThreadIndex { get; set; }
        public int PostId { get; set; }
        public DateTime PostDate { get; set; }
        public string PostTitle { get; set; }
        public string PostAuthor { get; set; }

    }
}
