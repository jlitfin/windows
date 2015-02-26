using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class RoutineDefinition : DatabaseObject
    {
        public string Catalog { get; set; }
        public string Schema { get; set; }
        public string Text { get; set; }
        public string RoutineType { get; set; }
        public override string ObjectId
        {
            get
            {
                return ObjectName;
            }
        }
    }
}
