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
    public partial class Main : Form
    {
        #region private members

        #endregion

        #region properties

        #endregion

        #region constructor

        public Main()
        {
            InitializeComponent();
        }

        #endregion

        #region private methods

        private void log(string message, bool newLIne = false)
        {
            if (newLIne)
            {
                this.txtOutput.AppendText(message + "\r\n");
            }
            else
            {
                this.txtOutput.AppendText(message.PadRight(message.Length + 2, ' '));
            }
        }

        #endregion

        #region ui events

        private void Main_Load(object sender, EventArgs e)
        {
            updateServersList();
        }

        private void displaySearchResult(List<SearchResult> list)
        {
            int c1 = 0;
            int c2 = 0;
            int c3 = 0;
            int c4 = 0;
            int buffer = 2;
            foreach (var sr in list)
            {
                c1 = (sr.ObjectType.Length > c1) ? sr.ObjectType.Length : c1;
                c2 = (sr.ObjectName.Length > c2) ? sr.ObjectName.Length : c2;
                c3 = (sr.Server.Length > c3) ? sr.Server.Length : c3;
                c4 = (sr.Database.Length > c4) ? sr.Database.Length : c4;
            }
            string format = "{0, -" + (c1 + buffer).ToString() + "}{1, -" + (c2 + buffer).ToString() + "}{2, -" + (c3 + buffer).ToString() + "}{3, -" + (c3 + buffer).ToString() + "}\r\n";
            this.txtSearchResult.Clear();
            this.txtSearchResult.AppendText(string.Format(format, "TYPE", "OBJECT", "SERVER", "DATABASE"));
            this.txtSearchResult.AppendText("-".PadRight(c1 + c2 + c3 + c4 + (buffer * 3), '-') + "\r\n");
            foreach (var sr in list)
            {
                this.txtSearchResult.AppendText(string.Format(format, sr.ObjectType, sr.ObjectName, sr.Server, sr.Database));
            }
        }

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            var frm = new AddServerDialog();
            var result = frm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                updateServersList();
            }
        }

        private void cboServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var server = this.cboServers.SelectedItem.ToString();
                if (server.Equals(Repository.SERVER_LIST_DEFAULT_VALUE)) return;

                log(string.Format("querying server {0}...", server), false);
                var dblist = Repository.GetDatabases(server);
                if (dblist != null && dblist.Count > 0)
                {
                    this.lbDatabases.Items.Clear();
                    this.lbDatabases.Items.AddRange(dblist.ToArray());
                    this.pnlSearchControls.Visible = true;
                }
                else
                {
                    this.pnlSearchControls.Visible = false;
                }
                log("done.", true);
            }
            catch (Exception ex)
            {
                log(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSearch.Text))
            {
                this.Cursor = Cursors.WaitCursor;
                this.btnSearch.Enabled = false;

                try
                {
                    var cumulative = new List<SearchResult>();
                    foreach (var item in this.lbDatabases.SelectedItems)
                    {
                        Database db = item as Database;
                        if (db != null)
                        {
                            log(string.Format("searching {0}->{1} ...", db.Server, db.Name), false);
                            List<SearchResult> results = Repository.Search(db, this.txtSearch.Text);
                            cumulative.AddRange(results);
                            log(string.Format("located {0} possible objects.", results.Count), true);
                        }
                    }
                    displaySearchResult(cumulative.OrderBy(r => r.ObjectType).ToList());
                }
                catch (Exception ex)
                {
                    log(ex.Message, true);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void updateServersList()
        {
            this.cboServers.Items.Clear();
            this.cboServers.Items.AddRange(Repository.ServerList.ToArray());
            this.cboServers.SelectedIndex = 0;
        }

        private void lbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSearch.Text) && this.lbDatabases.SelectedItems.Count > 0)
            {
                this.btnSearch.Enabled = true;
            }
            else
            {
                this.btnSearch.Enabled = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSearch.Text) && this.lbDatabases.SelectedItems.Count > 0)
            {
                this.btnSearch.Enabled = true;
            }
            else
            {
                this.btnSearch.Enabled = false;
            }
        }

        #endregion

    }
}
