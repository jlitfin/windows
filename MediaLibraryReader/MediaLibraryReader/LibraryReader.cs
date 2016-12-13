using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace JPL.Lib.MediaLibraryReader
{
    public class LibraryReader
    {
        private string XMLTS = "!!-XML_TERMINATE_SEGMENT-!!";
        private string __fileName;
        private Dictionary<string, Dictionary<string, string>> __keyValPairs;
        private StringBuilder __debugString = new StringBuilder();

        #region Constructor

        public LibraryReader(string fileName)
        {
            __fileName = fileName;
            __keyValPairs = ReadLibrary();
        }

        #endregion

        #region Public Members

        public string DebugString
        {
            get
            {
                return __debugString.ToString();
            }
        }

        #endregion

        #region Public Methods

        public List<Track> BuildTracks()
        {
            List<Track> list = new List<Track>();
            foreach (KeyValuePair<string, Dictionary<string, string>> kv in __keyValPairs)
            {
                Track t = new Track(kv.Value);
                list.Add(t);
            }

            return list;
        }

        public void TransformToDb()
        {
            AlbumRepository albumRepository = new AlbumRepository();
            ArtistRepository artistRepository = new ArtistRepository();
            GenreTypeRepository genreTypeRepository = new GenreTypeRepository();
            KindTypeRepository kindTypeRepository = new KindTypeRepository();
            AlbumTrackRepository albumTrackRepository = new AlbumTrackRepository();

            //
            // build and save / update tracks RAW
            //
            List<Track> tracks = BuildTracks();
            TrackRepository trackRepository = new TrackRepository();
            trackRepository.Write(tracks, Environment.UserName);

            //List<Video> videoList = new List<Video>();
            //List<Audio> audioList = new List<Audio>();

            List<AlbumTrack> albumTrackList = new List<AlbumTrack>();

            foreach (Track t in tracks)
            {
                Console.WriteLine("Adding Track: " + t.Name);
                KindType kindType = new KindType();
                kindType.KindTypeText = t.Kind;
                kindType = kindTypeRepository.GetKindType(kindType);

                AlbumTrack albumTrack = new AlbumTrack();
                albumTrack.AlbumTrackId = albumTrackRepository.GetAlbumTrackId(t.TrackId);

                Album album = new Album();
                album.Name = t.Album.Equals(Constants.UNKNOWN_VALUE) ? t.Name : t.Album;
                album.Year = t.Year;
                album.AlbumId = albumRepository.GetAlbumId(album);
                albumTrack.AlbumId = album.AlbumId;

                Artist artist = new Artist();
                artist.Name = t.Artist;
                artist.ArtistId = artistRepository.GetArtistId(artist);
                albumTrack.ArtistId = artist.ArtistId;

                GenreType genre = new GenreType();
                genre.GenreTypeText = t.Genre;
                genre = genreTypeRepository.GetGenreType(genre);
                albumTrack.GenreId = genre.GenreTypeId;

                albumTrack.ItunesTrackId = t.TrackId;
                albumTrack.KindTypeId = kindType.KindTypeId;
                albumTrack.Name = t.Name;
                albumTrack.TotalTimeString = t.TotalTimeString;
                albumTrack.TrackNumber = t.TrackNumber;
                albumTrack.PersistentId = t.PersistentId;

                
                albumTrackList.Add(albumTrack);

                
            //    if (kindType.KindTypeMap.Equals("video"))
            //    {
            //        Video video = new Video();

            //        Album album = new Album();
            //        album.Name = t.Album.Equals(Constants.UNKNOWN_VALUE) ? t.Name : t.Album;
            //        album.Year = t.Year;
            //        album.AlbumId = albumRepository.GetAlbumId(album);
            //        video.AlbumId = album.AlbumId;

            //        Artist artist = new Artist();
            //        artist.Name = t.Artist;
            //        artist.ArtistId = artistRepository.GetArtistId(artist);
            //        video.DirectorId = artist.ArtistId;

            //        GenreType genre = new GenreType();
            //        genre.GenreTypeText = t.Genre;
            //        genre = genreTypeRepository.GetGenreType(genre);
            //        video.GenreId = genre.GenreTypeId;

            //        video.ItunesTrackId = t.TrackId;
            //        video.KindTypeId = kindType.KindTypeId;
            //        video.Name = t.Name;
            //        video.TotalTimeString = t.TotalTimeString;

            //        video.VideoId = videoRepository.GetVideoId(t.TrackId);
            //        videoList.Add(video);
            //    }
            //    else
            //    {
            //        Audio audio = new Audio();

            //        Album album = new Album();
            //        album.Name = t.Album;
            //        album.Year = t.Year;
            //        album.AlbumId = albumRepository.GetAlbumId(album);
            //        audio.AlbumId = album.AlbumId;

            //        Artist artist = new Artist();
            //        artist.Name = t.Artist;
            //        artist.ArtistId = artistRepository.GetArtistId(artist);
            //        audio.ArtistId = artist.ArtistId;

            //        GenreType genre = new GenreType();
            //        genre.GenreTypeText = t.Genre;
            //        genre = genreTypeRepository.GetGenreType(genre);
            //        audio.GenreId = genre.GenreTypeId;

            //        audio.ItunesTrackId = t.TrackId;
            //        audio.KindTypeId = kindType.KindTypeId;
            //        audio.Name = t.Name;
            //        audio.TrackNumber = t.TrackNumber;
            //        audio.TotalTimeString = t.TotalTimeString;

            //        audio.AudioId = audioRepository.GetAudioId(t.TrackNumber);
            //        audioList.Add(audio);
            //    }

            }

            //
            // update audio / video tables
            //
            //audioRepository.Write(audioList, Environment.UserName);
            //videoRepository.Write(videoList, Environment.UserName);

            albumTrackRepository.Write(albumTrackList, Environment.UserName);

        }

        #endregion

        #region Private Methods

        private string GetXMLValue(XmlTextReader r)
        {
            string ret = XMLTS;

            //
            // expect an xml element open, a text value, and a close
            // and return the text value
            //
            r.Read();
            while (r.NodeType == XmlNodeType.Whitespace)
            {
                r.Read();
            }

            if (r.NodeType == XmlNodeType.Element)
            {
                r.Read();
                if (r.NodeType == XmlNodeType.Text)
                {
                    ret = r.Value;
#if DEBUG
                    __debugString.AppendLine(r.Value.ToString());
#endif
                    r.Read();
                    if (r.NodeType == XmlNodeType.EndElement)
                    {
                        return ret;
                    }
                }
            }

            return ret;
        }

        private Dictionary<string, Dictionary<string, string>> ReadLibrary()
        {
            XmlTextReader reader = new XmlTextReader(__fileName);
            Console.WriteLine("Reading File: " + __fileName);
            Dictionary<string, Dictionary<string, string>> keyValuePairs = new Dictionary<string, Dictionary<string, string>>();

            int elementDepth = 0;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text && reader.Value == "Tracks")
                {
                    //
                    // set baseline depth
                    //
                    elementDepth++;

                    //
                    // read end of tracks text element
                    //
                    reader.Read();

                    //
                    // read outermost dict for tracks listing
                    //
                    reader.Read();
                    reader.Read();

                    //
                    // next element is key for track dict
                    //
                    string currentKey = string.Empty;
                    while (reader.Read() && elementDepth > 0)
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element: // The node is an element.
                                elementDepth++;
                                if (reader.Name == "key")
                                {
                                    reader.Read();
                                    string key = reader.Value;
                                    if (!keyValuePairs.ContainsKey(key))
                                    {
                                        currentKey = key;
                                        keyValuePairs.Add(key, new Dictionary<string, string>());
                                    }

                                    //
                                    // read the element end
                                    //
                                    reader.Read();
                                    elementDepth--;
                                }
                                else if (reader.Name == "dict")
                                {
                                    //
                                    // if this is a "dict" element, go and get key value pairs until
                                    // the dict is ended.
                                    //
                                    if (keyValuePairs.ContainsKey(currentKey))
                                    {
                                        Dictionary<string, string> currentDict = keyValuePairs[currentKey];
                                        do
                                        {
                                            string key = GetXMLValue(reader);
                                            if (key == XMLTS)
                                            {
                                                elementDepth--;
                                                continue;
                                            }

                                            string value = GetXMLValue(reader);
                                            currentDict.Add(key, value);
                                        }
                                        while (elementDepth > 1);

                                    }
                                    else
                                    {
                                        throw new Exception("Unexpected key defined: " + currentKey);
                                    }
                                }
                                break;
                            case XmlNodeType.Text:
                                break;
                            case XmlNodeType.EndElement:
                                elementDepth--;
                                break;
                        }
                    }
                    break;

                }
            }

            reader.Close();

            return keyValuePairs;

        }

        #endregion

    }

}
