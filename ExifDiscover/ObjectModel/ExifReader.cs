using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;

namespace ObjectModel
{
    public class ExifReader
    {
        private static Bitmap __defaultDisplayImage;

        #region Private Members

        private Image   __targetImage;
        private string  __fileName;
        private Dictionary<int, ExifFieldFormat> __exifFieldFormats;
        private Dictionary<ushort, ExifField> __exifFields;

        private const ushort DATE_TIME = 0x0132;
        private const ushort DATE_TIME_DIGITIZED = 0x9004;
        private const ushort DATE_TIME_ORIGINAL = 0x9003;
        private const ushort EXIF_IMAGE_WIDTH = 0xa002;
        private const ushort EXIF_IMAGE_HEIGHT = 0xa003;
        private const ushort EXPOSURE_TIME = 0x829a;
        private const ushort FNUMBER = 0x0829d;
        private const ushort ISO_SPEED_RATINGS = 0x8827;
        private const ushort MAKE = 0x010f;
        private const ushort MAKER_NOTE = 0x927c;
        private const ushort MODEL = 0x0110;
        private const ushort SUB_SEC_TIME_TAKEN = 0x9290;
        private const ushort SUB_SEC_TIME_DIGITIZED = 0x9292;
        private const ushort SUB_SEC_TIME_ORIGINAL = 0x9291;

        #endregion

        #region Constructor

        public ExifReader(string fileName)
        {
            if (ExifReader.__defaultDisplayImage == null)
            {
                __defaultDisplayImage = new Bitmap(Constants.Resources.DefaultImagePath);
            }

            __fileName = fileName;
            try
            {
                __targetImage = null;
                __targetImage = Image.FromFile(__fileName);

                //FileStream fs = new FileStream(__fileName, FileMode.Open);
                //__targetImage = Image.FromStream(fs, false, false);
                //while (__targetImage == null)
                //{
                //    int i = 0;
                //}
                //fs.Close();

                //Dim path as String ="some picture.jpg"
                //Dim st As New IO.FileStream(path, IO.FileMode.Open,
                //IO.FileAccess.Read)
                //Dim img As Image = Drawing.Image.FromStream(st, False, False)

                //While st.Position <> st.Position
                //Application.DoEvents()
                //' might need a sleep in here
                //End While
                //st.Close()

                this.Initialize();
            }
            catch (Exception ex)
            {
                ErrorManager.Instance().Publish(ex.Message);
            }

            Console.WriteLine("Leaving Const.");
        }

        #endregion

        #region Public Properties

        public Dictionary<int, ExifFieldFormat> ExifFieldFormats
        {
            get
            {
                return __exifFieldFormats;
            }
        }

        public Dictionary<ushort, ExifField> ExifFields
        {
            get
            {
                return __exifFields;
            }
        }

        public DateTime DateTimeTaken
        {
            get
            {
                DateTime dt = DateTime.MinValue;

                if (__exifFields != null && __exifFields.ContainsKey(DATE_TIME))
                {
                    ExifField fld = __exifFields[DATE_TIME];

                    try
                    {
                        string dateString = fld.GetValueString();
                        dt = this.ParseDateTime(dateString);
                    }
                    catch
                    {
                        Exception pE = new Exception("Could not parse DateTime string");
                        throw pE;
                    }
                }

                return dt;
            }
        }

        public DateTime DateTimeDigitized
        {
            get
            {
                DateTime dt = DateTime.MinValue;

                if (__exifFields != null && __exifFields.ContainsKey(DATE_TIME_DIGITIZED))
                {
                    ExifField fld = __exifFields[DATE_TIME_DIGITIZED];

                    try
                    {
                        string dateString = fld.GetValueString();
                        dt = this.ParseDateTime(dateString);
                    }
                    catch
                    {
                        Exception pE = new Exception("Could not parse DateTime string");
                        throw pE;
                    }
                }

                return dt;
            }
        }

        public DateTime DateTimeOriginal
        {
            get
            {
                DateTime dt = DateTime.MinValue;

                if (__exifFields != null && __exifFields.ContainsKey(DATE_TIME_ORIGINAL))
                {
                    ExifField fld = __exifFields[DATE_TIME_ORIGINAL];

                    try
                    {
                        string dateString = fld.GetValueString();
                        dt = this.ParseDateTime(dateString);
                    }
                    catch
                    {
                        Exception pE = new Exception("Could not parse DateTime string");
                        throw pE;
                    }
                }

                return dt;
            }
        }

