using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Q3DemoCatalog
{
  public partial class MessageWindow : Form
  {
    public MessageWindow()
    {
      InitializeComponent();
    }

    public void AppendMessage(string message, bool newLine)
    {
      this.txtMessages.AppendText(message);
    }
  }
}