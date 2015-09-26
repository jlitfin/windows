using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace CustomControls
{
  public class LookAndFeel
  {

    //COLORS
    public static Color Black
    {
      get
      {
        return Color.FromArgb(0, 0, 0);
      }
    }

    public static Color Blue
    {
      get
      {
        return Color.FromArgb(80, 80, 250);
      }
    }

    public static Color Red
    {
      get
      {
        return Color.FromArgb(250, 80, 80);
      }
    }

    public static Color White
    {
      get
      {
        return Color.FromArgb(240, 240, 255);
      }
    }

    public static Color ColorDownX(Color clr, int xTimes)
    {
      int r = clr.R;
      int g = clr.G;
      int b = clr.B;

      float fade = .02F;
      int rDec = (int)((float)r * fade);
      int gDec = (int)((float)g * fade);
      int bDec = (int)((float)b * fade);

      for (int i = 0; i < xTimes; ++i)
      {
        rDec = (int)((float)r * fade);
        gDec = (int)((float)g * fade);
        bDec = (int)((float)b * fade);

        if (r - rDec > 0 && g - gDec > 0 && b - bDec > 0)
        {
          r -= rDec;
          g -= gDec;
          b -= bDec;
        }
        else
        {
          break;
        }
      } 

      return Color.FromArgb(r,g,b);
    }

    public static Color ColorUpX(Color clr, int xTimes)
    {
      int r = clr.R;
      int g = clr.G;
      int b = clr.B;

      float fade = .02F;
      int rDec = (int)((float)r * fade);
      int gDec = (int)((float)g * fade);
      int bDec = (int)((float)b * fade);

      for (int i = 0; i < xTimes; ++i)
      {
        if (r + rDec < 255 && g + gDec < 255 && b + bDec < 0)
        {
          r += rDec;
          g += gDec;
          b += bDec;
        }
        else
        {
          break;
        }
      }

      return Color.FromArgb(r, g, b);
    }

    public static Font Monospace
    {
      get
      {
        return new Font(FontFamily.GenericMonospace, 8.0F, FontStyle.Bold);
      }
    }

    public static Font Font
    {
      get
      {
        return new Font("Trebuchet MS", 10.0F);
        //Trebuchet MS     Verdana  Palatino Linotype  Franklin Gothic Medium
      }
    }


    //INFRASTRUCTURE
    public static float BorderWidth
    {
      get
      {
        return 1.0F;
      }
    }

  }
}