        public string PhotoId
        {
            get
            {
                string fileName = GetPhotoFileName();
                if (fileName.IndexOf(".jpg") > 0)
                {
                    return fileName.Substring(0, fileName.Length - 4);
                }

                return fileName;
            }
        }

        public Bitmap DisplayBitmap
        {
            get
            {
                if (__targetImage == null)
                {
                    try
                    {
                        __targetImage = Image.FromFile(__fileName);
                        Bitmap displayBitmap = new Bitmap(__targetImage, ImageWidth, ImageHeight);
                        return displayBitmap;
                    }
                    catch (Exception e)
                    {
                        ErrorManager.Instance().Publish(e.Message);
                        return __defaultDisplayImage;
                    }
                }
                else
                {
                    Bitmap displayBitmap = new Bitmap(__targetImage, ImageWidth, ImageHeight);
                    return displayBitmap;
                }              
                
            }
        }

        public UInt16 SubSecTimeTaken
        {
            get
            {
                UInt16 ms = (UInt16)0;

                if (__exifFields != null && __exifFields.ContainsKey(SUB_SEC_TIME_TAKEN))
                {
                    ExifField fld = __exifFields[SUB_SEC_TIME_TAKEN];
                    bool parsed = UInt16.TryParse(fld.GetValueString(), out ms);

                    if (!parsed)
                    {
                        ms = 0;
                    }
                }

                return ms;
            }
        }

        public UInt16 ImageHeight
        {
            get
            {
                UInt16 height = 0;

                if (__exifFields != null && __exifFields.ContainsKey(EXIF_IMAGE_HEIGHT))
                {
                    ExifField fld = __exifFields[EXIF_IMAGE_HEIGHT];
                    height = fld.GetValueUInt16();
                }

                return height;
            }
        }

        public UInt16 ImageWidth
        {
            get
            {
                UInt16 width = 0;

                if (__exifFields != null && __exifFields.ContainsKey(EXIF_IMAGE_WIDTH))
                {
                    ExifField fld = __exifFields[EXIF_IMAGE_WIDTH];
                    width = fld.GetValueUInt16();
                }

                return width;
            }
        }

        public bool HasExifInfo
        {
            get
            {
                Console.WriteLine("Has called.");
                if (__targetImage != null && __targetImage.PropertyItems != null && __targetImage.PropertyItems.Length > 0)
                {
                    return true;
                }

                return false;
            }
        }

        #endregion

        #region Public Methods

        public string GetPhotoFileName()
        {
            DateTime nDate = DateTime.MinValue; // DateTimeTaken;
            if (nDate == DateTime.MinValue)
            {
                nDate = DateTimeDigitized;
            }

            if (nDate == DateTime.MinValue)
            {
                nDate = DateTimeOriginal;
            }

            if (nDate == DateTime.MinValue)
            {
                //error condition, we tried all possible exif dates and failed.
                nDate = DateTime.MaxValue;
            }

            if (nDate == DateTime.MaxValue)
            {
                throw new Exception("No EXIF Date");
            }

            StringBuilder sb = new StringBuilder()
            .Append(nDate.Month)
            .Append(".")
            .Append(nDate.Day)
            .Append(".")
            .Append(nDate.Year)
            .Append(".")
            .Append(nDate.Hour)
            .Append(".")
            .Append(nDate.Minute)
            .Append(".")
            .Append(nDate.Second)
            .Append(".jpg");

            return sb.ToString();
        }

        #endregion

        #region Private Methods

        public string GetExifDataString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ushort key in __exifFields.Keys)
            {
                ExifField fld = __exifFields[key];
                sb.Append(fld.Name.PadRight(30));
                sb.Append(" ");
                sb.Append(" ");
                sb.Append(fld.Format.FormatDescription.PadRight(25));
                sb.Append(" ");
                sb.Append(" ");

                if (fld.Bytes != null && fld.Bytes.Length > 0)
                {
                    for (int i = 0; i < fld.Bytes.Length; ++i)
                    {
                        sb.Append(fld.Bytes[i].ToString("X2"));

                        if ((i + 1) % 8 == 0)
                        {
                            if (i < fld.Bytes.Length - 1)
                            {
                                sb.AppendLine();
                                sb.Append(" ".PadRight(59));
                            }
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }
                }

                sb.AppendLine();
            }
            return sb.ToString();
        }

        private void GetExifData()
        {
            if (__targetImage != null && __targetImage.PropertyItems != null && __exifFields != null && __exifFieldFormats != null)
            {
                foreach (PropertyItem prop in __targetImage.PropertyItems)
                {
                    ushort key = (ushort)prop.Id;
                    if (__exifFields.ContainsKey(key))
                    {
                        __exifFields[key].Bytes = prop.Value;
                    }
                }
            }



            __targetImage.Dispose();
            __targetImage = null;
        }

