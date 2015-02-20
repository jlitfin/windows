using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DatabaseConnector;

namespace DatabaseInterrogator
{
    public partial class AddServerDialog : Form
    {
        private bool _connTest = false;

        public AddServerDialog()
        {
            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.txtOutput.Text = string.Empty;
            string msg = string.Empty;
            _connTest = Repository.TestConnection(this.txtServerName.Text, out msg);
            if (_connTest)
            {
                this.btnSave.Enabled = true;
            }

            this.txtOutput.Text = msg;
            this.Cursor = Cursors.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_connTest)
            {
                Repository.AddServer(this.txtServerName.Text);
            }
        }

        private void txtServerName_TextChanged(object sender, EventArgs e)
        {
            _connTest = false;
        }
    }
}
