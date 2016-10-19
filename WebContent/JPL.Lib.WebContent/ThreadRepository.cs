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

namespace JPL.Lib.WebContent
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

        public List<ThreadStats> GetThreadStats(int threadId)
        {
            DbCommand command = Database.GetStoredProcCommand("prc_thread_stats_sel_by_thread");
            Database.AddInParameter(command, "@thread_id", DbType.Int32, threadId);
            List<ThreadStats> stats = new List<ThreadStats>();

            int index = 1;
            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    ThreadStats ts = new ThreadStats();
                    ts.ThreadIndex = index++;

                    if (ColumnExists(dr, "thread_id"))
                    {
                        if (dr["thread_id"] == DBNull.Value)
                        {
                            ts.ThreadId = 0;
                        }
                        else
                        {
                            ts.ThreadId = Convert.ToInt32(dr["thread_id"].ToString());
                        }
                    }
                    if (ColumnExists(dr, "id"))
                    {
                        if (dr["id"] == DBNull.Value)
                        {
                            ts.PostId = 0;
                        }
                        else
                        {
                            ts.PostId = Convert.ToInt32(dr["id"].ToString());
                        }
                    }
                    if (ColumnExists(dr, "post_date"))
                    {
                        if (dr["post_date"] == DBNull.Value)
                        {
                            ts.PostDate = DateTime.MinValue;
                        }
                        else
                        {
                            ts.PostDate = Convert.ToDateTime(dr["post_date"].ToString());
                        }
                    }
                    if (ColumnExists(dr, "title"))
                    {
                        if (dr["title"] == DBNull.Value)
                        {
                            ts.PostTitle = string.Empty;
                        }
                        else
                        {
                            ts.PostTitle = Convert.ToString(dr["title"].ToString());
                        }
                    }
                    if (ColumnExists(dr, "author"))
                    {
                        if (dr["author"] == DBNull.Value)
                        {
                            ts.PostAuthor = string.Empty;
                        }
                        else
                        {
                            ts.PostAuthor = Convert.ToString(dr["author"].ToString());
                        }
                    }

                    stats.Add(ts);

                }
            }


            return stats;
        }

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

            thread.Statistics = GetThreadStats(thread.Id);

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