        private void Initialize()
        {
            try
            {
                #region Field Formats

                //setup Field Formats
                __exifFieldFormats = new Dictionary<int, ExifFieldFormat>();

                ExifFieldFormat f = new ExifFieldFormat(1, "Unsigned Byte", typeof(byte), 1);
                __exifFieldFormats.Add(f.Key, f);

                f = new ExifFieldFormat(2, "ASCII String", typeof(string), 1);
                __exifFieldFormats.Add(f.Key, f);

                f = new ExifFieldFormat(3, "Unsigned Short", typeof(UInt16), 2);
                __exifFieldFormats.Add(f.Key, f);

                f = new ExifFieldFormat(4, "Unsigned Long", typeof(UInt32), 4);
                __exifFieldFormats.Add(f.Key, f);

                f = new ExifFieldFormat(5, "Unsigned Rational", typeof(UInt32), 8);
                __exifFieldFormats.Add(f.Key, f);

                f = new ExifFieldFormat(6, "Signed Byte", typeof(sbyte), 1);
                __exifFieldFormats.Add(f.Key, f);

                f = new ExifFieldFormat(7, "Undefined", typeof(object), 1);
                __exifFieldFormats.Add(f.Key, f);

                f = new ExifFieldFormat(8, "Signed Short", typeof(Int16), 2);
                __exifFieldFormats.Add(f.Key, f);

                f = new ExifFieldFormat(9, "Signed Long", typeof(Int32), 4);
                __exifFieldFormats.Add(f.Key, f);

                f = new ExifFieldFormat(10, "Signed Rational", typeof(Int32), 8);
                __exifFieldFormats.Add(f.Key, f);

                f = new ExifFieldFormat(11, "Float", typeof(float), 4);
                __exifFieldFormats.Add(f.Key, f);

                f = new ExifFieldFormat(12, "Double", typeof(double), 8);
                __exifFieldFormats.Add(f.Key, f);

                #endregion

                //setup fields
                __exifFields = new Dictionary<ushort, ExifField>();

                #region IFD0

                //
                //IFD0
                //

                ExifField fld = new ExifField();
                fld.Name = "ImageDescription";
                fld.Tag = 0x010e;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "Make";
                fld.Tag = 0x010f;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "Model";
                fld.Tag = 0x0110;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "Orientation";
                fld.Tag = 0x0112;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "XResolution";
                fld.Tag = 0x011a;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "YResolution";
                fld.Tag = 0x011b;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ResolutionUnit";
                fld.Tag = 0x0128;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "Software";
                fld.Tag = 0x0131;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "DateTime";
                fld.Tag = 0x0132;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "WhitePoint";
                fld.Tag = 0x013e;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "PrimaryChromaticities";
                fld.Tag = 0x013f;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "YCbCrCoefficients";
                fld.Tag = 0x0211;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "YCbCrPositioning";
                fld.Tag = 0x0213;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ReferenceBlackWhite";
                fld.Tag = 0x0214;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "Copyright";
                fld.Tag = 0x8298;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ExifOffset";
                fld.Tag = 0x8769;
                fld.Format = __exifFieldFormats[9];
                __exifFields.Add(fld.Tag, fld);

                #endregion

                #region SubIFD
                //
                //SubIFD
                //

                fld = new ExifField();
                fld.Name = "ExposureTime";
                fld.Tag = 0x829a;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "FNumber";
                fld.Tag = 0x829d;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ExposureProgram";
                fld.Tag = 0x8822;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ISOSpeedRatings";
                fld.Tag = 0x8827;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ExifVersion";
                fld.Tag = 0x9000;
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "DateTimeOriginal";
                fld.Tag = 0x9003;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "DateTimeDigitized";
                fld.Tag = 0x9004;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ComponentsConfiguration";
                fld.Tag = 0x9101;
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "CompressedBitsPerPixel";
                fld.Tag = 0x9102;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ShutterSpeedValue";
                fld.Tag = 0x9201;
                fld.Format = __exifFieldFormats[10];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ApertureValue";
                fld.Tag = 0x9202;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "BrightnessValue";
                fld.Tag = 0x9203;
                fld.Format = __exifFieldFormats[10];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ExposureBiasValue";
                fld.Tag = 0x9204;
                fld.Format = __exifFieldFormats[10];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "MaxApertureValue";
                fld.Tag = 0x9205;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "SubjectDistance";
                fld.Tag = 0x9206;
                fld.Format = __exifFieldFormats[10];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "MeteringMode";
                fld.Tag = 0x9207;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "LightSource";
                fld.Tag = 0x9208;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "Flash";
                fld.Tag = 0x9209;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "FocalLength";
                fld.Tag = 0x920a;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "MakerNote";
                fld.Tag = 0x927c;
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "UserComment";
                fld.Tag = 0x9286;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "SubsecTime";
                fld.Tag = 0x9290;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "SubsecTimeOriginal";
                fld.Tag = 0x9291;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "SubsecTimeDigitized";
                fld.Tag = 0x9292;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "FlashPixVersion";
                fld.Tag = 0xa000;
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ColorSpace";
                fld.Tag = 0xa001;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ExifImageWidth";
                fld.Tag = 0xa002;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ExifImageHeight";
                fld.Tag = 0xa003;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "RelatedSoundFile";
                fld.Tag = 0xa004;
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ExifInteroperabilityOffset";
                fld.Tag = 0xa005;
                fld.Format = __exifFieldFormats[4];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "FocalPlaneXResolution";
                fld.Tag = 0xa20e;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "FocalPlaneYResolution";
                fld.Tag = 0xa20f;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "FocalPlaneResolutionUnit";
                fld.Tag = 0xa210;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "ExposureIndex";
                fld.Tag = 0xa215;
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "SensingMethod";
                fld.Tag = 0xa217;
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "FileSource";
                fld.Tag = 0xa300;
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "SceneType";
                fld.Tag = 0xa301;
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Name = "CFAPattern";
                fld.Tag = 0xa302;
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                #endregion

                #region MISC types
                //
                //So Called MISC types
                //

                fld = new ExifField();
                fld.Tag = 0x00fe;
                fld.Name = "NewSubfileType";
                fld.Format = __exifFieldFormats[4];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x00ff;
                fld.Name = "SubfileType";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x012d;
                fld.Name = "TransferFunction";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x013b;
                fld.Name = "Artist";
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x013d;
                fld.Name = "Predictor";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x0142;
                fld.Name = "TileWidth";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x0143;
                fld.Name = "TileLength";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x0144;
                fld.Name = "TileOffsets";
                fld.Format = __exifFieldFormats[4];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x0145;
                fld.Name = "TileByteCounts";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x014a;
                fld.Name = "SubIFDs";
                fld.Format = __exifFieldFormats[4];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x015b;
                fld.Name = "JPEGTables";
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x828d;
                fld.Name = "CFARepeatPatternDim";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x828e;
                fld.Name = "CFAPattern";
                fld.Format = __exifFieldFormats[1];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x828f;
                fld.Name = "BatteryLevel";
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x83bb;
                fld.Name = "IPTC/NAA";
                fld.Format = __exifFieldFormats[4];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x8773;
                fld.Name = "InterColorProfile";
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x8824;
                fld.Name = "SpectralSensitivity";
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x8825;
                fld.Name = "GPSInfo";
                fld.Format = __exifFieldFormats[4];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x8828;
                fld.Name = "OECF";
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x8829;
                fld.Name = "Interlace";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x882a;
                fld.Name = "TimeZoneOffset";
                fld.Format = __exifFieldFormats[8];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x882b;
                fld.Name = "SelfTimerMode";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x920b;
                fld.Name = "FlashEnergy";
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x920c;
                fld.Name = "SpatialFrequencyResponse";
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x920d;
                fld.Name = "Noise";
                fld.Format = __exifFieldFormats[7];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x9211;
                fld.Name = "ImageNumber";
                fld.Format = __exifFieldFormats[4];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x9212;
                fld.Name = "SecurityClassification";
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x9213;
                fld.Name = "ImageHistory";
                fld.Format = __exifFieldFormats[2];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x9214;
                fld.Name = "SubjectLocation";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x9215;
                fld.Name = "ExposureIndex";
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0x9216;
                fld.Name = "TIFF/EPStandardID";
                fld.Format = __exifFieldFormats[1];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0xa20b;
                fld.Name = "FlashEnergy";
                fld.Format = __exifFieldFormats[5];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0xa20c;
                fld.Name = "SpatialFrequencyResponse";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                fld = new ExifField();
                fld.Tag = 0xa214;
                fld.Name = "SubjectLocation";
                fld.Format = __exifFieldFormats[3];
                __exifFields.Add(fld.Tag, fld);

                #endregion

                //
                //populate data from Image 
                //
                GetExifData();

            }

            catch (Exception ex)
            {
                throw new Exception("Field Initialization Error: " + ex.Message);
            }
        }

