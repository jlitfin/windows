using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class Repository
    {
        private const string SERVER_LIST_FILE = "servers.txt";
        public const string SERVER_LIST_DEFAULT_VALUE = "Select Server";
        public const string DATABASE_LIST_DEFAULT_VALUE = "All";

        #region cache

        private static Dictionary<string, bool> _serverList;
        private static Dictionary<string, List<ColumnDefinition>> _columnCache;
        private static Dictionary<string, List<Database>> _dbCache;
        private static Dictionary<string, List<RoutineDefinition>> _routineCache;
        private static Dictionary<string, List<TableDefinition>> _tableCache;

        #endregion

        #region properties

        public static List<string> ServerList
        {
            get
            {
                if (_serverList == null)
                {
                    _serverList = new Dictionary<string, bool>();
                    if (!File.Exists(SERVER_LIST_FILE))
                    {
                        using (var sw = new StreamWriter(SERVER_LIST_FILE))
                        {
                            sw.WriteLine(SERVER_LIST_DEFAULT_VALUE);
                        }
                    }

                    using (var sr = new StreamReader(SERVER_LIST_FILE))
                    {
                        var line = string.Empty;
                        while ((line = sr.ReadLine()) != null)
                        {
                            _serverList.Add(line, true);
                        }
                    }

                }

                return _serverList.Keys.ToList<string>();
            }
        }

        #endregion

        #region private methods

        private static void BuildColumn(SqlDataReader rdr, ColumnDefinition def)
        {
            if (ColumnExists("TABLE_CATALOG", rdr))
            {
                def.Catalog = rdr["TABLE_CATALOG"].ToString();
            }
            if (ColumnExists("TABLE_SCHEMA", rdr))
            {
                def.Schema = rdr["TABLE_SCHEMA"].ToString();
            }
            if (ColumnExists("TABLE_NAME", rdr))
            {
                def.Table = rdr["TABLE_NAME"].ToString();
            }
            if (ColumnExists("COLUMN_NAME", rdr))
            {
                def.Name = rdr["COLUMN_NAME"].ToString();
            }
            if (ColumnExists("DATA_TYPE", rdr))
            {
                def.DataType = rdr["DATA_TYPE"].ToString();
            }
        }

        private static void BuildDatabase(SqlDataReader rdr, Database db)
        {
            if (ColumnExists("database_id", rdr))
            {
                db.Id = Convert.ToInt32(rdr["database_id"].ToString());
            }

            if (ColumnExists("name",rdr))
            {
                db.Name = rdr["name"].ToString();
            }
        }

        private static void BuildRoutine(SqlDataReader rdr, RoutineDefinition def)
        {
            if (ColumnExists("ROUTINE_CATALOG", rdr))
            {
                def.Catalog = rdr["ROUTINE_CATALOG"].ToString();
            }
            if (ColumnExists("ROUTINE_SCHEMA", rdr))
            {
                def.Schema = rdr["ROUTINE_SCHEMA"].ToString();
            }
            if (ColumnExists("ROUTINE_NAME", rdr))
            {
                def.Name = rdr["ROUTINE_NAME"].ToString();
            }
            if (ColumnExists("ROUTINE_TYPE", rdr))
            {
                def.Type = rdr["ROUTINE_TYPE"].ToString();
            }
            if (ColumnExists("ROUTINE_DEFINITION", rdr))
            {
                def.Text = rdr["ROUTINE_DEFINITION"].ToString();
            }

        }

        private static void BuildTable(SqlDataReader rdr, TableDefinition def)
        {
            if (ColumnExists("TABLE_CATALOG", rdr))
            {
                def.Catalog = rdr["TABLE_CATALOG"].ToString();
            }
            if (ColumnExists("TABLE_SCHEMA", rdr))
            {
                def.Schema = rdr["TABLE_SCHEMA"].ToString();
            }
            if (ColumnExists("TABLE_NAME", rdr))
            {
                def.Name = rdr["TABLE_NAME"].ToString();
            }
            if (ColumnExists("TABLE_TYPE", rdr))
            {
                def.Type = rdr["TABLE_TYPE"].ToString();
            }
        }

        private static bool ColumnExists(string colName, SqlDataReader reader)
        {
            if (reader.FieldCount > 0 && reader.GetOrdinal(colName) >= 0)
            {
                return true;
            }
            return false;
        }

        private static void WriteServerList()
        {
            using (StreamWriter sw = new StreamWriter(SERVER_LIST_FILE, false))
            {
                foreach (var item in _serverList.Keys)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }

        #endregion

        public static void AddServer(string serverName)
        {
            if (!_serverList.ContainsKey(serverName))
            {
                _serverList.Add(serverName, true);
                WriteServerList();
            }
        }

        public static void DeleteServer(string serverName)
        {
            if (_serverList.ContainsKey(serverName))
            {
                _serverList.Remove(serverName);
                WriteServerList();
            }
        }

        public static List<ColumnDefinition> GetColumns(string server, string database)
        {
            if (_columnCache == null)
            {
                _columnCache = new Dictionary<string, List<ColumnDefinition>>();
            }

            string key = server + "." + database;
            if (_columnCache.ContainsKey(key))
            {
                return _columnCache[key];
            }

            List<ColumnDefinition> ret = new List<ColumnDefinition>();
            using (SqlConnection conn = GetSqlConnection(database, server))
            {
                SqlCommand cmd = new SqlCommand(Commands.GetColumns, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ColumnDefinition def = new ColumnDefinition();
                    BuildColumn(rdr, def);
                    ret.Add(def);
                }
            }
            _columnCache.Add(key, ret);
            return ret;
        }

        public static List<Database> GetDatabases(string serverName)
        {
            if (_dbCache == null)
            {
                _dbCache = new Dictionary<string, List<Database>>();
            }

            if (_dbCache.ContainsKey(serverName))
            {
                return _dbCache[serverName];
            }

            List<Database> dbs = new List<Database>();
            using (SqlConnection conn = GetSqlConnection("master", serverName))
            {
                SqlCommand cmd = new SqlCommand(Commands.GetDatabases, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Database db = new Database(serverName);
                    BuildDatabase(rdr, db);
                    dbs.Add(db);
                }

            }
            _dbCache.Add(serverName, dbs);
            return dbs;
        }

        public static List<RoutineDefinition> GetRoutines(string server, string database)
        {
            if (_routineCache == null)
            {
                _routineCache = new Dictionary<string, List<RoutineDefinition>>();
            }

            string key = server + "." + database;
            if (_routineCache.ContainsKey(key))
            {
                return _routineCache[key];
            }

            List<RoutineDefinition> ret = new List<RoutineDefinition>();
            using (SqlConnection conn = GetSqlConnection(database, server))
            {
                SqlCommand cmd = new SqlCommand(Commands.GetRoutines, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RoutineDefinition def = new RoutineDefinition();
                    BuildRoutine(rdr, def);
                    ret.Add(def);
                }
            }
            _routineCache.Add(key, ret);
            return ret;
        }

        public static List<TableDefinition> GetTables(string server, string database)
        {
            if (_tableCache == null)
            {
                _tableCache = new Dictionary<string, List<TableDefinition>>();
            }

            string key = server + "." + database;
            if (_tableCache.ContainsKey(key))
            {
                return _tableCache[key];
            }

            List<TableDefinition> ret = new List<TableDefinition>();
            using (SqlConnection conn = GetSqlConnection(database, server))
            {
                SqlCommand cmd = new SqlCommand(Commands.GetTables, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TableDefinition def = new TableDefinition();
                    BuildTable(rdr, def);
                    ret.Add(def);
                }

            }
            _tableCache.Add(key, ret);
            return ret;
        }

        public static SqlConnection GetSqlConnection(string db, string serverName)
        {
            string connString = string.Format("Database={0};Server={1};Integrated Security=SSPI;", db, serverName);
            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

        public static List<SearchResult> Search(Database db, string queryString)
        {
            List<SearchResult> result = new List<SearchResult>();
            if (db != null && !string.IsNullOrEmpty(queryString) && !string.IsNullOrWhiteSpace(queryString))
            {
                result = (from t in GetTables(db.Server, db.Name)
                          where t.Name.ToUpper().Contains(queryString.ToUpper())
                          select new SearchResult
                          {
                              Server = db.Server,
                              Database = db.Name,
                              QueryString = queryString,
                              ObjectName = t.Name,
                              ObjectType = t.Type

                          }).ToList();

                result.AddRange((from c in GetColumns(db.Server, db.Name)
                                where c.Name.ToUpper().Contains(queryString.ToUpper())
                                select new SearchResult
                                {
                                    Server = db.Server,
                                    Database = db.Name,
                                    QueryString = queryString,
                                    ObjectName = c.Table + "." + c.Name,
                                    ObjectType = "COLUMN"

                                }).ToList());
            }
            return result;
        }

        public static bool TestConnection(string serverName, out string message)
        {
            try
            {
                string connString = string.Format("Database=master;Server={0};Integrated Security=SSPI;", serverName);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    var cmdText = @"
                    SELECT
                        *
                    FROM
                        sys.databases                
                    ";

                    var command = new SqlCommand(cmdText, conn);
                    conn.Open();

                    var reader = command.ExecuteReader();
                    StringBuilder sb = new StringBuilder();
                    int dbCount = 0;
                    while (reader.Read())
                    {
                        if (ColumnExists("database_id", reader) && ColumnExists("name", reader))
                        {
                            dbCount++;
                        }
                    }

                    sb.AppendLine(string.Format("Connection Successful: {0} databases visible on server", dbCount));
                    message = sb.ToString();

                    return true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return false;
        }

        
    }
}
