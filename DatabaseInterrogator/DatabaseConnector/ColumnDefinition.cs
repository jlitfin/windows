using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class ColumnDefinition : DatabaseObject
    {
        public string Catalog { get; set; }
        public string Schema { get; set; }
        public string Table { get; set; }
        public string DataType { get; set; }

        public override string ObjectId
        {
            get
            {
                return Table + "." + ObjectName;
            }
        }
    }
}
