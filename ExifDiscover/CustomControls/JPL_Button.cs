using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace CustomControls
{
  public partial class JPL_Button : Control
  {
    #region Private Members

    private Rectangle __topLeft;
    private Rectangle __topRight;
    private Rectangle __bottomRight;
    private Rectangle __bottomLeft;
    private Rectangle __hltBottomRight;
    private Rectangle __hltBottomLeft;
    private Rectangle __hltTopLeft;
    private Rectangle __hltTopRight;
    private int __cornerRadius;

    private GraphicsPath __bgPath;
    private GraphicsPath __hltPath;
    private GraphicsPath __hltSuper;

    private Font __font = LookAndFeel.Font;

    private bool __inMouseOver = false;

    #endregion

    public JPL_Button()
    {
      InitializeComponent();
    }

    #region Properites



    #endregion

    #region Events

    protected override void OnMouseHover(EventArgs e)
    {
      base.OnMouseHover(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      __inMouseOver = false;
      this.Invalidate();

      base.OnMouseLeave(e);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      __inMouseOver = true;
      this.Invalidate();

      base.OnMouseEnter(e);
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      SmoothingMode saveMode = pe.Graphics.SmoothingMode;
      pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;

      //draw background
      Color blu40 = LookAndFeel.ColorDownX(LookAndFeel.Blue, 40);
      Color blu44 = LookAndFeel.ColorDownX(LookAndFeel.Blue, 44);

      HatchBrush hatch = new HatchBrush(HatchStyle.WideUpwardDiagonal, blu44, blu40);
      pe.Graphics.FillPath(hatch, __bgPath);

      //Draw Highlights
      int hltOpacity = 130;
      if (__inMouseOver)
      {
        hltOpacity = 200;
      }

      Color hlt = Color.FromArgb(hltOpacity, LookAndFeel.White);
      Color hlt2 = Color.FromArgb(100, blu40);
      LinearGradientBrush brush = new LinearGradientBrush(__hltPath.GetBounds(), hlt, hlt2, LinearGradientMode.Vertical);
      pe.Graphics.FillPath(brush, __hltPath);

      Pen p = new Pen(LookAndFeel.White, 2.0F);
      //Point h1 = new Point(__cornerRadius, 2);
      //Point h2 = new Point(Width - __cornerRadius, 2);
      //pe.Graphics.DrawLine(p, h1, h2);

      //SolidBrush b = new SolidBrush(Color.FromArgb(130, JPL_LAF_Provider.White));
      //pe.Graphics.FillPath(b, __hltSuper);


      //draw border
      p.Color = LookAndFeel.Black;
      pe.Graphics.DrawPath(p, __bgPath);

      //p = new Pen(Color.FromArgb(90, JPL_LAF_Provider.Black100), 5.0F);
      //pe.Graphics.DrawPath(p, __bgPath);


      //ADD TEXT
      int charsFitted = 0;
      int linesFilled = 0;
      SizeF layoutArea = new SizeF((float)this.ClientRectangle.Width, (float)this.ClientRectangle.Height);
      SizeF sz = pe.Graphics.MeasureString(this.Text, __font, layoutArea, StringFormat.GenericDefault, out charsFitted, out linesFilled);
      Rectangle layoutRect = new Rectangle(0,0,0,0);
      if (linesFilled <= 1)
      {
        //simply center
        int x = (int)(this.ClientRectangle.Width - sz.Width) / 2;
        int y = (int)((this.ClientRectangle.Height / 2) - (sz.Height / 2));
        layoutRect = new Rectangle(x, y - 2, (int)sz.Width + 2, (int)sz.Height + 2);        
      }
      else if (linesFilled > 1)
      {
        if (sz.Height > this.ClientRectangle.Height - (2 * __cornerRadius))
        {
          //scale font
        }
      }

      SolidBrush b = new SolidBrush(LookAndFeel.Black);
      pe.Graphics.DrawString(this.Text, __font, b, layoutRect);

      layoutRect.Offset(-1,-1);
      b.Color = LookAndFeel.White;
      pe.Graphics.DrawString(this.Text, __font, b, layoutRect);  


      //////////hatch.Dispose();
      //////////brush.Dispose();
      //////////p.Dispose();


      //TEST
      //Pen tp = new Pen(Color.Cyan, 1.0F);
      //pe.Graphics.DrawRectangle(tp, __upperLeft);
      //pe.Graphics.DrawRectangle(tp, __upperRight);
      //pe.Graphics.DrawRectangle(tp, __lowerRight);
      //pe.Graphics.DrawRectangle(tp, __lowerLeft);
      //pe.Graphics.DrawRectangle(tp, __hltBottomRight);
      //pe.Graphics.DrawRectangle(tp, __hltBottomLeft);
      //tp.Dispose();

      // Calling the base class OnPaint
      pe.Graphics.SmoothingMode = saveMode;
      base.OnPaint(pe);
    }

    private void JPL_Button_Layout(object sender, LayoutEventArgs e)
    {
      int width = this.ClientRectangle.Width - 4;
      int height = this.ClientRectangle.Height - 4;
      __cornerRadius = height / 3;

      __topLeft   = new Rectangle(1, 1, __cornerRadius, __cornerRadius);
      __topRight  = new Rectangle(width - __cornerRadius, 1, __cornerRadius, __cornerRadius);
      __bottomRight  = new Rectangle(width - __cornerRadius, height - __cornerRadius, __cornerRadius, __cornerRadius);
      __bottomLeft   = new Rectangle(1, height - __cornerRadius, __cornerRadius, __cornerRadius);

      __bgPath = new GraphicsPath();
      __bgPath.AddArc(__topLeft, 180, 90);
      __bgPath.AddLine(__cornerRadius, 1, width - __cornerRadius, 1);
      __bgPath.AddArc(__topRight, 270, 90);
      __bgPath.AddLine(width, __cornerRadius, width, height - __cornerRadius);
      __bgPath.AddArc(__bottomRight, 0, 90);
      __bgPath.AddLine(width - __cornerRadius, height, __cornerRadius, height);
      __bgPath.AddArc(__bottomLeft, 90, 90);
      __bgPath.CloseFigure();

      int hltMid = (height / 2) + (height / 6);
      __hltBottomRight = new Rectangle(width - __cornerRadius, hltMid - __cornerRadius / 2, __cornerRadius, __cornerRadius / 2);
      __hltBottomLeft = new Rectangle(1, hltMid - __cornerRadius / 2, __cornerRadius, __cornerRadius / 2);

      __hltPath = new GraphicsPath();
      __hltPath.AddArc(__topLeft, 180, 90);
      __hltPath.AddLine(__cornerRadius, 1, width - __cornerRadius, 1);
      __hltPath.AddArc(__topRight, 270, 90);
      __hltPath.AddLine(width, __cornerRadius, width, hltMid - __cornerRadius / 2);
      __hltPath.AddArc(__hltBottomRight, 0, 90);
      __hltPath.AddLine(width - __cornerRadius, hltMid, __cornerRadius, hltMid);
      __hltPath.AddArc(__hltBottomLeft, 90, 90);
      __hltPath.AddLine(1, hltMid - __cornerRadius / 2, 1, __cornerRadius);

      __hltTopLeft = new Rectangle(__topLeft.X, __topLeft.Y, __topLeft.Width, __topLeft.Height);
      __hltTopRight = new Rectangle(__topRight.X, __topRight.Y, __topLeft.Width, __topLeft.Height);
      __hltSuper = new GraphicsPath();
      __hltSuper.AddArc(__hltTopLeft, 90, 180);
      __hltSuper.AddArc(__hltTopRight, 270, 180);
      __hltSuper.CloseFigure();


    }

    #endregion
  }
}
