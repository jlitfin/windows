using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class RoutineDefinition : DatabaseObject, IComparable
    {
        public string Catalog { get; set; }
        public string Schema { get; set; }
        public string Text { get; set; }
        public string RoutineType { get; set; }

        int IComparable.CompareTo(object def)
        {
            RoutineDefinition d = def as RoutineDefinition;
            if (d != null)
            {
                return string.Compare(this.ObjectName, d.ObjectName);
            }
            else
            {
                throw new ArgumentException("Not a valid RoutineDefinition");
            }
        }
    }
}
