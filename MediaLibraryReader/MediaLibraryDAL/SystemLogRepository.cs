using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace JPL.Lib.MediaLibraryReader
{
    public class SystemLogRepository : RepositoryBase
    {
        #region private members


        #endregion

        #region public accessors

        #endregion


        #region constructor

        public SystemLogRepository()
        {
        }

        #endregion


        #region public methods

        public List<SystemLog> Read()
        {
            List<SystemLog> list = new List<SystemLog>();
            DbCommand command = Database.GetStoredProcCommand("prc_system_log_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    SystemLog systemLog = new SystemLog();
                    list.Add(Load(dr, systemLog));
                }
            }

            return list;
        }

        public List<SystemLog> Read(int count)
        {
            List<SystemLog> list = new List<SystemLog>();
            DbCommand command = Database.GetStoredProcCommand("prc_system_log_sel_count");
            //
            // Optional Parameters:
            //
            Database.AddInParameter(command, "@count", DbType.Int32, count);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    SystemLog systemLog = new SystemLog();
                    list.Add(Load(dr, systemLog));
                }
            }

            return list;
        }

        public void Log(string action, string desc, string user)
        {
            SystemLog log = new SystemLog();
            log.Activity = action;
            log.Description = desc;

            WriteNew(log, user);
        }

        public int WriteNew(SystemLog systemLog, string updatedBy)
        {
            return Add(systemLog, updatedBy);
        }

        #endregion

        #region internal methods

        protected SystemLog Load(IDataReader dr, SystemLog systemLog)
        {
            if (ColumnExists(dr, "activity"))
            {
                if (dr["activity"] == DBNull.Value)
                {
                    systemLog.Activity = string.Empty;
                }
                else
                {
                    systemLog.Activity = Convert.ToString(dr["activity"].ToString());
                }
            }
            if (ColumnExists(dr, "description"))
            {
                if (dr["description"] == DBNull.Value)
                {
                    systemLog.Description = string.Empty;
                }
                else
                {
                    systemLog.Description = Convert.ToString(dr["description"].ToString());
                }
            }
            if (ColumnExists(dr, "id"))
            {
                if (dr["id"] == DBNull.Value)
                {
                    systemLog.Id = 0;
                }
                else
                {
                    systemLog.Id = Convert.ToInt32(dr["id"].ToString());
                }
            }
            if (ColumnExists(dr, "updated_by"))
            {
                if (dr["updated_by"] == DBNull.Value)
                {
                    systemLog.UpdatedBy = string.Empty;
                }
                else
                {
                    systemLog.UpdatedBy = Convert.ToString(dr["updated_by"].ToString());
                }
            }
            if (ColumnExists(dr, "updated_date"))
            {
                if (dr["updated_date"] == DBNull.Value)
                {
                    systemLog.UpdatedDate = DateTime.MinValue;
                }
                else
                {
                    systemLog.UpdatedDate = Convert.ToDateTime(dr["updated_date"].ToString());
                }
            }


            return systemLog;
        }


        internal int Add(SystemLog systemLog, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_system_log_ins");
            Database.AddInParameter(command, "@activity", DbType.String, systemLog.Activity);
            Database.AddInParameter(command, "@description", DbType.String, systemLog.Description);
            Database.AddInParameter(command, "@id", DbType.Int32, systemLog.Id);
            Database.AddInParameter(command, "@updated_by", DbType.String, systemLog.UpdatedBy);

            return Convert.ToInt32(Database.ExecuteScalar(command));
        }

        #endregion

    }

}
