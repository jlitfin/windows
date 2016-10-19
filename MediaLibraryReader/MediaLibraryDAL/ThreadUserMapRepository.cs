using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JPL.Lib.MediaLibraryReader
{
    public class ThreadUserMapRepository : RepositoryBase
    {
        #region private members


        #endregion

        #region public accessors

        #endregion


        #region constructor

        public ThreadUserMapRepository()
        {
        }

        #endregion


        #region public methods

        public List<ThreadUserMap> Read()
        {
            List<ThreadUserMap> list = new List<ThreadUserMap>();
            DbCommand command = Database.GetStoredProcCommand("prc_thread_user_map_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    ThreadUserMap threadUserMap = new ThreadUserMap();
                    list.Add(Load(dr, threadUserMap));
                }
            }

            return list;
        }

        public int Write(List<ThreadUserMap> threadUserMapList, string updatedBy)
        {
            return Save(threadUserMapList, updatedBy);
        }


        #endregion

        #region internal methods

        protected ThreadUserMap Load(IDataReader dr, ThreadUserMap threadUserMap)
        {
            if (ColumnExists(dr, "id"))
            {
                if (dr["id"] == DBNull.Value)
                {
                    threadUserMap.Id = 0;
                }
                else
                {
                    threadUserMap.Id = Convert.ToInt32(dr["id"].ToString());
                }
            }
            if (ColumnExists(dr, "thread_id"))
            {
                if (dr["thread_id"] == DBNull.Value)
                {
                    threadUserMap.ThreadId = 0;
                }
                else
                {
                    threadUserMap.ThreadId = Convert.ToInt32(dr["thread_id"].ToString());
                }
            }
            if (ColumnExists(dr, "user_name"))
            {
                if (dr["user_name"] == DBNull.Value)
                {
                    threadUserMap.UserName = string.Empty;
                }
                else
                {
                    threadUserMap.UserName = Convert.ToString(dr["user_name"].ToString());
                }
            }


            return threadUserMap;
        }


        internal int Save(List<ThreadUserMap> threadUserMapList, string updatedBy)
        {

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(threadUserMapList.GetType());
            serializer.Serialize(writer, threadUserMapList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_thread_user_map_ups");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }


        #endregion

    }



}
