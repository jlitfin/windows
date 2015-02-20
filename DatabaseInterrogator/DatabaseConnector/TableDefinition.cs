using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class TableDefinition
    {
        public string Catalog { get; set; }
        public string Schema { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Key
        {
            get
            {
                return Catalog + Schema + Name;
            }
        }

        public List<ColumnDefinition> Columns { get; set; }
    }
}
