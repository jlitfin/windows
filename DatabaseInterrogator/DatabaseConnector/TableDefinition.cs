using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class TableDefinition : DatabaseObject, IComparable
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

        int IComparable.CompareTo(object def)
        {
            TableDefinition d = def as TableDefinition;
            if (d != null)
            {
                return string.Compare(this.ObjectName, d.ObjectName);
            }
            else
            {
                throw new ArgumentException("Not a valid TableDefinition");
            }
        }
    }
}
