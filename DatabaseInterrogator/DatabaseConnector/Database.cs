using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class Database
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
        public List<TableDefinition> Tables { get; set; }
        public List<ColumnDefinition> Columns { get; set; }
        public List<RoutineDefinition> Routines { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