        private DateTime ParseDateTime(string dateString)
        {
            dateString = dateString.Replace(" ", ":");
            string[] delims = { ":" };
            string[] sArray = dateString.Split(delims, StringSplitOptions.None);
            DateTime dt = DateTime.MinValue;
            if (sArray != null && sArray.Length == 6)
            {
                int year = Int32.Parse(sArray[0]);
                int mnth = Int32.Parse(sArray[1]);
                int day = Int32.Parse(sArray[2]);
                int hr = Int32.Parse(sArray[3]);
                int min = Int32.Parse(sArray[4]);
                int sec = Int32.Parse(sArray[5]);

                try
                {
                    dt = new DateTime(year, mnth, day, hr, min, sec);
                }
                catch (Exception ex)
                {
                    ErrorManager.Instance().Publish(ex.Message);
                }
            }

            return dt;
        }

        #endregion
    }

    #region Exif Field Format

    public class ExifFieldFormat
    {
        public readonly int Key;
        public readonly string FormatDescription;
        public readonly Type Type;
        public readonly int Size;

        public ExifFieldFormat(int key, string desc, Type t, int size)
        {
            this.Key = key;
            this.FormatDescription = desc;
            this.Type = t;
            this.Size = size;
        }
    }

    #endregion

    #region Exif Field Class

    public class ExifField
    {
        #region Private Members

        private ushort __tag;
        private ExifFieldFormat __format;
        private string __displayName;
        private byte[] __value;

        #endregion

        public ExifField()
        {
            __value = null;
        }

        #region Public Properties

        public byte[] Bytes
        {
            get
            {
                if (__value == null)
                {
                    byte[] zeroBytes = new byte[__format.Size];
                    for (int i = 0; i < __format.Size; ++i)
                    {
                        zeroBytes[i] = (byte)0;
                    }

                    return zeroBytes;
                }
                return __value;
            }
            set
            {
                __value = value;
            }
        }


        public string BytesString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < Bytes.Length; ++i)
                {
                    sb.Append(Bytes[i].ToString("X2"));

                    if ((i + 1) % 8 == 0)
                    {
                        if (i < Bytes.Length - 1)
                        {
                            sb.AppendLine();
                        }
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }

                return sb.ToString();
            }
        }

        public ExifFieldFormat Format
        {
            get
            {
                return __format;
            }
            set
            {
                __format = value;
            }
        }

        public string Name
        {
            get
            {
                return __displayName;
            }
            set
            {
                __displayName = value;
            }
        }

        public ushort Tag
        {
            get
            {
                return __tag;
            }
            set
            {
                __tag = value;
            }
        }

        #endregion

        #region Public Methods

        public byte GetValueByte()
        {
            if (__value != null && __format != null && __format.Type != null)
            {
                if (__format.Type == typeof(System.Byte))
                {
                    if (__value.Length == 4)
                    {
                        return (byte)__value[3];
                    }
                }
            }

            return (byte)0;
        }

        public string GetValueString()
        {
            if (__value != null && __format != null && __format.Type != null)
            {
                if (__format.Type == typeof(System.String))
                {
                    string str = System.Text.ASCIIEncoding.ASCII.GetString(__value);
                    //check for null terminated array and remove
                    str = str.Replace("\0", "");
                    return str;
                }
            }

            return string.Empty;
        }

        public UInt16 GetValueUInt16()
        {
            if (__value != null && __format != null && __format.Type != null)
            {
                if (__format.Type == typeof(System.UInt16))
                {
                    return BitConverter.ToUInt16(__value, 0);
                }
            }

            return (UInt16)0;
        }

        public UInt32 GetValueUInt32()
        {
            if (__value != null && __format != null && __format.Type != null)
            {
                if (__format.Type == typeof(System.UInt32))
                {
                    return BitConverter.ToUInt32(__value, 0);
                }
            }

            return (UInt32)0;
        }

        public double GetValueURational()
        {
            if (__value != null && __format != null && __format.Type != null)
            {
                if (__format.Type == typeof(System.UInt32) && __format.Key == 5)
                {
                    byte[] numBytes = new byte[4];
                    byte[] denBytes = new byte[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        numBytes[i] = __value[i];
                    }
                    for (int i = 4; i < __value.Length; ++i)
                    {
                        denBytes[i - 4] = __value[i];
                    }

                    UInt32 num = BitConverter.ToUInt32(numBytes, 0);
                    UInt32 den = BitConverter.ToUInt32(denBytes, 0);
                    if (den != 0)
                    {
                        return (((double)((double)num / (double)den)));
                    }
                }
            }

            return 0.0;
        }


        #endregion
    }

    #endregion
}


