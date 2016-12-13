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
    public class GenreTypeRepository : RepositoryBase
    {
        #region private members

        private Dictionary<string, GenreType> __cache;
        private Dictionary<int, GenreType> __cacheOpt;

        #endregion

        #region public accessors

        public List<GenreType> Genres
        {
            get
            {
                if (__cache != null)
                {
                    return __cache.Values.ToList<GenreType>();
                }

                return new List<GenreType>();
            }
        }

        #endregion


        #region constructor

        public GenreTypeRepository()
        {
            __cache = new Dictionary<string, GenreType>();
            __cacheOpt = new Dictionary<int, GenreType>();
            List<GenreType> list = Read();
            foreach (GenreType g in list)
            {
                if (!__cache.ContainsKey(g.GenreTypeText))
                {
                    __cache.Add(g.GenreTypeText, g);
                }

                if (!__cacheOpt.ContainsKey(g.GenreTypeId))
                {
                    __cacheOpt.Add(g.GenreTypeId, g);
                }
            }
        }

        #endregion


        #region public methods

        public GenreType GetGenreType(GenreType genreType)
        {
            if (__cache.ContainsKey(genreType.GenreTypeText))
            {
                return __cache[genreType.GenreTypeText];
            }

            genreType.GenreTypeId = WriteNew(genreType, Environment.UserName);
            __cache.Add(genreType.GenreTypeText, genreType);
            __cacheOpt.Add(genreType.GenreTypeId, genreType);

            return genreType;
        }

        public List<GenreType> Read()
        {
            List<GenreType> list = new List<GenreType>();
            DbCommand command = Database.GetStoredProcCommand("prc_genre_type_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    GenreType genreType = new GenreType();
                    list.Add(Load(dr, genreType));
                }
            }

            return list;
        }


        public GenreType Read(int genreTypeId)
        {
            if (__cacheOpt.ContainsKey(genreTypeId))
            {
                return __cacheOpt[genreTypeId];
            }

            return new GenreType();
        }


        public GenreType Read(string genreTypeText)
        {
            if (__cache.ContainsKey(genreTypeText))
            {
                return __cache[genreTypeText];
            }

            return new GenreType();
        }


        public int Write(GenreType genreType, string updatedBy)
        {
            return Save(genreType, updatedBy);
        }


        public int WriteNew(GenreType genreType, string updatedBy)
        {
            return Add(genreType, updatedBy);
        }


        public int Write(List<GenreType> genreTypeList, string updatedBy)
        {
            return Save(genreTypeList, updatedBy);
        }


        #endregion

        #region internal methods

        protected GenreType Load(IDataReader dr, GenreType genreType)
        {
            if (ColumnExists(dr, "genre_type_id"))
            {
                if (dr["genre_type_id"] == DBNull.Value)
                {
                    genreType.GenreTypeId = 0;
                }
                else
                {
                    genreType.GenreTypeId = Convert.ToInt32(dr["genre_type_id"].ToString());
                }
            }
            if (ColumnExists(dr, "genre_type_map"))
            {
                if (dr["genre_type_map"] == DBNull.Value)
                {
                    genreType.GenreTypeMap = string.Empty;
                }
                else
                {
                    genreType.GenreTypeMap = Convert.ToString(dr["genre_type_map"].ToString());
                }
            }
            if (ColumnExists(dr, "genre_type_text"))
            {
                if (dr["genre_type_text"] == DBNull.Value)
                {
                    genreType.GenreTypeText = string.Empty;
                }
                else
                {
                    genreType.GenreTypeText = Convert.ToString(dr["genre_type_text"].ToString());
                }
            }


            return genreType;
        }


        internal int Add(GenreType genreType, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_genre_type_ins");
            Database.AddInParameter(command, "@genre_type_id", DbType.Int32, genreType.GenreTypeId);
            Database.AddInParameter(command, "@genre_type_map", DbType.String, genreType.GenreTypeMap);
            Database.AddInParameter(command, "@genre_type_text", DbType.String, genreType.GenreTypeText);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Convert.ToInt32(Database.ExecuteScalar(command));
        }


        internal int Save(GenreType genreType, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_genre_type_upd");
            Database.AddInParameter(command, "@genre_type_id", DbType.Int32, genreType.GenreTypeId);
            Database.AddInParameter(command, "@genre_type_map", DbType.String, genreType.GenreTypeMap);
            Database.AddInParameter(command, "@genre_type_text", DbType.String, genreType.GenreTypeText);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Database.ExecuteNonQuery(command);
        }


        internal int Save(List<GenreType> genreTypeList, string updatedBy)
        {

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(genreTypeList.GetType());
            serializer.Serialize(writer, genreTypeList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_genre_type_ups");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }


        #endregion

    }

}
