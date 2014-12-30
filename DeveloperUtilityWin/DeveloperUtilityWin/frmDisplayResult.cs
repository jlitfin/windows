using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeveloperUtilityWin
{
    public partial class frmDisplayResult : Form
    {
        private string __displayText = string.Empty;

        public frmDisplayResult(string displayText)
        {
            InitializeComponent();

            DisplayText = displayText;
        }

        public string DisplayText
        {
            get
            {
                return __displayText;
            }
            set
            {
                __displayText = value;
                this.txtDisplay.Text = value;
            }
        }

        private void txtDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString().Equals("A"))
            {
                //
                // copy all to clipboard
                //
                this.txtDisplay.SelectAll();
                e.Handled = true;
            }
        }
    }
}
