using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JPL.Lib.MediaLibraryReader
{
    public class Track : IComparable<Track> 
    {
        private const string EMPTY_STRING = Constants.UNKNOWN_VALUE;
        private Dictionary<string, string> __initializerFields;

        private int __TrackId = 0;
        private string __Name = EMPTY_STRING;
        private string __Artist = EMPTY_STRING;
        private string __AlbumArtist = EMPTY_STRING;
        private string __Album = EMPTY_STRING;
        private string __Genre = EMPTY_STRING;
        private string __Kind = EMPTY_STRING;
        private int __Size = 0;
        private int __TotalTime = 0;
        private int __DiscNumber = 0;
        private int __DiscCount = 0;
        private int __TrackNumber = 0;
        private int __TrackCount = 0;
        private int __Year = 0;
        private DateTime __DateModified = Constants.NULL_DATE;
        private DateTime __DateAdded = Constants.NULL_DATE;
        private int __BitRate = 0;
        private int __SampleRate = 0;
        private int __PlayCount = 0;
        private int __PlayDate = 0;
        private DateTime __PlayDateUTC = Constants.NULL_DATE;
        private DateTime __ReleaseDate = Constants.NULL_DATE;
        private int __ArtworkCount = 0;
        private string __PersistentID = EMPTY_STRING;
        private string __TrackType = EMPTY_STRING;
        private bool __Purchased = false;
        private string __Location = EMPTY_STRING;
        private int __FileFolderCount = 0;
        private int __LibraryFolderCount = 0;


        public Track()
        {
        }

        public Track(Dictionary<string, string> fields)
        {
            __initializerFields = fields;
            this.InitializeFields();
        }

        public int TrackId
        {
            get
            {
                return __TrackId;
            }
            set
            {
                __TrackId = value;
            }
        }
        public string Name
        {
            get
            {
                return __Name;
            }
            set
            {
                __Name = value;
            }
        }
        public string Artist
        {
            get
            {
                return __Artist;
            }
            set
            {
                __Artist = value;
            }
        }
        public string AlbumArtist
        {
            get
            {
                return __AlbumArtist;
            }
            set
            {
                __AlbumArtist = value;
            }
        }
        public string Album
        {
            get
            {
                return __Album;
            }
            set
            {
                __Album = value;
            }
        }
        public string Genre
        {
            get
            {
                return __Genre;
            }
            set
            {
                __Genre = value;
            }
        }
        public string Kind
        {
            get
            {
                return __Kind;
            }
            set
            {
                __Kind = value;
            }
        }
        public int Size
        {
            get
            {
                return __Size;
            }
            set
            {
                __Size = value;
            }
        }
        public int TotalTime
        {
            get
            {
                return __TotalTime;
            }
            set
            {
                __TotalTime = value;
            }
        }
        public string TotalTimeString
        {
            get
            {
                StringBuilder time = new StringBuilder();
                if (TotalTime > 0)
                {
                    int Hours =     (int) ((double)TotalTime / (1000.0 * 60.0 * 60.0));
                    int Minutes =   (int) ((double)TotalTime % (1000.0 * 60.0 * 60.0) / (1000.0 * 60.0));
                    int Seconds =   (int) Math.Round((double)TotalTime % (1000.0 * 60.0 * 60.0) % (1000.0 * 60.0) / 1000.0);

                    if (Hours > 0)
                    {
                        time.Append(Hours.ToString());
                        time.Append(":");
                    }

                    if (Minutes > 9)
                    {
                        time.Append(Minutes.ToString());
                        time.Append(":");
                    }
                    else
                    {
                        time.Append("0");
                        time.Append(Minutes.ToString());
                        time.Append(":");
                    }

                    if (Seconds > 9)
                    {
                        time.Append(Seconds.ToString());
                    }
                    else 
                    {
                        time.Append("0");
                        time.Append(Seconds.ToString());
                    }
                }

                return time.ToString();
            }
            set
            {
                //do nothing, but must have for xml to serialize
            }
        }
        public int DiscNumber
        {
            get
            {
                return __DiscNumber;
            }
            set
            {
                __DiscNumber = value;
            }
        }
        public int DiscCount
        {
            get
            {
                return __DiscCount;
            }
            set
            {
                __DiscCount = value;
            }
        }
        public int TrackNumber
        {
            get
            {

                if (__TrackNumber != 0)
                {
                    return __TrackNumber;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                __TrackNumber = value;
            }
        }
        public int TrackCount
        {
            get
            {
                return __TrackCount;
            }
            set
            {
                __TrackCount = value;
            }
        }
        public int Year
        {
            get
            {
                return __Year;
            }
            set
            {
                __Year = value;
            }
        }
        public DateTime DateModified
        {
            get
            {
                return __DateModified;
            }
            set
            {
                __DateModified = value;
            }
        }
        public DateTime DateAdded
        {
            get
            {
                return __DateAdded;
            }
            set
            {
                __DateAdded = value;
            }
        }
        public int BitRate
        {
            get
            {
                return __BitRate;
            }
            set
            {
                __BitRate = value;
            }
        }
        public int SampleRate
        {
            get
            {
                return __SampleRate;
            }
            set
            {
                __SampleRate = value;
            }
        }
        public int PlayCount
        {
            get
            {
                return __PlayCount;
            }
            set
            {
                __PlayCount = value;
            }
        }
        public int PlayDate
        {
            get
            {
                return __PlayDate;
            }
            set
            {
                __PlayDate = value;
            }
        }
        public DateTime PlayDateUtc
        {
            get
            {
                return __PlayDateUTC;
            }
            set
            {
                __PlayDateUTC = value;
            }
        }
        public DateTime ReleaseDate
        {
            get
            {
                return __ReleaseDate;
            }
            set
            {
                __ReleaseDate = value;
            }
        }
        public int ArtworkCount
        {
            get
            {
                return __ArtworkCount;
            }
            set
            {
                __ArtworkCount = value;
            }
        }
        public string PersistentId
        {
            get
            {
                return __PersistentID;
            }
            set
            {
                __PersistentID = value;
            }
        }
        public string TrackType
        {
            get
            {
                return __TrackType;
            }
            set
            {
                __TrackType = value;
            }
        }
        public bool Purchased
        {
            get
            {
                return __Purchased;
            }
            set
            {
                __Purchased = value;
            }
        }
        public string Location
        {
            get
            {
                return __Location;
            }
            set
            {
                __Location = value;
            }
        }
        public int FileFolderCount
        {
            get
            {
                return __FileFolderCount;
            }
            set
            {
                __FileFolderCount = value;
            }
        }
        public int LibraryFolderCount
        {
            get
            {
                return __LibraryFolderCount;
            }
            set
            {
                __LibraryFolderCount = value;
            }
        }


        public int CompareTo(Track right)
        {
            if (right.TrackNumber < this.TrackNumber)
                return 1;

            if (right.TrackNumber > this.TrackNumber)
                return -1;

            return 0;
        }

        private void InitializeFields()
        {
            if (__initializerFields != null)
            {
                foreach (string key in __initializerFields.Keys)
                {
                    SetField(key, __initializerFields[key]);
                }
            }
        }

        private bool SetField(string key, string val)
        {
            bool status = false;
            //
            // remove any spaces in the key value to make valid property name
            //
            string k = key.Replace(" ", "").ToUpper();

            //
            // iterate through the properties to see if there is a match
            //
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach (PropertyInfo pi in props)
            {
                if (pi.Name.ToUpper().Equals(k))
                {
                    Type t = pi.PropertyType;
                    switch (t.ToString())
                    {
                        case "System.String":
                            pi.SetValue(this, val, null);
                            status = true;
                            break;

                        case "System.Int32":
                            int res = int.MaxValue;
                            if (int.TryParse(val, out res))
                            {
                                pi.SetValue(this, res, null);
                                status = true;
                            }
                            break;

                        case "System.DateTime":
                            DateTime dt = Constants.NULL_DATE;
                            if (DateTime.TryParse(val, out dt))
                            {
                                pi.SetValue(this, dt, null);
                                status = true;
                            }
                            break;
                    }
                }
            }

            return status;
        }
        
    }

}