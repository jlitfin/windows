using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class SearchResult
    {
        public string ObjectType { get; set; }
        public string ObjectName { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
        public string QueryString { get; set; }
    }
}
