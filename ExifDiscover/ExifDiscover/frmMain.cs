using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace JPhoto
{
  public partial class frmMain : Form
  {
    BinaryReader __binaryReader;
    ExifReader __exifReader;
    StringBuilder __fieldDump;

    Dictionary<int, ExifFieldFormat> __fieldFormats;

    public frmMain()
    {
      InitializeComponent();
    }

    private void btnRead_Click(object sender, EventArgs e)
    {
      Image img = Image.FromFile("test.jpg");
      img.Dispose();

      FileStream fs = new FileStream("test.jpg", FileMode.Open);
      __binaryReader = new BinaryReader(fs);

      StringBuilder sb = new StringBuilder();
      try
      {
        bool intel = true;
        bool eof = false;
        while (!eof)
        {
          byte b1 = __binaryReader.ReadByte();
          if (b1.ToString("x").Equals("ff"))
          {
            byte b2 = __binaryReader.ReadByte();

            string b1S = b1.ToString("x");
            string b2S = b2.ToString("x");

            sb.Append(b1S);
            sb.Append(b2S);

            if (b2S.Equals("d9"))
            {
              eof = true;
              break;
            }
            if (!b2S.Equals("d8"))
            {
              //try to get size
              byte[] sz = __binaryReader.ReadBytes(2);
              short size = BitConverter.ToInt16(sz, 0);
              sb.Append("  =  ").Append(size.ToString());

              if (b2S.Equals("e1"))
              {
                //check for exif header, byte reader is now pointed to start of exif header if exists
                string header = new string(__binaryReader.ReadChars(4));

                if (header.Equals("Exif"))
                {
                  //eat two bytes of zero and prepare for possible TIFF header
                  __binaryReader.ReadBytes(2); 

                  //TIFF HEADER
                  //get EndianNess
                  string tiff = new string(__binaryReader.ReadChars(2));
                  if (tiff.Equals("II"))
                  {
                    intel = true;
                  }
                  else
                  {
                    intel = false;
                  }

                  //test endianness
                  byte[] tag = __binaryReader.ReadBytes(2);
                  if (intel)
                  {
                    if (tag[0] != 0x2a)
                    {
                      throw new Exception("EndianNess test failed. II with mark out of order");
                    }
                  }
                  else
                  {
                    if (tag[1] != 0x2a)
                    {
                      throw new Exception("EndianNess test failed. MM with mark out of order.");
                    }
                  }

                  //get offset to first IFD
                  int IFD = __binaryReader.ReadInt32(); 

                  //advance to IFD0, subtract 8 which is TIFF header size before eating any
                  //bytes if necessary
                  int offset = IFD - 8;
                  if (offset > 0)
                  {
                    __binaryReader.ReadBytes(offset);
                  }
    
                  //next 4 bytes is count of directory entries
                  int entryCount = BitConverter.ToInt16(__binaryReader.ReadBytes(2), 0);

                  //now read the entries in the first IFD
                  __fieldDump = new StringBuilder();
                  for (int i = 0; i < entryCount; ++i)
                  {
                    //TEST
                    //get the entries for dump
                    __fieldDump.Append(i.ToString("000"));
                    __fieldDump.Append(": ");
                    
                    //get tag value
                    short entry = __binaryReader.ReadInt16();
                    __fieldDump.Append(entry.ToString("X4"));
                    __fieldDump.Append(" ");
                    
                    //get data format
                    entry = __binaryReader.ReadInt16();
                    __fieldDump.Append(entry.ToString("X4"));
                    __fieldDump.Append(" ");

                    //get number of components
                    int entry4 = __binaryReader.ReadInt32();
                    __fieldDump.Append(entry4.ToString("X8"));
                    __fieldDump.Append(" ");

                    entry4 = __binaryReader.ReadInt32();
                    __fieldDump.Append(entry4.ToString("X8"));
                    __fieldDump.Append("     ");

                    //give data type
                    ExifFieldFormat f = __fieldFormats[entry];
                    __fieldDump.Append(f.Format.PadRight(20));
                    __fieldDump.Append(" ");
                    __fieldDump.Append(f.Size.ToString());
                    __fieldDump.AppendLine();      
             

                    //get data type of components in this entry
                    //int dataType = __binaryReader.ReadInt32();

                    //ExifFieldFormat format = null;
                    //if (__fieldFormats.ContainsKey(dataType))
                    //{
                    //  ExifFieldFormat format = __fieldFormats[dataType];
                    //}
                    //else
                    //{
                    //  throw new Exception("Unknown field format type: " + format.ToString());
                    //}

                  }
                }
              }

              //now read and discard size bytes (minus size indicator [2 bytes])
              //__binaryReader.ReadBytes(size - 2);
            }
            sb.AppendLine();
          }
        }
        
        sb.AppendLine();
        __fieldDump.AppendLine();
        __fieldDump.AppendLine(Constants.TagsIFD0.ImageDescription.ToString("x4"));
        __fieldDump.AppendLine(Constants.TagsIFD0.Make.ToString("x4"));

        this.txtOut.Text = __fieldDump.ToString();
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

      __binaryReader.Close();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      //setup Field Formats
      __fieldFormats = new Dictionary<int, ExifFieldFormat>();

      ExifFieldFormat f = new ExifFieldFormat();
      f.Format = "Unsigned Byte";
      f.Key = 1;
      f.Size = 1;
      __fieldFormats.Add(f.Key, f);

      f = new ExifFieldFormat();
      f.Format = "ASCII String";
      f.Key = 2;
      f.Size = 1;
      __fieldFormats.Add(f.Key, f);

      f = new ExifFieldFormat();
      f.Format = "Unsigned Short";
      f.Key = 3;
      f.Size = 2;
      __fieldFormats.Add(f.Key, f);

      f = new ExifFieldFormat();
      f.Format = "Unsigned Long";
      f.Key = 4;
      f.Size = 4;
      __fieldFormats.Add(f.Key, f);

      f = new ExifFieldFormat();
      f.Format = "Unsigned Rational";
      f.Key = 5;
      f.Size =8;
      __fieldFormats.Add(f.Key, f);

      f = new ExifFieldFormat();
      f.Format = "Signed Byte";
      f.Key = 6;
      f.Size = 1;
      __fieldFormats.Add(f.Key, f);

      f = new ExifFieldFormat();
      f.Format = "Undefined";
      f.Key = 7;
      f.Size = 1;
      __fieldFormats.Add(f.Key, f);

      f = new ExifFieldFormat();
      f.Format = "Signed Short";
      f.Key = 8;
      f.Size = 2;
      __fieldFormats.Add(f.Key, f);

      f = new ExifFieldFormat();
      f.Format = "Signed Long";
      f.Key = 9;
      f.Size = 4;
      __fieldFormats.Add(f.Key, f);

      f = new ExifFieldFormat();
      f.Format = "Signed Rational";
      f.Key = 10;
      f.Size = 8;
      __fieldFormats.Add(f.Key, f);

      f = new ExifFieldFormat();
      f.Format = "Float";
      f.Key = 11;
      f.Size = 4;
      __fieldFormats.Add(f.Key, f);

      f = new ExifFieldFormat();
      f.Format = "Double";
      f.Key = 12;
      f.Size = 8;
      __fieldFormats.Add(f.Key, f);
    }
  }
}