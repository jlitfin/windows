using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomControls
{
  public partial class JPL_ImageContainer : Control
  {
    #region Private Members

    PictureBox __pbImageCanvas;
    Image      __displayImage;

    #endregion

    #region Properties

    public Image DisplayImage
    {
      get
      {
        return __displayImage;
      }
      set
      {
        if (value != null)
        {
          __displayImage = value;
          __pbImageCanvas.Image = __displayImage;
          Invalidate();
        }
      }
    }

    #endregion

    public JPL_ImageContainer()
    {
      InitializeComponent();
    }

    #region Events

    protected override void OnPaint(PaintEventArgs pe)
    {
      // TODO: Add custom paint code here
      //this.pnlBackground.Invalidate();
      //__pbImageCanvas.Invalidate();

      // Calling the base class OnPaint
      base.OnPaint(pe);
    }

    private void JPL_ImageContainer_Layout(object sender, LayoutEventArgs e)
    {
      pnlBackground.Dock = DockStyle.Fill;
      pnlBackground.BackColor = LookAndFeel.Black;
      pnlBackground.BorderStyle = BorderStyle.FixedSingle;
      pnlBackground.Padding = new Padding(10);
      this.Controls.Add(pnlBackground);

      __pbImageCanvas = new PictureBox();
      __pbImageCanvas.BackColor = LookAndFeel.ColorDownX(LookAndFeel.Blue, 20);
      __pbImageCanvas.Dock = DockStyle.Fill;
      this.pnlBackground.Controls.Add(__pbImageCanvas);

      if (__displayImage != null)
      {
        __pbImageCanvas.Image = __displayImage;
      }
    }

    #endregion

  }
}
