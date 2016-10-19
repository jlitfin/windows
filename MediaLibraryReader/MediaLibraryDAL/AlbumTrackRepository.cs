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
    public class AlbumTrackRepository : RepositoryBase
    {
        #region private members

        private Dictionary<int, AlbumTrack> __cache;
        private Dictionary<int, int> __cacheExt;

        #endregion

        #region public accessors

        #endregion


        #region constructor

        public AlbumTrackRepository()
        {
            __cache = new Dictionary<int, AlbumTrack>();
            __cacheExt = new Dictionary<int, int>();
            List<AlbumTrack> list = Read();
            foreach (AlbumTrack a in list)
            {
                if (!__cache.ContainsKey(a.AlbumTrackId))
                {
                    __cache.Add(a.AlbumTrackId, a);
                }

                if (a.ItunesTrackId != 0)
                {
                    if (!__cacheExt.ContainsKey(a.ItunesTrackId))
                    {
                        __cacheExt.Add(a.ItunesTrackId, a.AlbumTrackId);
                    }
                }
            }
        }

        #endregion


        #region public methods

        public int GetAlbumTrackId(int iTunesTrackId)
        {
            if (__cacheExt.ContainsKey(iTunesTrackId))
            {
                return __cacheExt[iTunesTrackId];
            }

            return 0;
        }

        public List<AlbumTrack> Read()
        {
            List<AlbumTrack> list = new List<AlbumTrack>();
            DbCommand command = Database.GetStoredProcCommand("prc_album_track_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    AlbumTrack albumTrack = new AlbumTrack();
                    list.Add(Load(dr, albumTrack));
                }
            }

            return list;
        }

        public AlbumTrack Read(int albumTrackId)
        {
            if (__cache.ContainsKey(albumTrackId))
            {
                return __cache[albumTrackId];
            }

            return null;
        }

        public List<AlbumTrack> Read(Album forAlbum)
        {
            List<AlbumTrack> tracks = new List<AlbumTrack>();
            foreach (KeyValuePair<int, AlbumTrack> kv in __cache)
            {
                if (kv.Value.AlbumId == forAlbum.AlbumId)
                {
                    tracks.Add(kv.Value);
                }
            }

            return tracks;
        }


        public int Write(AlbumTrack albumTrack, string updatedBy)
        {
            return Save(albumTrack, updatedBy);
        }


        public int WriteNew(AlbumTrack albumTrack, string updatedBy)
        {
            return Add(albumTrack, updatedBy);
        }


        public int Write(List<AlbumTrack> albumTrackList, string updatedBy)
        {
            return Save(albumTrackList, updatedBy);
        }


        public int WriteWithReplace(List<AlbumTrack> albumTrackList, string updatedBy)
        {
            return Replace(albumTrackList, updatedBy);
        }


        #endregion
        #region internal methods

        protected AlbumTrack Load(IDataReader dr, AlbumTrack albumTrack)
        {
            if (ColumnExists(dr, "album_id"))
            {
                if (dr["album_id"] == DBNull.Value)
                {
                    albumTrack.AlbumId = 0;
                }
                else
                {
                    albumTrack.AlbumId = Convert.ToInt32(dr["album_id"].ToString());
                }
            }
            if (ColumnExists(dr, "album_track_id"))
            {
                if (dr["album_track_id"] == DBNull.Value)
                {
                    albumTrack.AlbumTrackId = 0;
                }
                else
                {
                    albumTrack.AlbumTrackId = Convert.ToInt32(dr["album_track_id"].ToString());
                }
            }
            if (ColumnExists(dr, "artist_id"))
            {
                if (dr["artist_id"] == DBNull.Value)
                {
                    albumTrack.ArtistId = 0;
                }
                else
                {
                    albumTrack.ArtistId = Convert.ToInt32(dr["artist_id"].ToString());
                }
            }
            if (ColumnExists(dr, "genre_id"))
            {
                if (dr["genre_id"] == DBNull.Value)
                {
                    albumTrack.GenreId = 0;
                }
                else
                {
                    albumTrack.GenreId = Convert.ToInt32(dr["genre_id"].ToString());
                }
            }
            if (ColumnExists(dr, "itunes_track_id"))
            {
                if (dr["itunes_track_id"] == DBNull.Value)
                {
                    albumTrack.ItunesTrackId = 0;
                }
                else
                {
                    albumTrack.ItunesTrackId = Convert.ToInt32(dr["itunes_track_id"].ToString());
                }
            }
            if (ColumnExists(dr, "kind_type_id"))
            {
                if (dr["kind_type_id"] == DBNull.Value)
                {
                    albumTrack.KindTypeId = 0;
                }
                else
                {
                    albumTrack.KindTypeId = Convert.ToInt32(dr["kind_type_id"].ToString());
                }
            }
            if (ColumnExists(dr, "manual_update"))
            {
                if (dr["manual_update"] == DBNull.Value)
                {
                    albumTrack.ManualUpdate = false;
                }
                else
                {
                    albumTrack.ManualUpdate = Convert.ToBoolean(dr["manual_update"].ToString());
                }
            }
            if (ColumnExists(dr, "name"))
            {
                if (dr["name"] == DBNull.Value)
                {
                    albumTrack.Name = string.Empty;
                }
                else
                {
                    albumTrack.Name = Convert.ToString(dr["name"].ToString());
                }
            }
            if (ColumnExists(dr, "persistent_id"))
            {
                if (dr["persistent_id"] == DBNull.Value)
                {
                    albumTrack.PersistentId = string.Empty;
                }
                else
                {
                    albumTrack.PersistentId = Convert.ToString(dr["persistent_id"].ToString());
                }
            }
            if (ColumnExists(dr, "total_time_string"))
            {
                if (dr["total_time_string"] == DBNull.Value)
                {
                    albumTrack.TotalTimeString = string.Empty;
                }
                else
                {
                    albumTrack.TotalTimeString = Convert.ToString(dr["total_time_string"].ToString());
                }
            }
            if (ColumnExists(dr, "track_number"))
            {
                if (dr["track_number"] == DBNull.Value)
                {
                    albumTrack.TrackNumber = 0;
                }
                else
                {
                    albumTrack.TrackNumber = Convert.ToInt32(dr["track_number"].ToString());
                }
            }


            return albumTrack;
        }


        internal int Add(AlbumTrack albumTrack, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_album_track_ins");
            Database.AddInParameter(command, "@album_id", DbType.Int32, albumTrack.AlbumId);
            Database.AddInParameter(command, "@album_track_id", DbType.Int32, albumTrack.AlbumTrackId);
            Database.AddInParameter(command, "@artist_id", DbType.Int32, albumTrack.ArtistId);
            Database.AddInParameter(command, "@genre_id", DbType.Int32, albumTrack.GenreId);
            Database.AddInParameter(command, "@itunes_track_id", DbType.Int32, albumTrack.ItunesTrackId);
            Database.AddInParameter(command, "@kind_type_id", DbType.Int32, albumTrack.KindTypeId);
            Database.AddInParameter(command, "@manual_update", DbType.Boolean, albumTrack.ManualUpdate);
            Database.AddInParameter(command, "@name", DbType.String, albumTrack.Name);
            Database.AddInParameter(command, "@persistent_id", DbType.String, albumTrack.PersistentId);
            Database.AddInParameter(command, "@total_time_string", DbType.String, albumTrack.TotalTimeString);
            Database.AddInParameter(command, "@track_number", DbType.Int32, albumTrack.TrackNumber);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Convert.ToInt32(Database.ExecuteScalar(command));
        }


        internal int Replace(List<AlbumTrack> albumTrackList, string updatedBy)
        {
            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(albumTrackList.GetType());
            serializer.Serialize(writer, albumTrackList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_album_track_rpl");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }


        internal int Save(AlbumTrack albumTrack, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_album_track_upd");
            Database.AddInParameter(command, "@album_id", DbType.Int32, albumTrack.AlbumId);
            Database.AddInParameter(command, "@album_track_id", DbType.Int32, albumTrack.AlbumTrackId);
            Database.AddInParameter(command, "@artist_id", DbType.Int32, albumTrack.ArtistId);
            Database.AddInParameter(command, "@genre_id", DbType.Int32, albumTrack.GenreId);
            Database.AddInParameter(command, "@itunes_track_id", DbType.Int32, albumTrack.ItunesTrackId);
            Database.AddInParameter(command, "@kind_type_id", DbType.Int32, albumTrack.KindTypeId);
            Database.AddInParameter(command, "@manual_update", DbType.Boolean, albumTrack.ManualUpdate);
            Database.AddInParameter(command, "@name", DbType.String, albumTrack.Name);
            Database.AddInParameter(command, "@persistent_id", DbType.String, albumTrack.PersistentId);
            Database.AddInParameter(command, "@total_time_string", DbType.String, albumTrack.TotalTimeString);
            Database.AddInParameter(command, "@track_number", DbType.Int32, albumTrack.TrackNumber);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Database.ExecuteNonQuery(command);
        }


        internal int Save(List<AlbumTrack> albumTrackList, string updatedBy)
        {

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(albumTrackList.GetType());
            serializer.Serialize(writer, albumTrackList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_album_track_ups");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }


        #endregion

    }

}
