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
    public class ImdbSearchRepository : RepositoryBase
    {
        #region private members

        private static Dictionary<string, ImdbSearch> __cache;

        #endregion

        #region public accessors

        #endregion

        #region constructor

        public ImdbSearchRepository()
        {
            BuildCache();
        }

        #endregion


        #region public methods

        public List<ImdbSearch> Read()
        {
            List<ImdbSearch> list = new List<ImdbSearch>();
            DbCommand command = Database.GetStoredProcCommand("prc_imdb_search_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    ImdbSearch imdbSearch = new ImdbSearch();
                    list.Add(Load(dr, imdbSearch));
                }
            }

            return list;
        }


        public ImdbSearch Read(string searchString)
        {
            ImdbSearch result = new ImdbSearch();
            if (__cache.ContainsKey(searchString.ToUpper()))
            {
                result = __cache[searchString.ToUpper()];
            }

            return result;
        }

        public int Write(ImdbSearch imdbSearch, string updatedBy)
        {
            int result = Save(imdbSearch, updatedBy);
            if (result > 0)
            {
                BuildCache();
            }

            return result;
        }

        public int WriteNew(ImdbSearch imdbSearch, string updatedBy)
        {
            
            int result = Add(imdbSearch, updatedBy);
            if (result > 0)
            {
                BuildCache();
            }

            return result;
        }

        #endregion

        #region internal methods

        protected ImdbSearch Load(IDataReader dr, ImdbSearch imdbSearch)
        {
            if (ColumnExists(dr, "imdb_search_id"))
            {
                if (dr["imdb_search_id"] == DBNull.Value)
                {
                    imdbSearch.ImdbSearchId = 0;
                }
                else
                {
                    imdbSearch.ImdbSearchId = Convert.ToInt32(dr["imdb_search_id"].ToString());
                }
            }
            if (ColumnExists(dr, "json_result"))
            {
                if (dr["json_result"] == DBNull.Value)
                {
                    imdbSearch.JsonResult = string.Empty;
                }
                else
                {
                    imdbSearch.JsonResult = Convert.ToString(dr["json_result"].ToString());
                }
            }
            if (ColumnExists(dr, "search_string"))
            {
                if (dr["search_string"] == DBNull.Value)
                {
                    imdbSearch.SearchString = string.Empty;
                }
                else
                {
                    imdbSearch.SearchString = Convert.ToString(dr["search_string"].ToString());
                }
            }


            return imdbSearch;
        }

        internal int Add(ImdbSearch imdbSearch, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_imdb_search_ins");
            Database.AddInParameter(command, "@imdb_search_id", DbType.Int32, imdbSearch.ImdbSearchId);
            Database.AddInParameter(command, "@json_result", DbType.String, imdbSearch.JsonResult);
            Database.AddInParameter(command, "@search_string", DbType.String, imdbSearch.SearchString);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);

            return Convert.ToInt32(Database.ExecuteScalar(command));
        }

        internal int Save(ImdbSearch imdbSearch, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_imdb_search_upd");
            Database.AddInParameter(command, "@imdb_search_id", DbType.Int32, imdbSearch.ImdbSearchId);
            Database.AddInParameter(command, "@json_result", DbType.String, imdbSearch.JsonResult);
            Database.AddInParameter(command, "@search_string", DbType.String, imdbSearch.SearchString);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);

            return Database.ExecuteNonQuery(command);
        }

        #endregion

        #region private

        private void BuildCache()
        {
            if (__cache == null) __cache = new Dictionary<string, ImdbSearch>();
            List<ImdbSearch> list = Read();
            foreach (ImdbSearch i in list)
            {
                if (!__cache.ContainsKey(i.SearchString.ToUpper()))
                {
                    __cache.Add(i.SearchString.ToUpper(), i);
                }
            }
        }

        #endregion
    }

}
