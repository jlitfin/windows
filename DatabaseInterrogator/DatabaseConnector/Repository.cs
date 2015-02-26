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
        public const string SERVER_LIST_DEFAULT_VALUE = "[Select Server]";
        public const string DATABASE_LIST_DEFAULT_VALUE = "All";

        #region cache

        private static Dictionary<string, bool> _serverList;
        //
        // column cache
        // keyed by server.database
        //
        private static Dictionary<string, List<ColumnDefinition>> _columnCache;
        //
        // db cache 
        // keyed by server
        //
        private static Dictionary<string, List<Database>> _dbCache;
        //
        // routine cache
        // keyed by server.database
        //
        private static Dictionary<string, List<RoutineDefinition>> _routineCache;
        //
        // table cache
        // keyed by server.database
        //
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

                return _serverList.Keys.OrderBy(s => s).ToList<string>();
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
                def.ObjectName = rdr["COLUMN_NAME"].ToString();
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
                def.ObjectName = rdr["ROUTINE_NAME"].ToString();
            }
            if (ColumnExists("ROUTINE_TYPE", rdr))
            {
                def.RoutineType = rdr["ROUTINE_TYPE"].ToString();
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
                def.ObjectName = rdr["TABLE_NAME"].ToString();
            }
        }

        private static List<CompareResult> EvaluateColumnDiffs(CompareRequest request, List<ColumnDefinition> primary, List<ColumnDefinition> secondary)
        {
            if (primary.Count != secondary.Count) throw new ArgumentException(string.Format("Column list mismatch"));

            List<CompareResult> list = new List<CompareResult>();
            for (int i = 0; i < primary.Count; ++i)
            {
                if (primary[i] == null)
                {
                    CompareResult r = new CompareResult
                    {
                        ComparisonType = "COLUMN",
                        ObjectName = string.Empty,
                        ObjectType = string.Empty,
                        ObjectId = string.Empty,
                        ObjectDatabase = request.PrimaryDatabase,
                        ObjectServer = request.PrimaryServer,
                        CompareStatus = "MISSING",
                        CompareObjectName = secondary[i].ObjectName,
                        CompareObjectType = secondary[i].DataType,
                        CompareObjectId = secondary[i].ObjectId,
                        CompareDatabase = secondary[i].ObjectDatabase,
                        CompareServer = secondary[i].ObjectServer
                    };
                    list.Add(r);
                }
                else if (secondary[i] == null)
                {
                    CompareResult r = new CompareResult
                    {
                        ComparisonType = "COLUMN",
                        ObjectName = primary[i].ObjectName,
                        ObjectType = primary[i].DataType,
                        ObjectId = primary[i].ObjectId,
                        ObjectDatabase = primary[i].ObjectDatabase,
                        ObjectServer = primary[i].ObjectServer,
                        CompareStatus = "MISSING",
                        CompareObjectName = string.Empty,
                        CompareObjectType = string.Empty,
                        CompareObjectId = string.Empty,
                        CompareDatabase = request.SecondaryDatabase,
                        CompareServer = request.SecondaryServer
                    };
                    list.Add(r);
                }
                else
                {
                    if (!primary[i].DataType.Equals(secondary[i].DataType))
                    {
                        CompareResult r = new CompareResult
                        {
                            ComparisonType = "COLUMN",
                            ObjectName = primary[i].ObjectName,
                            ObjectType = primary[i].DataType,
                            ObjectId = primary[i].ObjectId,
                            ObjectDatabase = primary[i].ObjectDatabase,
                            ObjectServer = primary[i].ObjectServer,
                            CompareStatus = "DIFF",
                            CompareObjectName = secondary[i].ObjectName,
                            CompareObjectType = secondary[i].DataType,
                            CompareObjectId = secondary[i].ObjectId,
                            CompareDatabase = secondary[i].ObjectDatabase,
                            CompareServer = secondary[i].ObjectServer
                        };
                        list.Add(r);
                    }
                }
            }
            return list;
        }

        private static List<CompareResult> CompareColumns(CompareRequest request, TableDefinition primary, TableDefinition secondary)
        {
            List<ColumnDefinition> pt = (from c in GetColumns(request.PrimaryServer, request.PrimaryDatabase)
                                           where c.Table == primary.ObjectName
                                           select c).ToList<ColumnDefinition>();

            List<ColumnDefinition> st = (from c in GetColumns(request.SecondaryServer, request.SecondaryDatabase)
                                            where c.Table == secondary.ObjectName
                                            select c).ToList<ColumnDefinition>();

            pt.Sort();
            st.Sort();
            int i = 0;
            while (true)
            {
                if (i < pt.Count && i < st.Count)
                {
                    int c = string.Compare(pt[i].ObjectName, st[i].ObjectName);
                    if (c > 0)
                    {
                        pt.Insert(i, null);
                    }
                    else if (c < 0)
                    {
                        st.Insert(i, null);
                    }
                }
                else if (i >= pt.Count && i < st.Count)
                {
                    pt.Add(null);
                }
                else if (i < pt.Count && i >= st.Count)
                {
                    st.Add(null);
                }
                else
                {
                    break;
                }
                ++i;
            }

            return EvaluateColumnDiffs(request, pt, st);
        }

        private static List<CompareResult> EvaluateTableDiffs(CompareRequest request, List<TableDefinition> primary, List<TableDefinition> secondary)
        {
            if (primary.Count != secondary.Count) throw new ArgumentException("Table list mismatch");

            List<CompareResult> list = new List<CompareResult>();
            for (int i = 0; i < primary.Count; ++i)
            {
                if (primary[i] == null)
                {
                    CompareResult r = new CompareResult
                    {
                        ComparisonType = "TABLE",
                        ObjectName = string.Empty,
                        ObjectType = string.Empty,
                        ObjectId = string.Empty,
                        ObjectDatabase = request.PrimaryDatabase,
                        ObjectServer = request.PrimaryServer,
                        CompareStatus = "MISSING",
                        CompareObjectName = secondary[i].ObjectName,
                        CompareObjectType = secondary[i].ObjectType,
                        CompareObjectId = secondary[i].ObjectId,
                        CompareDatabase = secondary[i].ObjectDatabase,
                        CompareServer = secondary[i].ObjectServer
                    };
                    list.Add(r);
                }
                else if (secondary[i] == null)
                {
                    CompareResult r = new CompareResult
                    {
                        ComparisonType = "TABLE",
                        ObjectName = primary[i].ObjectName,
                        ObjectType = primary[i].ObjectType,
                        ObjectId = primary[i].ObjectId,
                        ObjectDatabase = primary[i].ObjectDatabase,
                        ObjectServer = primary[i].ObjectServer,
                        CompareStatus = "MISSING",
                        CompareObjectName = string.Empty,
                        CompareObjectType = string.Empty,
                        CompareObjectId = string.Empty,
                        CompareDatabase = request.SecondaryDatabase,
                        CompareServer = request.SecondaryServer
                    };
                    list.Add(r);
                }
                else
                {
                    list.AddRange(CompareColumns(request, primary[i], secondary[i]));
                }
            }

            return list;
        }

        private static List<CompareResult> CompareTables(CompareRequest request, Database primary, Database secondary)
        {
            List<CompareResult> list = new List<CompareResult>();
            var pt = GetTables(primary.Server, primary.Name);
            var st = GetTables(secondary.Server, secondary.Name);
            pt.Sort();
            st.Sort();

            int i = 0;
            while (true)
            {
                if (i < pt.Count && i < st.Count)
                {
                    int c = string.Compare(pt[i].ObjectName, st[i].ObjectName);
                    if (c > 0)
                    {
                        pt.Insert(i, null);
                    }
                    else if (c < 0)
                    {
                        st.Insert(i, null);
                    }
                }
                else if (i >= pt.Count && i < st.Count)
                {
                    pt.Add(null);
                }
                else if (i < pt.Count && i >= st.Count)
                {
                    st.Add(null);
                }
                else
                {
                    break;
                }
                ++i;
            }

            return EvaluateTableDiffs(request, pt, st);
        }

        private static List<CompareResult> EvaluateRoutineDiffs(CompareRequest request, List<RoutineDefinition> primary, List<RoutineDefinition> secondary, bool deep)
        {
            List<CompareResult> list = new List<CompareResult>();
            for (int i = 0; i < primary.Count; ++i)
            {
                if (primary[i] == null)
                {
                    CompareResult r = new CompareResult
                    {
                        ComparisonType = "ROUTINE",
                        ObjectName = string.Empty,
                        ObjectType = string.Empty,
                        ObjectId = string.Empty,
                        ObjectDatabase = request.PrimaryDatabase,
                        ObjectServer = request.PrimaryServer,
                        CompareStatus = "MISSING",
                        CompareObjectName = secondary[i].ObjectName,
                        CompareObjectType = secondary[i].ObjectType,
                        CompareObjectId = secondary[i].ObjectId,
                        CompareDatabase = secondary[i].ObjectDatabase,
                        CompareServer = secondary[i].ObjectServer
                    };
                    list.Add(r);
                }
                else if (secondary[i] == null)
                {
                    CompareResult r = new CompareResult
                    {
                        ComparisonType = "ROUTINE",
                        ObjectName = primary[i].ObjectName,
                        ObjectType = primary[i].ObjectType,
                        ObjectId = primary[i].ObjectId,
                        ObjectDatabase = primary[i].ObjectDatabase,
                        ObjectServer = primary[i].ObjectServer,
                        CompareStatus = "MISSING",
                        CompareObjectName = string.Empty,
                        CompareObjectType = string.Empty,
                        CompareObjectId = string.Empty,
                        CompareDatabase = request.SecondaryDatabase,
                        CompareServer = request.SecondaryServer
                    };
                    list.Add(r);
                }
                else if (deep && !primary[i].Text.Equals(secondary[i].Text))
                {
                    CompareResult r = new CompareResult
                    {
                        ComparisonType = "ROUTINE TEXT",
                        ObjectName = primary[i].ObjectName,
                        ObjectType = primary[i].ObjectType,
                        ObjectId = primary[i].ObjectId,
                        ObjectDatabase = primary[i].ObjectDatabase,
                        ObjectServer = primary[i].ObjectServer,
                        CompareStatus = "DIFF",
                        CompareObjectName = secondary[i].ObjectName,
                        CompareObjectType = secondary[i].ObjectType,
                        CompareObjectId = secondary[i].ObjectId,
                        CompareDatabase = request.SecondaryDatabase,
                        CompareServer = request.SecondaryServer
                    };
                    list.Add(r);
                }
            }

            return list;
        }

        private static List<CompareResult> CompareRoutines(CompareRequest request, Database primary, Database secondary, bool deep)
        {
            List<CompareResult> list = new List<CompareResult>();
            var pr = GetRoutines(primary.Server, primary.Name);
            var sr = GetRoutines(secondary.Server, secondary.Name);
            pr.Sort();
            sr.Sort();
            int i = 0;
            while (true)
            {
                if (i < pr.Count && i < sr.Count)
                {
                    int c = string.Compare(pr[i].ObjectName, sr[i].ObjectName);
                    if (c > 0)
                    {
                        pr.Insert(i, null);
                    }
                    else if (c < 0)
                    {
                        sr.Insert(i, null);
                    }
                }
                else if (i >= pr.Count && i < sr.Count)
                {
                    pr.Add(null);
                }
                else if (i < pr.Count && i >= sr.Count)
                {
                    sr.Add(null);
                }
                else
                {
                    break;
                }
                ++i;
            }

            return EvaluateRoutineDiffs(request, pr, sr, deep);
        }

        private static Database GetDatabase(string server, string database)
        {
            List<Database> list = GetDatabases(server);
            foreach (var db in list)
            {
                if (db.Name.Equals(database))
                {
                    return db;
                }
            }

            return null;
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

        #region public methods

        public static void AddServer(string serverName)
        {
            serverName = serverName.ToUpper();
            if (!_serverList.ContainsKey(serverName))
            {
                _serverList.Add(serverName, true);
                WriteServerList();
            }
        }

        public static void DeleteServer(string serverName)
        {
            serverName = serverName.ToUpper();
            if (_serverList.ContainsKey(serverName))
            {
                _serverList.Remove(serverName);
                WriteServerList();
            }
        }

        public static List<CompareResult> Compare(string primaryServer, string secondaryServer, string primaryDb, string secondaryDb, bool deep = false)
        {
            List<CompareResult> list = new List<CompareResult>();
            var primary = GetDatabase(primaryServer, primaryDb);
            var secondary = GetDatabase(secondaryServer, secondaryDb);
            if (primary != null && secondary != null)
            {
                CompareRequest r = new CompareRequest
                {
                    PrimaryServer = primaryServer,
                    PrimaryDatabase = primaryDb,
                    SecondaryServer = secondaryServer,
                    SecondaryDatabase = secondaryDb
                };

                list = CompareTables(r, primary, secondary);
                list.AddRange(CompareRoutines(r, primary, secondary, deep));
            }
            else
            {
                CompareResult error = new CompareResult
                {
                    ComparisonType = "DATABASE",
                    ObjectName = primaryDb,
                    ObjectType = "DATABASE",
                    ObjectId = primaryDb,
                    ObjectServer = primaryServer,
                    ObjectDatabase = primaryDb,
                    CompareStatus = secondary == null ? "MISSING" : "Error querying primary server.",
                    CompareObjectName = primaryDb,
                    CompareObjectType = "DATABASE",
                    CompareObjectId = primaryDb,
                    CompareServer = secondaryServer,
                    CompareDatabase = secondaryDb
                };
                list.Add(error);
            }
            
            return list;
        }

        public static List<ColumnDefinition> GetColumns(string server, string database)
        {
            List<ColumnDefinition> c = new List<ColumnDefinition>();
            if (_columnCache == null)
            {
                _columnCache = new Dictionary<string, List<ColumnDefinition>>();
            }

            string key = server + "." + database;
            if (_columnCache.ContainsKey(key))
            {
                c.AddRange(_columnCache[key]);
                return c;
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
                    def.ObjectServer = server;
                    def.ObjectDatabase = database;
                    def.ObjectType = "COLUMN";
                    ret.Add(def);
                }
            }
            _columnCache.Add(key, ret);
            c.AddRange(ret);
            return c;
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
            List<RoutineDefinition> c = new List<RoutineDefinition>();
            if (_routineCache == null)
            {
                _routineCache = new Dictionary<string, List<RoutineDefinition>>();
            }

            string key = server + "." + database;
            if (_routineCache.ContainsKey(key))
            {
                c.AddRange(_routineCache[key]);
                return c;
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
                    def.ObjectServer = server;
                    def.ObjectDatabase = database;
                    def.ObjectType = "ROUTINE";
                    ret.Add(def);
                }
            }
            _routineCache.Add(key, ret);
            c.AddRange(ret);
            return c;
        }

        public static List<TableDefinition> GetTables(string server, string database)
        {
            List<TableDefinition> c = new List<TableDefinition>();
            if (_tableCache == null)
            {
                _tableCache = new Dictionary<string, List<TableDefinition>>();
            }

            string key = server + "." + database;
            if (_tableCache.ContainsKey(key))
            {
                c.AddRange(_tableCache[key]);
                return c;
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
                    def.ObjectServer = server;
                    def.ObjectDatabase = database;
                    def.ObjectType = "TABLE";
                    ret.Add(def);
                }

            }
            _tableCache.Add(key, ret);
            c.AddRange(ret);
            return c;
        }

        public static SqlConnection GetSqlConnection(string db, string serverName)
        {
            string connString = string.Format("Database={0};Server={1};Integrated Security=SSPI;", db, serverName);
            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

        public static List<SearchResult> Search(Database db, string queryString, bool deep)
        {
            List<SearchResult> result = new List<SearchResult>();
            if (db != null && !string.IsNullOrEmpty(queryString) && !string.IsNullOrWhiteSpace(queryString))
            {
                result = (from t in GetTables(db.Server, db.Name)
                          where t.ObjectName.ToUpper().Contains(queryString.ToUpper())
                          select new SearchResult
                          {
                              Server = db.Server,
                              Database = db.Name,
                              QueryString = queryString,
                              ObjectName = t.ObjectName,
                              ObjectSearchable = t.ObjectName,
                              ObjectType = "TABLE",
                              SearchableType = "NAME"

                          }).ToList();

                result.AddRange((from c in GetColumns(db.Server, db.Name)
                                where c.ObjectName.ToUpper().Contains(queryString.ToUpper())
                                select new SearchResult
                                {
                                    Server = db.Server,
                                    Database = db.Name,
                                    QueryString = queryString,
                                    ObjectName = c.ObjectName,
                                    ObjectSearchable = c.Table + "." + c.ObjectName,
                                    ObjectType = "COLUMN",
                                    SearchableType = "NAME"

                                }).ToList());

                var names = from r in GetRoutines(db.Server, db.Name)
                            where r.ObjectName.ToUpper().Contains(queryString.ToUpper())
                            select new SearchResult
                            {
                                Server = db.Server,
                                Database = db.Name,
                                QueryString = queryString,
                                ObjectName = r.ObjectName,
                                ObjectSearchable = r.ObjectName,
                                ObjectType = "ZPROC",
                                SearchableType = "ZPROC"
                            };

                if (deep)
                {
                    var texts = from r in GetRoutines(db.Server, db.Name)
                                where r.Text.ToUpper().Contains(queryString.ToUpper())
                                select new SearchResult
                                {
                                    Server = db.Server,
                                    Database = db.Name,
                                    QueryString = queryString,
                                    ObjectName = r.ObjectName,
                                    ObjectSearchable = r.Text,
                                    ObjectType = "ZPROC",
                                    SearchableType = "TEXT"
                                };

                    result.AddRange(names.Union(texts).OrderBy(r => r.ObjectName).ToList());
                }
                else
                {
                    result.AddRange(names.ToList());
                }
                
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

        #endregion
    }
}
