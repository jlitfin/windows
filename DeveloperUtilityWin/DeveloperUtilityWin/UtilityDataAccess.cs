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

        public static Database Database
        {
            get
            {
                __database = DatabaseFactory.CreateDatabase(ConnectionString);
                return __database;
            }
        }

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

        public static string ConnectionString { get; set; }
    }
}
