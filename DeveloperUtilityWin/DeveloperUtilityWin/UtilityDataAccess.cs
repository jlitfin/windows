using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DeveloperUtilityWin
{
    public static class UtilityDataAccess
    {
        private static Microsoft.Practices.EnterpriseLibrary.Data.Database __database;
        private static Dictionary<string, List<string>> __leftSchema;
        private static Dictionary<string, List<string>> __rightSchema;

        #region public accessors

        public static Database Database
        {
            get
            {
                __database = DatabaseFactory.CreateDatabase(ConnectionString);
                return __database;
            }
        }

        public static string ConnectionString { get; set; }

        public static Dictionary<string, List<string>> LeftSchema
        {
            get
            {
                if (__leftSchema == null)
                {
                    InitializeLeftSchema();
                }

                return __leftSchema;
            }
        }



        public static Dictionary<string, List<string>> RightSchema
        {
            get
            {
                if (__rightSchema == null)
                {
                    InitializeRightSchema();
                }

                return __rightSchema;
            }
        }

        #endregion

        #region public methods

        public static bool ColumnExists(IDataRecord dr, string columnName)
        {
            try
            {
                return dr.GetOrdinal(columnName) >= 0;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public static Table GetLeftTable(string table, List<string> columns)
        {
            Database databaseLeft = DatabaseFactory.CreateDatabase("db_left");
            DbCommand command = databaseLeft.GetSqlStringCommand(GetSelectForTable(table, columns));

            using (IDataReader dr = databaseLeft.ExecuteReader(command))
            {
                Table t = new Table(table, columns, dr);
                return t;
            }
        }

        public static Table GetRightTable(string table, List<string> columns)
        {
            Database databaseLeft = DatabaseFactory.CreateDatabase("db_right");
            DbCommand command = databaseLeft.GetSqlStringCommand(GetSelectForTable(table, columns));

            using (IDataReader dr = databaseLeft.ExecuteReader(command))
            {
                Table t = new Table(table, columns, dr);
                return t;
            }
        }

        public static List<DBColumn> GetTableDefinition(string catalog, string schema, string tableName)
        {
            List<DBColumn> columns = new List<DBColumn>();
            string query = String.Format(
              @"SELECT TABLE_CATALOG ,TABLE_SCHEMA ,TABLE_NAME ,COLUMN_NAME ,DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE
                FROM
	                INFORMATION_SCHEMA.COLUMNS
                WHERE
	                TABLE_CATALOG    = '{0}'
	                AND TABLE_SCHEMA = '{1}'
	                AND TABLE_NAME   = '{2}'  
                ORDER BY
	                COLUMN_NAME", catalog, schema, tableName);

            using (IDataReader dr = Database.ExecuteReader(CommandType.Text, query))
            {
                while (dr.Read())
                {
                    DBColumn col = new DBColumn();
                    col.TableCatalog = dr["TABLE_CATALOG"].ToString();
                    col.TableSchema = dr["TABLE_SCHEMA"].ToString();
                    col.TableName = dr["TABLE_NAME"].ToString();
                    col.ColumnName = dr["COLUMN_NAME"].ToString();
                    col.DataType = dr["DATA_TYPE"].ToString();
                    col.CharacterLength = dr["CHARACTER_MAXIMUM_LENGTH"] == DBNull.Value ? string.Empty : dr["CHARACTER_MAXIMUM_LENGTH"].ToString();
                    col.NumericPrecision = dr["NUMERIC_PRECISION"] == DBNull.Value ? string.Empty : dr["NUMERIC_PRECISION"].ToString();
                    col.NumericScale = dr["NUMERIC_SCALE"] == DBNull.Value ? string.Empty : dr["NUMERIC_SCALE"].ToString();

                    columns.Add(col);
                }
            }
            
            return columns;
        }

        #endregion

        #region private methods

        private static string GetSelectForTable(string tableName, List<string> columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            bool isFirst = true;
            foreach (string col in columns)
            {
                if (isFirst)
                {
                    sb.AppendLine(col);
                    isFirst = false;
                }
                else
                {
                    sb.Append(",");
                    sb.Append(col);
                    sb.Append(Environment.NewLine);
                }
            }
            sb.AppendLine("FROM");
            sb.AppendLine(tableName);

            return sb.ToString();
        }

        private static void InitializeLeftSchema()
        {
            Database databaseLeft = DatabaseFactory.CreateDatabase("db_left");
            DbCommand command = databaseLeft.GetSqlStringCommand(Constants.SELECT_SCHEMA);

            using (IDataReader dr = databaseLeft.ExecuteReader(command))
            {
                LoadSchema(dr, out __leftSchema);
            }
        }



        private static void InitializeRightSchema()
        {
            Database databaseRight = DatabaseFactory.CreateDatabase("db_right");
            DbCommand command = databaseRight.GetSqlStringCommand(Constants.SELECT_SCHEMA);

            using (IDataReader dr = databaseRight.ExecuteReader(command))
            {
                LoadSchema(dr, out __rightSchema);
            }
        }

        private static void LoadSchema(IDataReader dr, out Dictionary<string, List<string>> target)
        {
            target = new Dictionary<string, List<string>>();
            while (dr.Read())
            {
                string key = dr["table"].ToString();
                if (!target.ContainsKey(key))
                {
                    target.Add(key, new List<string>());
                }

                string column = dr["column"].ToString();
                target[key].Add(column);
            }
        }

        #endregion


    }
}
