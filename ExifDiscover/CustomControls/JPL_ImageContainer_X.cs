using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace CustomControls
{
  public partial class JPL_ImageContainer : UserControl
  {
    #region Private Members

    private Bitmap __displayImage;
    private Image __sourceImage;
    private bool  __mouseDown;
    private Point __mouseLocation;

    #endregion

    #region Properties

    public Image Image
    {
      get
      {
        return __sourceImage;
      }
      set
      {
        if (value != null)
        {
          __sourceImage = value;
          UpdateView();
        }
      }
    }

    #endregion

    public JPL_ImageContainer()
    {
      InitializeComponent();
    }

    private void UpdateView()
    {
      if (__sourceImage != null)
      {
        __displayImage = new Bitmap(pbImageCanvas.Width, pbImageCanvas.Height, PixelFormat.Format24bppRgb);
        __displayImage.SetResolution(__sourceImage.HorizontalResolution, __sourceImage.VerticalResolution);
        Graphics g = Graphics.FromImage(__displayImage);
        g.InterpolationMode = InterpolationMode.Default;

        g.DrawImage(__sourceImage, new Rectangle(0, 0, __displayImage.Width, __displayImage.Height),
          new Rectangle(0, 0, __sourceImage.Width, __sourceImage.Height), GraphicsUnit.Pixel);
        g.Dispose();

        this.pbImageCanvas.Image = __displayImage;
      }
    }

    private void JPL_ImageContainer_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Location.X > this.Width - 20 && e.Location.Y > this.Height - 20)
      {
        __mouseDown = true;
        __mouseLocation = e.Location;
      }
    }

    private void JPL_ImageContainer_MouseUp(object sender, MouseEventArgs e)
    {
      //__mouseDown = false;
    }

    private void JPL_ImageContainer_MouseMove(object sender, MouseEventArgs e)
    {
      //if (__mouseDown)
      //{
      //  int x = e.Location.X - __mouseLocation.X;
      //  int y = e.Location.Y - __mouseLocation.Y;
      //  this.Size = new Size(this.Size.Width + x, this.Size.Height + y);

      //  __mouseLocation = new Point(e.Location.X, e.Location.Y);
      //}

    }

    private void pbImageCanvas_MouseUp(object sender, MouseEventArgs e)
    {
      //__mouseDown = false;
    }

    private void pbImageCanvas_MouseDown(object sender, MouseEventArgs e)
    {
      //if (e.Location.X > this.Width - 20 && e.Location.Y > this.Height - 20)
      //{
      //  __mouseDown = true;
      //  __mouseLocation = e.Location;
      //}
    }

    private void JPL_ImageContainer_Paint(object sender, PaintEventArgs e)
    {
      //Color blu40 = LookAndFeel.ColorDownX(LookAndFeel.Blue, 40);
      //Color blu44 = LookAndFeel.ColorDownX(LookAndFeel.Blue, 44);
      //int hltOpacity = 130;

      //Color hlt = Color.FromArgb(hltOpacity, LookAndFeel.White);
      //Color hlt2 = Color.FromArgb(100, blu40);
      //LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, hlt, hlt2, LinearGradientMode.Vertical);
      //e.Graphics.FillRectangle(brush, this.ClientRectangle);
      //brush.Dispose();
    }

    private void JPL_ImageContainer_Resize(object sender, EventArgs e)
    {
      UpdateView();
    }
  }
}
