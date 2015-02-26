using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class CompareResult
    {
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public string ObjectId { get; set; }
        public string ObjectServer { get; set; }
        public string ObjectDatabase { get; set; }
        public string CompareStatus { get; set; }
        public string CompareObjectName { get; set; }
        public string CompareObjectType { get; set; }
        public string CompareObjectId { get; set; }
        public string CompareServer { get; set; }
        public string CompareDatabase { get; set; }
        public string ComparisonType { get; set; }
    }
}
