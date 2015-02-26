using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class TableDefinition : DatabaseObject
    {
        public string Catalog { get; set; }
        public string Schema { get; set; }

        public override string ObjectId
        {
            get
            {
                return ObjectServer + "." + ObjectName;
            }
        }

        public List<ColumnDefinition> Columns { get; set; }
    }
}
