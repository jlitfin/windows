using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;

namespace ObjectModel
{
    public class Photo
    {
        private string  __description;
        private string  __displayName;
        private string  __path;
        private bool    __public;

        private ExifReader          __exifReader;
        private List<string> __keyWords;
        private List<PhotoProperty> __properties;

        public Photo(string path)
        {
            __path = path;
        }

        #region Public Methods

        public bool OpenPhoto()
        {
            if (__exifReader == null)
            {
                __exifReader = new ExifReader(__path);
            }

            Type type = this.GetType();
            PropertyInfo[] props = type.GetProperties();
            __properties = new List<PhotoProperty>();

            for (int i = 0; i < props.Length; ++i)
            {
                if (props[i].PropertyType == typeof(System.String))
                {
                    PhotoProperty pp = new PhotoProperty(this);
                    pp.PropertyName = props[i].Name;
                    pp.PropertyValue = props[i].GetValue(this, null) as string;
                    __properties.Add(pp);
                }
            }

            return true;
        }

        #endregion

        #region Properties

        public string DateTimeDigitized
        {
            get
            {
                if (__exifReader != null)
                {
                    return __exifReader.DateTimeDigitized.ToString(Constants.Format.ExactDateTime);
                }

                return string.Empty;
            }
            set
            {
                //do nothing
            }
        }

        public string DateTimeOriginal
        {
            get
            {
                if (__exifReader != null)
                {
                    return __exifReader.DateTimeOriginal.ToString(Constants.Format.ExactDateTime);
                }

                return string.Empty;
            }
            set
            {
                //do nothing
            }
        }

        public string DateTimeTaken
        {
            get
            {
                if (__exifReader != null)
                {
                    return __exifReader.DateTimeTaken.ToString(Constants.Format.ExactDateTime);
                }

                return string.Empty;
            }
            set
            {
                //do nothing
            }
        }

        public string Description
        {
            get
            {
                return __description;
            }
            set
            {
                __description = value;
            }
        }

        public Bitmap DisplayBitmap
        {
            get
            {
                OpenPhoto();
                return __exifReader.DisplayBitmap;
            }
            set
            {
                //do nothing
            }
        }

        public string DisplayName
        {
            get
            {
                if (__displayName != null && __displayName.Length > 0)
                {
                    return __displayName;
                }
                else
                {
                    return __exifReader.PhotoId;
                }
            }
            set
            {
                __displayName = value;
            }
        }

        public string KeyWords
        {
            get
            {
                if (__keyWords != null && __keyWords.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string str in __keyWords)
                    {
                        sb.Append(str).Append(", ");
                    }

                    return sb.ToString();
                }

                return string.Empty;

            }
            set
            {
                // do nothing
            }
        }
        

        /// <summary>
        /// Return the list of Exif Fields capture by exif reader for this photo
        /// </summary>
        public List<ExifField> ExifFields
        {
            get
            {
                List<ExifField> list = new List<ExifField>();
                if (__exifReader != null && __exifReader.ExifFields != null)
                {
                    foreach (ushort key in __exifReader.ExifFields.Keys)
                    {
                        list.Add(__exifReader.ExifFields[key]);
                    }
                }

                return list;
            }
            set
            {
                //do nothing
            }
        }

        public string FileName
        {
            get
            {
                if (__exifReader != null)
                {
                    return __exifReader.GetPhotoFileName();
                }

                return string.Empty;
            }
            set
            {
                //do nothing
            }
        }

        public string Path
        {
            get
            {
                return __path;
            }
            set
            {
                //do nothing
            }
        }

        public string PhotoId
        {
            get
            {
                return __exifReader.PhotoId;
            }
            set
            {
                //do nothing
            }
        }

        public string Public
        {
            get
            {
                return __public.ToString();
            }
            set
            {
                if (value.ToUpper().Equals("TRUE"))
                {
                    __public = true;
                }
                else
                {
                    __public = false;
                }
            }
        }

        public List<PhotoProperty> Properties
        {
            get
            {
                return __properties;
            }
            set
            {
                if (value != null)
                {
                    Type type = this.GetType();
                    PropertyInfo[] props = type.GetProperties();

                    for (int i = 0; i < props.Length; ++i)
                    {
                        PropertyInfo pi = props[i];
                        foreach (PhotoProperty pp in value)
                        {
                            if (pp.PropertyName.Equals(pi.Name))
                            {
                                props[i].SetValue(this, pp.PropertyValue, null);
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Photo Property Class

        public class PhotoProperty
        {
            private Photo   __parent;
            private string  __propertyName;
            private string  __propertyValue;

            public PhotoProperty(Photo parent)
            {
                __parent = parent;
            }

            public string PropertyName
            {
                get
                {
                    return __propertyName;
                }
                set
                {
                    __propertyName = value;
                }
            }

            public string PropertyValue
            {
                get
                {
                    return __propertyValue;
                }
                set
                {
                    __propertyValue = value;

                    if (__parent != null)
                    {
                        Type type = __parent.GetType();
                        PropertyInfo[] infos = type.GetProperties();

                        for (int i = 0; i < infos.Length; ++i)
                        {
                            if (__propertyName.Equals(infos[i].Name))
                            {
                                infos[i].SetValue(__parent, value, null);
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
