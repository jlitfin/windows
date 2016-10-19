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
    public class AlbumRepository : RepositoryBase
    {
        #region private members

        private Dictionary<string, Album> __cache;
        private Dictionary<int, Album> __cacheOpt;

        #endregion

        #region public accessors

        #endregion


        #region constructor

        public AlbumRepository()
        {
            __cache = new Dictionary<string, Album>();
            __cacheOpt = new Dictionary<int, Album>();
            List<Album> list = Read();
            foreach (Album a in list)
            {
                if (!__cache.ContainsKey(a.Name))
                {
                    __cache.Add(a.Name, a);
                }

                if (!__cacheOpt.ContainsKey(a.AlbumId))
                {
                    __cacheOpt.Add(a.AlbumId, a);
                }

            }
        }

        #endregion


        #region public methods

        public int GetAlbumId(Album album)
        {
            if (__cache.ContainsKey(album.Name))
            {
                return __cache[album.Name].AlbumId;
            }
            else
            {
                //
                // adding new
                //
                album.AlbumId = WriteNew(album, Environment.UserName);
                __cache.Add(album.Name, album);
            }
            //
            // return requested id
            //
            return album.AlbumId;
        }

        public List<Album> Read()
        {
            List<Album> list = new List<Album>();
            DbCommand command = Database.GetStoredProcCommand("prc_album_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    Album album = new Album();
                    list.Add(Load(dr, album));
                }
            }

            return list;
        }


        public Album Read(int albumId)
        {
            if (__cacheOpt.ContainsKey(albumId))
            {
                return __cacheOpt[albumId];
            }

            return new Album();
        }

        public Album Read(string albumName)
        {
            if (__cache.ContainsKey(albumName))
            {
                return __cache[albumName];
            }

            return new Album();
        }

        public int Write(Album album, string updatedBy)
        {
            return Save(album, updatedBy);
        }

        public int WriteNew(Album album, string updatedBy)
        {
            return Add(album, updatedBy);
        }

        public int Write(List<Album> albumList, string updatedBy)
        {
            return Save(albumList, updatedBy);
        }

        #endregion

        #region internal methods

        protected Album Load(IDataReader dr, Album album)
        {
            if (ColumnExists(dr, "album_id"))
            {
                if (dr["album_id"] == DBNull.Value)
                {
                    album.AlbumId = 0;
                }
                else
                {
                    album.AlbumId = Convert.ToInt32(dr["album_id"].ToString());
                }
            }
            if (ColumnExists(dr, "imdb_id"))
            {
                if (dr["imdb_id"] == DBNull.Value)
                {
                    album.ImdbId = string.Empty;
                }
                else
                {
                    album.ImdbId = Convert.ToString(dr["imdb_id"].ToString());
                }
            }
            if (ColumnExists(dr, "manual_update"))
            {
                if (dr["manual_update"] == DBNull.Value)
                {
                    album.ManualUpdate = false;
                }
                else
                {
                    album.ManualUpdate = Convert.ToBoolean(dr["manual_update"].ToString());
                }
            }
            if (ColumnExists(dr, "name"))
            {
                if (dr["name"] == DBNull.Value)
                {
                    album.Name = string.Empty;
                }
                else
                {
                    album.Name = Convert.ToString(dr["name"].ToString());
                }
            }
            if (ColumnExists(dr, "year"))
            {
                if (dr["year"] == DBNull.Value)
                {
                    album.Year = 0;
                }
                else
                {
                    album.Year = Convert.ToInt32(dr["year"].ToString());
                }
            }


            return album;
        }


        internal int Add(Album album, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_album_ins");
            Database.AddInParameter(command, "@imdb_id", DbType.String, album.ImdbId);
            Database.AddInParameter(command, "@manual_update", DbType.Boolean, album.ManualUpdate);
            Database.AddInParameter(command, "@name", DbType.String, album.Name);
            Database.AddInParameter(command, "@year", DbType.Int32, album.Year);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);

            return Convert.ToInt32(Database.ExecuteScalar(command));
        }


        internal int Save(Album album, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_album_upd");
            Database.AddInParameter(command, "@album_id", DbType.Int32, album.AlbumId);
            Database.AddInParameter(command, "@imdb_id", DbType.String, album.ImdbId);
            Database.AddInParameter(command, "@manual_update", DbType.Boolean, album.ManualUpdate);
            Database.AddInParameter(command, "@name", DbType.String, album.Name);
            Database.AddInParameter(command, "@year", DbType.Int32, album.Year);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);

            return Database.ExecuteNonQuery(command);
        }


        internal int Save(List<Album> albumList, string updatedBy)
        {

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(albumList.GetType());
            serializer.Serialize(writer, albumList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_album_ups");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }


        #endregion

    }

}
