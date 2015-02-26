using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class ColumnDefinition : DatabaseObject, IComparable
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

        int IComparable.CompareTo(object def)
        {
            ColumnDefinition d = def as ColumnDefinition;
            if (d != null)
            {
                return string.Compare(this.ObjectName, d.ObjectName);
            }
            else
            {
                throw new ArgumentException("Not a valid ColumnDefinition.");
            }
            
        }
    }
}
