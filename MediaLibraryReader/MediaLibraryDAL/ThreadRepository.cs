using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Practices.EnterpriseLibrary.Data;

namespace JPL.Lib.MediaLibraryReader
{
    public class ThreadRepository : RepositoryBase
    {
        #region private members


        #endregion

        #region public accessors

        #endregion


        #region constructor

        public ThreadRepository()
        {
        }

        #endregion


        #region public methods

        public List<Thread> Read()
        {
            List<Thread> list = new List<Thread>();
            DbCommand command = Database.GetStoredProcCommand("prc_thread_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    Thread thread = new Thread();
                    list.Add(Load(dr, thread));
                }
            }

            return list;
        }


        public int WriteNew(Thread thread, string updatedBy)
        {
            return Add(thread, updatedBy);
        }


        #endregion

        #region internal methods

        protected Thread Load(IDataReader dr, Thread thread)
        {
            if (ColumnExists(dr, "id"))
            {
                if (dr["id"] == DBNull.Value)
                {
                    thread.Id = 0;
                }
                else
                {
                    thread.Id = Convert.ToInt32(dr["id"].ToString());
                }
            }
            if (ColumnExists(dr, "title"))
            {
                if (dr["title"] == DBNull.Value)
                {
                    thread.Title = string.Empty;
                }
                else
                {
                    thread.Title = Convert.ToString(dr["title"].ToString());
                }
            }


            return thread;
        }


        internal int Add(Thread thread, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_thread_ins");
            Database.AddInParameter(command, "@id", DbType.Int32, thread.Id);
            Database.AddInParameter(command, "@title", DbType.String, thread.Title);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Convert.ToInt32(Database.ExecuteScalar(command));
        }


        internal int Save(Thread thread, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_thread_upd");
            Database.AddInParameter(command, "@id", DbType.Int32, thread.Id);
            Database.AddInParameter(command, "@title", DbType.String, thread.Title);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Database.ExecuteNonQuery(command);
        }


        #endregion

    }

}
