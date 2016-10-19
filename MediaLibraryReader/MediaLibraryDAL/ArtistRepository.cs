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
    public class ArtistRepository : RepositoryBase
    {
        #region private members

        private Dictionary<string, Artist> __cache;
        private Dictionary<int, Artist> __cacheOpt;

        #endregion

        #region public accessors

        public List<Artist> ArtistList
        {
            get
            {
                return __cache.Values.ToList<Artist>();
            }
            set
            {
                // do nothing
            }
        }

        #endregion


        #region constructor

        public ArtistRepository()
        {
            __cache = new Dictionary<string, Artist>();
            __cacheOpt = new Dictionary<int, Artist>();
            List<Artist> list = Read();
            foreach (Artist a in list)
            {
                if (!__cache.ContainsKey(a.Name))
                {
                    __cache.Add(a.Name, a);
                }

                if (!__cacheOpt.ContainsKey(a.ArtistId))
                {
                    __cacheOpt.Add(a.ArtistId, a);
                }

            }
        }

        #endregion

        #region public methods

        public int GetArtistId(Artist artist)
        {
            if (__cache.ContainsKey(artist.Name))
            {
                return __cache[artist.Name].ArtistId;
            }
            else
            {
                //
                // adding new
                //
                artist.ArtistId = WriteNew(artist, Environment.UserName);
                __cache.Add(artist.Name, artist);
                __cacheOpt.Add(artist.ArtistId, artist);
            }
            //
            // return requested id
            //
            return artist.ArtistId;
        }


        public List<Artist> Read()
        {
            List<Artist> list = new List<Artist>();
            DbCommand command = Database.GetStoredProcCommand("prc_artist_sel");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    Artist artist = new Artist();
                    list.Add(Load(dr, artist));
                }
            }

            return list;
        }

        public Artist Read(int artistId)
        {
            if (__cacheOpt.ContainsKey(artistId))
            {
                return __cacheOpt[artistId];
            }

            return new Artist();
        }

        public Artist Read(string artistName)
        {
            if (__cache.ContainsKey(artistName))
            {
                return __cache[artistName];
            }

            return null;
        }


        public int Write(Artist artist, string updatedBy)
        {
            return Save(artist, updatedBy);
        }


        public int WriteNew(Artist artist, string updatedBy)
        {
            return Add(artist, updatedBy);
        }


        public int Write(List<Artist> artistList, string updatedBy)
        {
            return Save(artistList, updatedBy);
        }


        #endregion

        #region internal methods

        protected Artist Load(IDataReader dr, Artist artist)
        {
            if (ColumnExists(dr, "artist_id"))
            {
                if (dr["artist_id"] == DBNull.Value)
                {
                    artist.ArtistId = 0;
                }
                else
                {
                    artist.ArtistId = Convert.ToInt32(dr["artist_id"].ToString());
                }
            }
            if (ColumnExists(dr, "base_name"))
            {
                if (dr["base_name"] == DBNull.Value)
                {
                    artist.BaseName = string.Empty;
                }
                else
                {
                    artist.BaseName = Convert.ToString(dr["base_name"].ToString());
                }
            }
            if (ColumnExists(dr, "name"))
            {
                if (dr["name"] == DBNull.Value)
                {
                    artist.Name = string.Empty;
                }
                else
                {
                    artist.Name = Convert.ToString(dr["name"].ToString());
                }
            }


            return artist;
        }


        internal int Add(Artist artist, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_artist_ins");
            Database.AddInParameter(command, "@artist_id", DbType.Int32, artist.ArtistId);
            Database.AddInParameter(command, "@base_name", DbType.String, artist.BaseName);
            Database.AddInParameter(command, "@name", DbType.String, artist.Name);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Convert.ToInt32(Database.ExecuteScalar(command));
        }


        internal int Save(Artist artist, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_artist_upd");
            Database.AddInParameter(command, "@artist_id", DbType.Int32, artist.ArtistId);
            Database.AddInParameter(command, "@base_name", DbType.String, artist.BaseName);
            Database.AddInParameter(command, "@name", DbType.String, artist.Name);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Database.ExecuteNonQuery(command);
        }


        internal int Save(List<Artist> artistList, string updatedBy)
        {

            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(artistList.GetType());
            serializer.Serialize(writer, artistList);
            string xml = writer.ToString();
            DbCommand command = Database.GetStoredProcCommand("prc_artist_ups");
            Database.AddInParameter(command, "@xml_list", DbType.String, xml);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);


            return Database.ExecuteNonQuery(command);
        }


        #endregion

    }

}
