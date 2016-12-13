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
    public class KeyWordIndexRepository : RepositoryBase
    {
        #region private members


        #endregion

        #region public accessors

        #endregion


        #region constructor

        public KeyWordIndexRepository()
        {
        }

        #endregion


        #region public methods

        public Dictionary<string, SkipWord> GetSkipWords()
        {
            Dictionary<string, SkipWord> list = new Dictionary<string, SkipWord>();
            DbCommand command = Database.GetStoredProcCommand("prc_skip_word_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    SkipWord word = new SkipWord();
                    word = Load(dr, word);
                    list.Add(word.Value, word);
                }
            }

            return list;
        }


        public List<KeyWordIndex> Read()
        {
            List<KeyWordIndex> list = new List<KeyWordIndex>();
            DbCommand command = Database.GetStoredProcCommand("prc_key_word_index_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    KeyWordIndex keyWordIndex = new KeyWordIndex();
                    list.Add(Load(dr, keyWordIndex));
                }
            }

            return list;
        }



        public int Write(List<KeyWordIndex> keyWordIndexList, string updatedBy)
        {
            return Save(keyWordIndexList, updatedBy);
        }


        #endregion

        #region internal methods

        protected SkipWord Load(IDataReader dr, SkipWord skipWord)
        {
            if (ColumnExists(dr, "id"))
            {
                if (dr["id"] == DBNull.Value)
                {
                    skipWord.Id = 0;
                }
                else
                {
                    skipWord.Id = Convert.ToInt32(dr["id"].ToString());
                }
            }
            if (ColumnExists(dr, "skip_word"))
            {
                if (dr["skip_word"] == DBNull.Value)
                {
                    skipWord.Value = string.Empty;
                }
                else
                {
                    skipWord.Value = Convert.ToString(dr["skip_word"].ToString());
                }
            }


            return skipWord;
        }

        protected KeyWordIndex Load(IDataReader dr, KeyWordIndex keyWordIndex)
        {
            if (ColumnExists(dr, "id"))
            {
                if (dr["id"] == DBNull.Value)
                {
                    keyWordIndex.Id = 0;
                }
                else
                {
                    keyWordIndex.Id = Convert.ToInt32(dr["id"].ToString());
                }
            }
            if (ColumnExists(dr, "key_word"))
            {
                if (dr["key_word"] == DBNull.Value)
                {
                    keyWordIndex.KeyWord = string.Empty;
                }
                else
                {
                    keyWordIndex.KeyWord = Convert.ToString(dr["key_word"].ToString());
                }
            }
            if (ColumnExists(dr, "post_id"))
            {
                if (dr["post_id"] == DBNull.Value)
                {
                    keyWordIndex.PostId = 0;
                }
                else
                {
                    keyWordIndex.PostId = Convert.ToInt32(dr["post_id"].ToString());
                }
            }
            if (ColumnExists(dr, "count"))
            {
                if (dr["count"] == DBNull.Value)
                {
                    keyWordIndex.Count = 0;
                }
                else
                {
                    keyWordIndex.Count = Convert.ToInt32(dr["count"].ToString());
                }
            }


            return keyWordIndex;
        }

        internal int Save(List<KeyWordIndex> keyWordIndexList, string updatedBy)
        {

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(keyWordIndexList.GetType());
            serializer.Serialize(writer, keyWordIndexList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_key_word_index_ups");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }


        #endregion

    }

}
