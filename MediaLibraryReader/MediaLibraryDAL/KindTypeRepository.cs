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
    public class KindTypeRepository : RepositoryBase
    {
        #region private members

        private Dictionary<string, KindType> __cache;
        private Dictionary<int, KindType> __cacheOpt;

        #endregion

        #region public accessors

        public List<KindType> KindTypes
        {
            get
            {
                return __cache.Values.ToList<KindType>();
            }
        }

        #endregion

        #region constructor

        public KindTypeRepository()
        {
            __cache = new Dictionary<string, KindType>();
            __cacheOpt = new Dictionary<int, KindType>();
            List<KindType> list = Read();
            foreach (KindType k in list)
            {
                if (!__cache.ContainsKey(k.KindTypeText))
                {
                    __cache.Add(k.KindTypeText, k);
                }

                if (!__cacheOpt.ContainsKey(k.KindTypeId))
                {
                    __cacheOpt.Add(k.KindTypeId, k);
                }
            }
        }

        #endregion

        #region public methods

        public KindType GetKindType(KindType kindType)
        {
            if (__cache.ContainsKey(kindType.KindTypeText))
            {
                return __cache[kindType.KindTypeText];
            }
            
            //
            // if we don't alread have this, create a new one
            // and attempt to set the map type correctly
            //
            string kindTypeMap = "Unmapped";
            if (kindType.KindTypeText.ToLower().Contains("video") || kindType.KindTypeText.ToLower().Contains("movie"))
            {
                kindTypeMap = "video";
            }
            else
            {
                //
                // default to audio
                //
                kindTypeMap = "audio";
            }

            kindType.KindTypeMap = kindTypeMap;
            kindType.KindTypeId = WriteNew(kindType, Environment.UserName);
            __cache.Add(kindType.KindTypeText, kindType);
            __cacheOpt.Add(kindType.KindTypeId, kindType);

            return kindType;
        }

        public List<KindType> Read()
        {
            List<KindType> list = new List<KindType>();
            DbCommand command = Database.GetStoredProcCommand("prc_kind_type_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    KindType kindType = new KindType();
                    list.Add(Load(dr, kindType));
                }
            }

            return list;
        }


        public KindType Read(int kindTypeId)
        {
            if (__cacheOpt.ContainsKey(kindTypeId))
            {
                return __cacheOpt[kindTypeId];
            }

            return new KindType();
        }

        public KindType Read(string kindTypeText)
        {
            if (__cache.ContainsKey(kindTypeText))
            {
                return __cache[kindTypeText];
            }

            return new KindType();
        }

        public int Write(KindType kindType, string updatedBy)
        {
            return Save(kindType, updatedBy);
        }

        public int WriteNew(KindType kindType, string updatedBy)
        {
            return Add(kindType, updatedBy);
        }

        public int Write(List<KindType> kindTypeList, string updatedBy)
        {
            return Save(kindTypeList, updatedBy);
        }

        #endregion

        #region internal methods

        protected KindType Load(IDataReader dr, KindType kindType)
        {
            if (ColumnExists(dr, "kind_type_id"))
            {
                if (dr["kind_type_id"] == DBNull.Value)
                {
                    kindType.KindTypeId = 0;
                }
                else
                {
                    kindType.KindTypeId = Convert.ToInt32(dr["kind_type_id"].ToString());
                }
            }
            if (ColumnExists(dr, "kind_type_map"))
            {
                if (dr["kind_type_map"] == DBNull.Value)
                {
                    kindType.KindTypeMap = string.Empty;
                }
                else
                {
                    kindType.KindTypeMap = Convert.ToString(dr["kind_type_map"].ToString());
                }
            }
            if (ColumnExists(dr, "kind_type_text"))
            {
                if (dr["kind_type_text"] == DBNull.Value)
                {
                    kindType.KindTypeText = string.Empty;
                }
                else
                {
                    kindType.KindTypeText = Convert.ToString(dr["kind_type_text"].ToString());
                }
            }


            return kindType;
        }

        internal int Add(KindType kindType, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_kind_type_ins");
            Database.AddInParameter(command, "@kind_type_id", DbType.Int32, kindType.KindTypeId);
            Database.AddInParameter(command, "@kind_type_map", DbType.String, kindType.KindTypeMap);
            Database.AddInParameter(command, "@kind_type_text", DbType.String, kindType.KindTypeText);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Convert.ToInt32(Database.ExecuteScalar(command));
        }

        internal int Save(KindType kindType, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_kind_type_upd");
            Database.AddInParameter(command, "@kind_type_id", DbType.Int32, kindType.KindTypeId);
            Database.AddInParameter(command, "@kind_type_map", DbType.String, kindType.KindTypeMap);
            Database.AddInParameter(command, "@kind_type_text", DbType.String, kindType.KindTypeText);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Database.ExecuteNonQuery(command);
        }

        internal int Save(List<KindType> kindTypeList, string updatedBy)
        {

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(kindTypeList.GetType());
            serializer.Serialize(writer, kindTypeList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_kind_type_ups");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }

        #endregion

    }

}
