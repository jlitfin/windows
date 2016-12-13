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
    public class TrackRepository : RepositoryBase
    {
        #region private members

        private Dictionary<int, Track> __cache;

        #endregion

        #region public accessors

        #endregion

        #region constructor

        public TrackRepository()
        {
            __cache = new Dictionary<int, Track>();
            List<Track> list = Read();
            foreach (Track t in list)
            {
                if (!__cache.ContainsKey(t.TrackId))
                {
                    __cache.Add(t.TrackId, t);
                }
            }
        }

        public List<Track> Tracks
        {
            get
            {
                if (__cache != null)
                {
                    return __cache.Values.ToList<Track>();
                }

                return null;
            }
        }


        #endregion

        #region public methods

        public int GetTrackId(Track track)
        {
            if (__cache.ContainsKey(track.TrackId))
            {
                //
                // update any fields in case cache is pushed to DB
                //
                __cache[track.TrackId].Name = track.Name;
                __cache[track.TrackId].Artist = track.Artist;
                __cache[track.TrackId].AlbumArtist = track.AlbumArtist;
                __cache[track.TrackId].Album = track.Album;
                __cache[track.TrackId].Genre = track.Genre;
                __cache[track.TrackId].Kind = track.Kind;
                __cache[track.TrackId].Size = track.Size;
                __cache[track.TrackId].TotalTime = track.TotalTime;
                __cache[track.TrackId].DiscNumber = track.DiscNumber;
                __cache[track.TrackId].DiscCount = track.DiscCount;
                __cache[track.TrackId].TrackNumber = track.TrackNumber;
                __cache[track.TrackId].TrackCount = track.TrackCount;
                __cache[track.TrackId].Year = track.Year;
                __cache[track.TrackId].DateModified = track.DateModified;
                __cache[track.TrackId].DateAdded = track.DateAdded;
                __cache[track.TrackId].BitRate = track.BitRate;
                __cache[track.TrackId].SampleRate = track.SampleRate;
                __cache[track.TrackId].PlayCount = track.PlayCount;
                __cache[track.TrackId].PlayDate = track.PlayDate;
                __cache[track.TrackId].PlayDateUtc = track.PlayDateUtc;
                __cache[track.TrackId].ReleaseDate = track.ReleaseDate;
                __cache[track.TrackId].ArtworkCount = track.ArtworkCount;
                __cache[track.TrackId].PersistentId = track.PersistentId;
                __cache[track.TrackId].TrackType = track.TrackType;
                __cache[track.TrackId].Purchased = track.Purchased;
                __cache[track.TrackId].Location = track.Location;
                __cache[track.TrackId].FileFolderCount = track.FileFolderCount;
                __cache[track.TrackId].LibraryFolderCount = track.LibraryFolderCount;
            }
            else
            {
                //
                // adding new
                //
                track.TrackId = WriteNew(track, Environment.UserName);
                __cache.Add(track.TrackId, track);
            }
            //
            // return requested id
            //
            return __cache[track.TrackId].TrackId;
        }

        public List<Track> Read()
        {
            List<Track> list = new List<Track>();
            DbCommand command = Database.GetStoredProcCommand("prc_track_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    Track track = new Track();
                    list.Add(Load(dr, track));
                }
            }

            return list;
        }

        public Track Read(int trackId)
        {
            Track track = new Track();
            DbCommand command = Database.GetStoredProcCommand("prc_track_sel_by_id");
            //
            // Optional Parameters:
            //
            Database.AddInParameter(command, "@pta_track_id", DbType.Int32, trackId);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    track = Load(dr, track);
                }
            }

            return track;
        }

        public int Write(Track track, string updatedBy)
        {
            return Save(track, updatedBy);
        }

        public int WriteNew(Track track, string updatedBy)
        {
            return Add(track, updatedBy);
        }

        public int Write(List<Track> trackList, string updatedBy)
        {
            return Save(trackList, updatedBy);
        }

        #endregion

        #region internal methods

        protected Track Load(IDataReader dr, Track track)
        {
            if (ColumnExists(dr, "track_id"))
            {
                if (dr["track_id"] == DBNull.Value)
                {
                    track.TrackId = 0;
                }
                else
                {
                    track.TrackId = Convert.ToInt32(dr["track_id"].ToString());
                }
            }
            if (ColumnExists(dr, "name"))
            {
                if (dr["name"] == DBNull.Value)
                {
                    track.Name = string.Empty;
                }
                else
                {
                    track.Name = Convert.ToString(dr["name"].ToString());
                }
            }
            if (ColumnExists(dr, "artist"))
            {
                if (dr["artist"] == DBNull.Value)
                {
                    track.Artist = string.Empty;
                }
                else
                {
                    track.Artist = Convert.ToString(dr["artist"].ToString());
                }
            }
            if (ColumnExists(dr, "album_artist"))
            {
                if (dr["album_artist"] == DBNull.Value)
                {
                    track.AlbumArtist = string.Empty;
                }
                else
                {
                    track.AlbumArtist = Convert.ToString(dr["album_artist"].ToString());
                }
            }
            if (ColumnExists(dr, "album"))
            {
                if (dr["album"] == DBNull.Value)
                {
                    track.Album = string.Empty;
                }
                else
                {
                    track.Album = Convert.ToString(dr["album"].ToString());
                }
            }
            if (ColumnExists(dr, "genre"))
            {
                if (dr["genre"] == DBNull.Value)
                {
                    track.Genre = string.Empty;
                }
                else
                {
                    track.Genre = Convert.ToString(dr["genre"].ToString());
                }
            }
            if (ColumnExists(dr, "kind"))
            {
                if (dr["kind"] == DBNull.Value)
                {
                    track.Kind = string.Empty;
                }
                else
                {
                    track.Kind = Convert.ToString(dr["kind"].ToString());
                }
            }
            if (ColumnExists(dr, "size"))
            {
                if (dr["size"] == DBNull.Value)
                {
                    track.Size = 0;
                }
                else
                {
                    track.Size = Convert.ToInt32(dr["size"].ToString());
                }
            }
            if (ColumnExists(dr, "total_time"))
            {
                if (dr["total_time"] == DBNull.Value)
                {
                    track.TotalTime = 0;
                }
                else
                {
                    track.TotalTime = Convert.ToInt32(dr["total_time"].ToString());
                }
            }
            if (ColumnExists(dr, "disc_number"))
            {
                if (dr["disc_number"] == DBNull.Value)
                {
                    track.DiscNumber = 0;
                }
                else
                {
                    track.DiscNumber = Convert.ToInt32(dr["disc_number"].ToString());
                }
            }
            if (ColumnExists(dr, "disc_count"))
            {
                if (dr["disc_count"] == DBNull.Value)
                {
                    track.DiscCount = 0;
                }
                else
                {
                    track.DiscCount = Convert.ToInt32(dr["disc_count"].ToString());
                }
            }
            if (ColumnExists(dr, "track_number"))
            {
                if (dr["track_number"] == DBNull.Value)
                {
                    track.TrackNumber = 0;
                }
                else
                {
                    track.TrackNumber = Convert.ToInt32(dr["track_number"].ToString());
                }
            }
            if (ColumnExists(dr, "track_count"))
            {
                if (dr["track_count"] == DBNull.Value)
                {
                    track.TrackCount = 0;
                }
                else
                {
                    track.TrackCount = Convert.ToInt32(dr["track_count"].ToString());
                }
            }
            if (ColumnExists(dr, "year"))
            {
                if (dr["year"] == DBNull.Value)
                {
                    track.Year = 0;
                }
                else
                {
                    track.Year = Convert.ToInt32(dr["year"].ToString());
                }
            }
            if (ColumnExists(dr, "date_modified"))
            {
                if (dr["date_modified"] == DBNull.Value)
                {
                    track.DateModified = DateTime.MinValue;
                }
                else
                {
                    track.DateModified = Convert.ToDateTime(dr["date_modified"].ToString());
                }
            }
            if (ColumnExists(dr, "date_added"))
            {
                if (dr["date_added"] == DBNull.Value)
                {
                    track.DateAdded = DateTime.MinValue;
                }
                else
                {
                    track.DateAdded = Convert.ToDateTime(dr["date_added"].ToString());
                }
            }
            if (ColumnExists(dr, "bit_rate"))
            {
                if (dr["bit_rate"] == DBNull.Value)
                {
                    track.BitRate = 0;
                }
                else
                {
                    track.BitRate = Convert.ToInt32(dr["bit_rate"].ToString());
                }
            }
            if (ColumnExists(dr, "sample_rate"))
            {
                if (dr["sample_rate"] == DBNull.Value)
                {
                    track.SampleRate = 0;
                }
                else
                {
                    track.SampleRate = Convert.ToInt32(dr["sample_rate"].ToString());
                }
            }
            if (ColumnExists(dr, "play_count"))
            {
                if (dr["play_count"] == DBNull.Value)
                {
                    track.PlayCount = 0;
                }
                else
                {
                    track.PlayCount = Convert.ToInt32(dr["play_count"].ToString());
                }
            }
            if (ColumnExists(dr, "play_date"))
            {
                if (dr["play_date"] == DBNull.Value)
                {
                    track.PlayDate = 0;
                }
                else
                {
                    track.PlayDate = Convert.ToInt32(dr["play_date"].ToString());
                }
            }
            if (ColumnExists(dr, "play_date_utc"))
            {
                if (dr["play_date_utc"] == DBNull.Value)
                {
                    track.PlayDateUtc = DateTime.MinValue;
                }
                else
                {
                    track.PlayDateUtc = Convert.ToDateTime(dr["play_date_utc"].ToString());
                }
            }
            if (ColumnExists(dr, "release_date"))
            {
                if (dr["release_date"] == DBNull.Value)
                {
                    track.ReleaseDate = DateTime.MinValue;
                }
                else
                {
                    track.ReleaseDate = Convert.ToDateTime(dr["release_date"].ToString());
                }
            }
            if (ColumnExists(dr, "artwork_count"))
            {
                if (dr["artwork_count"] == DBNull.Value)
                {
                    track.ArtworkCount = 0;
                }
                else
                {
                    track.ArtworkCount = Convert.ToInt32(dr["artwork_count"].ToString());
                }
            }
            if (ColumnExists(dr, "persistent_id"))
            {
                if (dr["persistent_id"] == DBNull.Value)
                {
                    track.PersistentId = string.Empty;
                }
                else
                {
                    track.PersistentId = Convert.ToString(dr["persistent_id"].ToString());
                }
            }
            if (ColumnExists(dr, "track_type"))
            {
                if (dr["track_type"] == DBNull.Value)
                {
                    track.TrackType = string.Empty;
                }
                else
                {
                    track.TrackType = Convert.ToString(dr["track_type"].ToString());
                }
            }
            if (ColumnExists(dr, "purchased"))
            {
                if (dr["purchased"] == DBNull.Value)
                {
                    track.Purchased = false;
                }
                else
                {
                    track.Purchased = Convert.ToBoolean(dr["purchased"].ToString());
                }
            }
            if (ColumnExists(dr, "location"))
            {
                if (dr["location"] == DBNull.Value)
                {
                    track.Location = string.Empty;
                }
                else
                {
                    track.Location = Convert.ToString(dr["location"].ToString());
                }
            }
            if (ColumnExists(dr, "file_folder_count"))
            {
                if (dr["file_folder_count"] == DBNull.Value)
                {
                    track.FileFolderCount = 0;
                }
                else
                {
                    track.FileFolderCount = Convert.ToInt32(dr["file_folder_count"].ToString());
                }
            }
            if (ColumnExists(dr, "library_folder_count"))
            {
                if (dr["library_folder_count"] == DBNull.Value)
                {
                    track.LibraryFolderCount = 0;
                }
                else
                {
                    track.LibraryFolderCount = Convert.ToInt32(dr["library_folder_count"].ToString());
                }
            }


            return track;
        }

        internal int Add(Track track, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_track_ins");
            Database.AddInParameter(command, "@track_id", DbType.Int32, track.TrackId);
            Database.AddInParameter(command, "@name", DbType.String, track.Name);
            Database.AddInParameter(command, "@artist", DbType.String, track.Artist);
            Database.AddInParameter(command, "@album_artist", DbType.String, track.AlbumArtist);
            Database.AddInParameter(command, "@album", DbType.String, track.Album);
            Database.AddInParameter(command, "@genre", DbType.String, track.Genre);
            Database.AddInParameter(command, "@kind", DbType.String, track.Kind);
            Database.AddInParameter(command, "@size", DbType.Int32, track.Size);
            Database.AddInParameter(command, "@total_time", DbType.Int32, track.TotalTime);
            Database.AddInParameter(command, "@total_time_string", DbType.String, track.TotalTimeString);
            Database.AddInParameter(command, "@disc_number", DbType.Int32, track.DiscNumber);
            Database.AddInParameter(command, "@disc_count", DbType.Int32, track.DiscCount);
            Database.AddInParameter(command, "@track_number", DbType.Int32, track.TrackNumber);
            Database.AddInParameter(command, "@track_count", DbType.Int32, track.TrackCount);
            Database.AddInParameter(command, "@year", DbType.Int32, track.Year);
            Database.AddInParameter(command, "@date_modified", DbType.DateTime, track.DateModified);
            Database.AddInParameter(command, "@date_added", DbType.DateTime, track.DateAdded);
            Database.AddInParameter(command, "@bit_rate", DbType.Int32, track.BitRate);
            Database.AddInParameter(command, "@sample_rate", DbType.Int32, track.SampleRate);
            Database.AddInParameter(command, "@play_count", DbType.Int32, track.PlayCount);
            Database.AddInParameter(command, "@play_date", DbType.Int32, track.PlayDate);
            Database.AddInParameter(command, "@play_date_utc", DbType.DateTime, track.PlayDateUtc);
            Database.AddInParameter(command, "@release_date", DbType.DateTime, track.ReleaseDate);
            Database.AddInParameter(command, "@artwork_count", DbType.Int32, track.ArtworkCount);
            Database.AddInParameter(command, "@persistent_id", DbType.String, track.PersistentId);
            Database.AddInParameter(command, "@track_type", DbType.String, track.TrackType);
            Database.AddInParameter(command, "@purchased", DbType.Boolean, track.Purchased);
            Database.AddInParameter(command, "@location", DbType.String, track.Location);
            Database.AddInParameter(command, "@file_folder_count", DbType.Int32, track.FileFolderCount);
            Database.AddInParameter(command, "@library_folder_count", DbType.Int32, track.LibraryFolderCount);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Convert.ToInt32(Database.ExecuteScalar(command));
        }

        internal int Save(Track track, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_track_upd");
            Database.AddInParameter(command, "@track_id", DbType.Int32, track.TrackId);
            Database.AddInParameter(command, "@name", DbType.String, track.Name);
            Database.AddInParameter(command, "@artist", DbType.String, track.Artist);
            Database.AddInParameter(command, "@album_artist", DbType.String, track.AlbumArtist);
            Database.AddInParameter(command, "@album", DbType.String, track.Album);
            Database.AddInParameter(command, "@genre", DbType.String, track.Genre);
            Database.AddInParameter(command, "@kind", DbType.String, track.Kind);
            Database.AddInParameter(command, "@size", DbType.Int32, track.Size);
            Database.AddInParameter(command, "@total_time", DbType.Int32, track.TotalTime);
            Database.AddInParameter(command, "@total_time_string", DbType.String, track.TotalTimeString);
            Database.AddInParameter(command, "@disc_number", DbType.Int32, track.DiscNumber);
            Database.AddInParameter(command, "@disc_count", DbType.Int32, track.DiscCount);
            Database.AddInParameter(command, "@track_number", DbType.Int32, track.TrackNumber);
            Database.AddInParameter(command, "@track_count", DbType.Int32, track.TrackCount);
            Database.AddInParameter(command, "@year", DbType.Int32, track.Year);
            Database.AddInParameter(command, "@date_modified", DbType.DateTime, track.DateModified);
            Database.AddInParameter(command, "@date_added", DbType.DateTime, track.DateAdded);
            Database.AddInParameter(command, "@bit_rate", DbType.Int32, track.BitRate);
            Database.AddInParameter(command, "@sample_rate", DbType.Int32, track.SampleRate);
            Database.AddInParameter(command, "@play_count", DbType.Int32, track.PlayCount);
            Database.AddInParameter(command, "@play_date", DbType.Int32, track.PlayDate);
            Database.AddInParameter(command, "@play_date_utc", DbType.DateTime, track.PlayDateUtc);
            Database.AddInParameter(command, "@release_date", DbType.DateTime, track.ReleaseDate);
            Database.AddInParameter(command, "@artwork_count", DbType.Int32, track.ArtworkCount);
            Database.AddInParameter(command, "@persistent_id", DbType.String, track.PersistentId);
            Database.AddInParameter(command, "@track_type", DbType.String, track.TrackType);
            Database.AddInParameter(command, "@purchased", DbType.Boolean, track.Purchased);
            Database.AddInParameter(command, "@location", DbType.String, track.Location);
            Database.AddInParameter(command, "@file_folder_count", DbType.Int32, track.FileFolderCount);
            Database.AddInParameter(command, "@library_folder_count", DbType.Int32, track.LibraryFolderCount);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Database.ExecuteNonQuery(command);
        }

        internal int Save(List<Track> trackList, string updatedBy)
        {

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(trackList.GetType());
            serializer.Serialize(writer, trackList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_track_ups");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }


        #endregion

    }

}
