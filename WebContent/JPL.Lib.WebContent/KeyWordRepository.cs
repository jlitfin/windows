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
    public class KeyWordRepository : RepositoryBase
    {
        #region private members


        #endregion

        #region public accessors

        #endregion


        #region constructor

        public KeyWordRepository()
        {
        }

        #endregion


        #region public methods

        public List<KeyWord> Read()
        {
            List<KeyWord> list = new List<KeyWord>();
            DbCommand command = Database.GetStoredProcCommand("prc_key_word_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    KeyWord keyWord = new KeyWord();
                    list.Add(Load(dr, keyWord));
                }
            }

            return list;
        }

        public int Write(List<KeyWord> keyWordList, string updatedBy)
        {
            return Save(keyWordList, updatedBy);
        }


        #endregion

        #region internal methods

        protected KeyWord Load(IDataReader dr, KeyWord keyWord)
        {
            if (ColumnExists(dr, "word"))
            {
                if (dr["word"] == DBNull.Value)
                {
                    keyWord.Word = string.Empty;
                }
                else
                {
                    keyWord.Word = Convert.ToString(dr["word"].ToString());
                }
            }


            return keyWord;
        }

        internal int Save(List<KeyWord> keyWordList, string updatedBy)
        {

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(keyWordList.GetType());
            serializer.Serialize(writer, keyWordList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_key_word_ups");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }


        #endregion

    }

}
