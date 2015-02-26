using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class DatabaseObject
    {
        public string ObjectServer { get; set; }
        public string ObjectDatabase { get; set; }
        public string ObjectName { get; set; }
        public virtual string ObjectId
        {
            get
            {
                return ObjectKey + "." + ObjectName;
            }
        }
        public string ObjectKey
        {
            get
            {
                return ObjectServer + "." + ObjectDatabase;
            }
        }
        public string ObjectType { get; set; }
    }
}
