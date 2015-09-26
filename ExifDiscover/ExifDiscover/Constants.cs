using System;
using System.Collections.Generic;
using System.Text;

namespace JPhoto
{
  class Constants
  {
    public const string EOF_MARKER = "FFFF [EOF] FFFF";

    public class TagsIFD0
    {
      public const short ImageDescription = 0x010e;
      public const short Make = 0x010f;
      public const short Model = 0x0110;
      public const short Orientation = 0x0112;
      public const short XResolution = 0x011a;
      public const short YResolution = 0x011b;

    }
  }
}
