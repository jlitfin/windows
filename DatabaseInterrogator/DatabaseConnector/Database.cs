using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class Database : IComparable
    {
        public Database()
        {
        }

        public Database(string serverName)
        {
            Server = serverName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }

        public override string ToString()
        {
            return Name;
        }

        int IComparable.CompareTo(object obj)
        {
            Database d = obj as Database;
            if (d != null)
            {
                return string.Compare(this.Name, d.Name);
            }
            else
            {
                throw new ArgumentException("Not a valid database object");
            }
        }
    }
}
