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
    public class VideoRepository : RepositoryBase
    {
        #region private members

        private Dictionary<int, Video> __cache;
        private Dictionary<int, Video> __cacheExt;

        #endregion

        #region public accessors

        public List<Video> VideoList
        {
            get
            {
                return __cache.Values.ToList<Video>();
            }
        }

        #endregion


        #region constructor

        public VideoRepository()
        {
            __cache = new Dictionary<int, Video>();
            __cacheExt = new Dictionary<int, Video>();
            List<Video> list = Read();
            foreach (Video v in list)
            {
                if (!__cache.ContainsKey(v.VideoId))
                {
                    __cache.Add(v.VideoId, v);
                }
                if (v.ItunesTrackId != 0 && !__cacheExt.ContainsKey(v.ItunesTrackId))
                {
                    __cacheExt.Add(v.ItunesTrackId, v);
                }
            }
        }

        #endregion

        #region public methods

        public int GetVideoId(int itunesTrackId)
        {
            if (__cacheExt.ContainsKey(itunesTrackId))
            {
                return __cacheExt[itunesTrackId].VideoId;
            }

            return 0;
        }

        public Video Read(int videoId)
        {
            if (__cache.ContainsKey(videoId))
            {
                return __cache[videoId];
            }

            return new Video();
        }

        public Video ReadExternal(int itunesTrackId)
        {
            if (__cacheExt.ContainsKey(itunesTrackId))
            {
                return __cacheExt[itunesTrackId];
            }

            return null;
        }

        public int Write(Video video, string updatedBy)
        {
            return Save(video, updatedBy);
        }

        public int WriteNew(Video video, string updatedBy)
        {
            return Add(video, updatedBy);
        }

        public int Write(List<Video> videoList, string updatedBy)
        {
            return Save(videoList, updatedBy);
        }

        #endregion

        #region internal methods

        private List<Video> Read()
        {
            List<Video> list = new List<Video>();
            DbCommand command = Database.GetStoredProcCommand("prc_video_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    Video video = new Video();
                    list.Add(Load(dr, video));
                }
            }

            return list;
        }

        protected Video Load(IDataReader dr, Video video)
        {
            if (ColumnExists(dr, "video_id"))
            {
                if (dr["video_id"] == DBNull.Value)
                {
                    video.VideoId = 0;
                }
                else
                {
                    video.VideoId = Convert.ToInt32(dr["video_id"].ToString());
                }
            }
            if (ColumnExists(dr, "director_id"))
            {
                if (dr["director_id"] == DBNull.Value)
                {
                    video.DirectorId = 0;
                }
                else
                {
                    video.DirectorId = Convert.ToInt32(dr["director_id"].ToString());
                }
            }
            if (ColumnExists(dr, "album_id"))
            {
                if (dr["album_id"] == DBNull.Value)
                {
                    video.AlbumId = 0;
                }
                else
                {
                    video.AlbumId = Convert.ToInt32(dr["album_id"].ToString());
                }
            }
            if (ColumnExists(dr, "genre_id"))
            {
                if (dr["genre_id"] == DBNull.Value)
                {
                    video.GenreId = 0;
                }
                else
                {
                    video.GenreId = Convert.ToInt32(dr["genre_id"].ToString());
                }
            }
            if (ColumnExists(dr, "itunes_track_id"))
            {
                if (dr["itunes_track_id"] == DBNull.Value)
                {
                    video.ItunesTrackId = 0;
                }
                else
                {
                    video.ItunesTrackId = Convert.ToInt32(dr["itunes_track_id"].ToString());
                }
            }
            if (ColumnExists(dr, "kind_type_id"))
            {
                if (dr["kind_type_id"] == DBNull.Value)
                {
                    video.KindTypeId = 0;
                }
                else
                {
                    video.KindTypeId = Convert.ToInt32(dr["kind_type_id"].ToString());
                }
            }
            if (ColumnExists(dr, "name"))
            {
                if (dr["name"] == DBNull.Value)
                {
                    video.Name = string.Empty;
                }
                else
                {
                    video.Name = Convert.ToString(dr["name"].ToString());
                }
            }
            if (ColumnExists(dr, "total_time_string"))
            {
                if (dr["total_time_string"] == DBNull.Value)
                {
                    video.TotalTimeString = string.Empty;
                }
                else
                {
                    video.TotalTimeString = Convert.ToString(dr["total_time_string"].ToString());
                }
            }


            return video;
        }

        internal int Add(Video video, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_video_ins");
            Database.AddInParameter(command, "@video_id", DbType.Int32, video.VideoId);
            Database.AddInParameter(command, "@director_id", DbType.Int32, video.DirectorId);
            Database.AddInParameter(command, "@album_id", DbType.Int32, video.AlbumId);
            Database.AddInParameter(command, "@genre_id", DbType.Int32, video.GenreId);
            Database.AddInParameter(command, "@itunes_track_id", DbType.Int32, video.ItunesTrackId);
            Database.AddInParameter(command, "@kind_type_id", DbType.Int32, video.KindTypeId);
            Database.AddInParameter(command, "@name", DbType.String, video.Name);
            Database.AddInParameter(command, "@total_time_string", DbType.String, video.TotalTimeString);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            int id = Convert.ToInt32(Database.ExecuteScalar(command));
            if (!__cache.ContainsKey(id))
            {
                __cache.Add(id, video);
            }

            return id;
        }

        internal int Save(Video video, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_video_upd");
            Database.AddInParameter(command, "@video_id", DbType.Int32, video.VideoId);
            Database.AddInParameter(command, "@director_id", DbType.Int32, video.DirectorId);
            Database.AddInParameter(command, "@album_id", DbType.Int32, video.AlbumId);
            Database.AddInParameter(command, "@genre_id", DbType.Int32, video.GenreId);
            Database.AddInParameter(command, "@itunes_track_id", DbType.Int32, video.ItunesTrackId);
            Database.AddInParameter(command, "@kind_type_id", DbType.Int32, video.KindTypeId);
            Database.AddInParameter(command, "@name", DbType.String, video.Name);
            Database.AddInParameter(command, "@total_time_string", DbType.String, video.TotalTimeString);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);

            int count = Database.ExecuteNonQuery(command);
            if (count > 0)
            {
                if (__cache.ContainsKey(video.VideoId))
                {
                    __cache[video.VideoId] = video;
                }
            }

            return count;
        }

        internal int Save(List<Video> videoList, string updatedBy)
        {

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(videoList.GetType());
            serializer.Serialize(writer, videoList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_video_ups");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }

        #endregion

    }

}
