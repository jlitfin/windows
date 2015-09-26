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
  public partial class JPL_BaseForm : Form
  {
    public JPL_BaseForm()
    {
      InitializeComponent();
    }

    private void pnlControlsTop_Paint(object sender, PaintEventArgs e)
    {
      
    }

    private void pnlContent_Paint(object sender, PaintEventArgs e)
    {
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void JPL_BaseForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        JPL_BaseForm frm = sender as JPL_BaseForm;
        if (frm != null)
        {
            frm.Hide();
            e.Cancel = true;
        }

       
    }
  }
}