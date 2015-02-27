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
        public static readonly string GetRoutines = @"
            SELECT 
	            ROUTINE_CATALOG,
	            ROUTINE_SCHEMA,
                ROUTINE_NAME, 
                ROUTINE_TYPE, 
                OBJECT_DEFINITION(object_id(ROUTINE_NAME)) as ROUTINE_DEFINITION
            FROM 
                INFORMATION_SCHEMA.ROUTINES
            ORDER BY 
                ROUTINE_NAME";
        public static readonly string GetTables = @"SELECT * FROM INFORMATION_SCHEMA.TABLES";
    }
}
