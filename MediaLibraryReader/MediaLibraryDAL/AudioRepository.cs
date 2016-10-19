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
    public class AudioRepository : RepositoryBase
    {
        #region private members

        private Dictionary<int, Audio> __cache;

        #endregion

        #region public accessors

        #endregion


        #region constructor

        public AudioRepository()
        {
            __cache = new Dictionary<int, Audio>();
            List<Audio> list = Read();
            foreach (Audio a in list)
            {
                if (!__cache.ContainsKey(a.ItunesTrackId))
                {
                    __cache.Add(a.ItunesTrackId, a);
                }
            }
        }

        #endregion


        #region public methods

        public int GetAudioId(int itunesTrackId)
        {
            if (__cache.ContainsKey(itunesTrackId))
            {
                return __cache[itunesTrackId].AudioId;
            }

            return 0;         
        }

        public void Push(Audio audio)
        {
            if (!__cache.ContainsKey(audio.ItunesTrackId))
            {
                __cache.Add(audio.ItunesTrackId, audio);
            }
        }

        public int PushCache()
        {
            List<Audio> list = new List<Audio>();
            foreach (Audio a in __cache.Values)
            {
                list.Add(a);
            }

            return Write(list, Environment.UserName);
        }

        public List<Audio> Read()
        {
            if (__cache != null && __cache.Values.Count > 0)
            {
                return __cache.Values.ToList<Audio>();
            }

            List<Audio> list = new List<Audio>();
            DbCommand command = Database.GetStoredProcCommand("prc_audio_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    Audio audio = new Audio();
                    list.Add(Load(dr, audio));
                }
            }

            return list;
        }

        public Audio Read(int itunesTrackId)
        {
            if (__cache.ContainsKey(itunesTrackId))
            {
                return __cache[itunesTrackId];
            }

            return null;
        }

        public int Write(Audio audio, string updatedBy)
        {
            return Save(audio, updatedBy);
        }

        public int WriteNew(Audio audio, string updatedBy)
        {
            return Add(audio, updatedBy);
        }

        public int Write(List<Audio> audioList, string updatedBy)
        {
            return Save(audioList, updatedBy);
        }

        #endregion

        #region internal methods

        protected Audio Load(IDataReader dr, Audio audio)
        {
            if (ColumnExists(dr, "audio_id"))
            {
                if (dr["audio_id"] == DBNull.Value)
                {
                    audio.AudioId = 0;
                }
                else
                {
                    audio.AudioId = Convert.ToInt32(dr["audio_id"].ToString());
                }
            }
            if (ColumnExists(dr, "album_id"))
            {
                if (dr["album_id"] == DBNull.Value)
                {
                    audio.AlbumId = 0;
                }
                else
                {
                    audio.AlbumId = Convert.ToInt32(dr["album_id"].ToString());
                }
            }
            if (ColumnExists(dr, "artist_id"))
            {
                if (dr["artist_id"] == DBNull.Value)
                {
                    audio.ArtistId = 0;
                }
                else
                {
                    audio.ArtistId = Convert.ToInt32(dr["artist_id"].ToString());
                }
            }
            if (ColumnExists(dr, "genre_id"))
            {
                if (dr["genre_id"] == DBNull.Value)
                {
                    audio.GenreId = 0;
                }
                else
                {
                    audio.GenreId = Convert.ToInt32(dr["genre_id"].ToString());
                }
            }
            if (ColumnExists(dr, "itunes_track_id"))
            {
                if (dr["itunes_track_id"] == DBNull.Value)
                {
                    audio.ItunesTrackId = 0;
                }
                else
                {
                    audio.ItunesTrackId = Convert.ToInt32(dr["itunes_track_id"].ToString());
                }
            }
            if (ColumnExists(dr, "kind_type_id"))
            {
                if (dr["kind_type_id"] == DBNull.Value)
                {
                    audio.KindTypeId = 0;
                }
                else
                {
                    audio.KindTypeId = Convert.ToInt32(dr["kind_type_id"].ToString());
                }
            }
            if (ColumnExists(dr, "name"))
            {
                if (dr["name"] == DBNull.Value)
                {
                    audio.Name = string.Empty;
                }
                else
                {
                    audio.Name = Convert.ToString(dr["name"].ToString());
                }
            }
            if (ColumnExists(dr, "total_time_string"))
            {
                if (dr["total_time_string"] == DBNull.Value)
                {
                    audio.TotalTimeString = string.Empty;
                }
                else
                {
                    audio.TotalTimeString = Convert.ToString(dr["total_time_string"].ToString());
                }
            }
            if (ColumnExists(dr, "track_number"))
            {
                if (dr["track_number"] == DBNull.Value)
                {
                    audio.TrackNumber = 0;
                }
                else
                {
                    audio.TrackNumber = Convert.ToInt32(dr["track_number"].ToString());
                }
            }


            return audio;
        }


        internal int Add(Audio audio, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_audio_ins");
            Database.AddInParameter(command, "@audio_id", DbType.Int32, audio.AudioId);
            Database.AddInParameter(command, "@album_id", DbType.Int32, audio.AlbumId);
            Database.AddInParameter(command, "@artist_id", DbType.Int32, audio.ArtistId);
            Database.AddInParameter(command, "@genre_id", DbType.Int32, audio.GenreId);
            Database.AddInParameter(command, "@itunes_track_id", DbType.Int32, audio.ItunesTrackId);
            Database.AddInParameter(command, "@kind_type_id", DbType.Int32, audio.KindTypeId);
            Database.AddInParameter(command, "@name", DbType.String, audio.Name);
            Database.AddInParameter(command, "@total_time_string", DbType.String, audio.TotalTimeString);
            Database.AddInParameter(command, "@track_number", DbType.Int32, audio.TrackNumber);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Convert.ToInt32(Database.ExecuteScalar(command));
        }


        internal int Save(Audio audio, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_audio_upd");
            Database.AddInParameter(command, "@audio_id", DbType.Int32, audio.AudioId);
            Database.AddInParameter(command, "@album_id", DbType.Int32, audio.AlbumId);
            Database.AddInParameter(command, "@artist_id", DbType.Int32, audio.ArtistId);
            Database.AddInParameter(command, "@genre_id", DbType.Int32, audio.GenreId);
            Database.AddInParameter(command, "@itunes_track_id", DbType.Int32, audio.ItunesTrackId);
            Database.AddInParameter(command, "@kind_type_id", DbType.Int32, audio.KindTypeId);
            Database.AddInParameter(command, "@name", DbType.String, audio.Name);
            Database.AddInParameter(command, "@total_time_string", DbType.String, audio.TotalTimeString);
            Database.AddInParameter(command, "@track_number", DbType.Int32, audio.TrackNumber);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Database.ExecuteNonQuery(command);
        }


        internal int Save(List<Audio> audioList, string updatedBy)
        {

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(audioList.GetType());
            serializer.Serialize(writer, audioList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_audio_ups");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }


        #endregion

    }

}
