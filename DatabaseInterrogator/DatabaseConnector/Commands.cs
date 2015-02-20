using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class Commands
    {
        public static readonly string GetColumns = @"SELECT * FROM INFORMATION_SCHEMA.COLUMNS";
        public static readonly string GetDatabases = @"SELECT * FROM sys.databases";
        public static readonly string GetRoutines = @"SELECT * FROM INFORMATION_SCHEMA.ROUTINES";
        public static readonly string GetTables = @"SELECT * FROM INFORMATION_SCHEMA.TABLES";
    }
}
