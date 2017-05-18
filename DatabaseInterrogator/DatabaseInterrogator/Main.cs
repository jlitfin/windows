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

//
// BG    = 30,30,30
// FG    = 220,220,220
// H     = 38,79,120
// CTRL  = 45,45,48
// CTRL2 = 51,51,51
// SPC   = 184,215,120

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

        private void highlightQueryString()
        {
            List<int> indexes = new List<int>();
            string str = this.txtSearch.Text.ToUpper();
            string src = this.txtSearchResult.Text.ToUpper();

            int j = src.IndexOf(str, 0);
            while (j != -1)
            {
                indexes.Add(j);
                if (j + str.Length < src.Length)
                {
                    j = src.IndexOf(str, j + str.Length);
                }
                else
                {
                    break;
                }
            }

            foreach (var n in indexes)
            {
                this.txtSearchResult.Select(n, str.Length);
                this.txtSearchResult.SelectionBackColor = Color.FromArgb(38, 79, 120);
            }
            
            
        }

        private void displayCompareResult(List<CompareResult> list)
        {
            this.txtComparResult.Clear();
            if (list != null && list.Count > 0)
            {
                string c0h = "OBJECT";
                string c12h = list[0].ObjectServer + "." + list[0].ObjectDatabase;
                string c3h = "STATUS";
                string c45h = list[0].CompareServer + "." + list[0].CompareDatabase;

                int c0, c1, c2, c3, c4, c5;
                c0 = c1 = c2 = c3 = c4 = c5 = 0;
                int buffer = 2;
                list = list.OrderBy(cr => cr.ComparisonType).ToList();

                foreach (var r in list)
                {
                    if (r.ComparisonType.Length > c0) c0 = r.ComparisonType.Length;
                    if (r.ObjectType.Length > c1) c1 = r.ObjectType.Length;
                    if (r.ObjectId.Length > c2) c2 = r.ObjectId.Length;
                    if (r.CompareStatus.Length > c3) c3 = r.CompareStatus.Length;
                    if (r.CompareObjectType.Length > c4) c4 = r.CompareObjectType.Length;
                    if (r.CompareObjectId.Length > c5) c5 = r.CompareObjectId.Length;
                }

                if (c0 < c0h.Length) c0 = c0h.Length;
                if (c1 + Math.Max(c2, c5) < c12h.Length) c2 = c12h.Length - c1;
                if (c3 < c3h.Length) c3 = c3h.Length;
                if (c4 + Math.Max(c2, c5) < c45h.Length) c5 = c45h.Length - c4;
                string formath = "  {0, -" + (c0).ToString() +
                    "}  {1, -" + (c1 + Math.Max(c2, c5) + buffer).ToString() +
                    "}  {2, -" + (c3).ToString() +
                    "}  {3, -" + (c4 + c5 + buffer).ToString() + "}\r\n";
                string hdr = string.Format(formath, c0h, c12h, c3h, c45h);
                this.txtComparResult.AppendText(hdr);
                this.txtComparResult.AppendText("\r\n".PadLeft(buffer * 7 + c0 + c1 + Math.Max(c2,c5) * 2 + c3 + c4, '-'));

                string format = "  {0, -" + (c0).ToString() +
                    "}  {1, -" + (c1).ToString() +
                    "}  {2,  " + (Math.Max(c2, c5)).ToString() +
                    "}  {3, -" + (c3).ToString() +
                    "}  {5, -" + (Math.Max(c2, c5)).ToString() +
                    "}  {4, -" + (c4).ToString() + "}\r\n";

                foreach (var r in list)
                {
                    this.txtComparResult.AppendText(
                        string.Format(format,
                            r.ComparisonType,
                            r.ObjectType,
                            r.ObjectId,
                            r.CompareStatus,
                            r.CompareObjectType,
                            r.CompareObjectId
                            ));
                }
            }
            else
            {
                this.txtComparResult.AppendText("No differences found.");
            }
        }

        private void displaySearchResult(List<SearchResult> list)
        {
            this.txtSearchResult.Clear();
            StringBuilder displayText = new StringBuilder();
            if (list != null && list.Count > 0)
            {
                int c1 = 0;
                int c2 = 0;
                int c3 = 0;
                int c4 = 0;
                int c5 = 0;
                int buffer = 2;
                foreach (var sr in list)
                {
                    c1 = (sr.ObjectType.Length > c1) ? sr.ObjectType.Length : c1;
                    c2 = (sr.ObjectSchema.Length > c2) ? sr.ObjectSchema.Length : c2;
                    c3 = sr.SearchableType.Equals("TEXT") ?
                            (sr.ObjectName.Length > c3) ? sr.ObjectName.Length : c3 :
                            (sr.ObjectSearchable.Length > c3) ? sr.ObjectSearchable.Length : c3;
                    c4 = (sr.Server.Length > c4) ? sr.Server.Length : c4;
                    c5 = (sr.Database.Length > c5) ? sr.Database.Length : c5;
                }
                string format = "  {0, -" + (c1 + buffer).ToString() + "}{1, -" + (c2 + buffer).ToString() + "}{2, -" + (c3 + buffer).ToString() + "}{3, -" + (c4 + buffer).ToString() + "}{4, -" + (c5 + buffer).ToString() + "}\r\n";
                this.txtSearchResult.AppendText(string.Format(format, "TYPE", "SCHEMA", "OBJECT", "SERVER", "DATABASE"));
                this.txtSearchResult.AppendText("  -".PadRight(2 + c1 + c2 + c3 + c4 + c5 + (buffer * 3), '-') + "\r\n");
                
                foreach (var sr in list)
                {
                    if (sr.SearchableType.Equals("TEXT"))
                    {
                        displayText.AppendLine();
                        displayText.Append(string.Format(format, sr.ObjectType, sr.ObjectSchema, sr.ObjectName, sr.Server, sr.Database));
                        StringBuilder txt = new StringBuilder();

                        Encoder enc = Encoding.Default.GetEncoder();
                        char[] chars = sr.ObjectSearchable.ToCharArray();
                        int byteCount = enc.GetByteCount(chars, 0, chars.Length, true);
                        byte[] bytes = new Byte[byteCount];
                        enc.GetBytes(chars, 0, chars.Length, bytes, 0, true);
                        using (StreamReader rdr = new StreamReader(new MemoryStream(bytes)))
                        {
                            txt.AppendLine();
                            string line = string.Empty;
                            string format2 = "  {0, -" + (c1 + buffer).ToString() + "}{1}";
                            while ((line = rdr.ReadLine()) != null)
                            {
                                txt.AppendLine(string.Format(format2, " ", line));
                            }
                            txt.AppendLine();
                        }

                        displayText.Append(txt.ToString());
                    }
                    else
                    {
                        displayText.Append(string.Format(format, sr.ObjectType, sr.ObjectSchema, sr.ObjectSearchable, sr.Server, sr.Database));
                    }
                }
            }
            else
            {
                displayText.AppendLine("No Results.");
            }

            this.txtSearchResult.AppendText(displayText.ToString());
            highlightQueryString();
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
                updateDbList(server);
                log(string.Format("querying server {0}...", server), false);

                log("done.", true);
            }
            catch (Exception ex)
            {
                log(ex.Message, true);
                log(ex.StackTrace, true);
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
                try
                {
                    var cumulative = new List<SearchResult>();
                    foreach (var item in this.lbDatabases.SelectedItems)
                    {
                        Database db = item as Database;
                        if (db != null)
                        {
                            log(string.Format("searching {0}.{1} ...", db.Server, db.Name), false);
                            try
                            {
                                List<SearchResult> results = Repository.Search(db, this.txtSearch.Text, this.chkText.Checked);
                                cumulative.AddRange(results);
                                log(string.Format("located {0} results.", results.Count), true);
                            }
                            catch (Exception ex)
                            {
                                log(string.Format("error communicating with db: {0}", db.Name), true);
                                log(string.Format("{0}", ex.Message), true);
                                log(ex.StackTrace, true);
                            }
                        }
                    }
                    displaySearchResult(cumulative.OrderBy(r => r.ObjectSchema).ThenBy(r => r.ObjectType).ThenBy(r => r.ObjectSearchable).ToList());
                }
                catch (Exception ex)
                {
                    log(ex.Message, true);
                    log(ex.StackTrace, true);
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

            this.cboCompareServer.Items.Clear();
            this.cboCompareServer.Items.AddRange(Repository.ServerList.ToArray());
            this.cboCompareServer.SelectedIndex = 0;

            this.lbDatabases.Items.Clear();
        }

        private void updateDbList(string server)
        {
            var dblist = Repository.GetDatabases(server);
            dblist.Sort();
            if (dblist != null && dblist.Count > 0)
            {
                this.lbDatabases.Items.Clear();
                this.lbDatabases.Items.AddRange(dblist.ToArray());
                this.pnlSearchControls.Visible = true;
                this.btnSearch.Enabled = false;
                this.btnSelectAll.Visible = true;
                this.btnDeselectAllDbs.Visible = true;
            }
            else
            {
                this.pnlSearchControls.Visible = false;
                this.btnSelectAll.Visible = false;
                this.btnDeselectAllDbs.Visible = false;
            }
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

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (this.cboServers.SelectedIndex != 0 && 
                this.cboCompareServer.SelectedIndex != 0 && 
                this.lbDatabases.SelectedItems.Count == 1 &&
                this.cboCompareDatabase.SelectedIndex != -1)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string primary = this.cboServers.SelectedItem.ToString();
                    string secondary = this.cboCompareServer.SelectedItem.ToString();
                    string pdb = this.lbDatabases.SelectedItem.ToString();
                    string sdb = this.cboCompareDatabase.SelectedItem.ToString();

                    log(string.Format("comparing {0}.{1} with {2}.{1} ...", primary, pdb, secondary));
                    List<CompareResult> list = Repository.Compare(primary, secondary, pdb, sdb, chkCompareProcText.Checked);
                    log("done.", true);
                    displayCompareResult(list);
                }
                catch (Exception ex)
                {
                    this.txtComparResult.Text = ex.Message;
                    log(ex.StackTrace, true);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                this.txtComparResult.Text = "Select a valid primary server and a single database.";
            }
        }

        private void cboCompareServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var server = this.cboCompareServer.SelectedItem.ToString();
                if (server.Equals(Repository.SERVER_LIST_DEFAULT_VALUE)) return;

                log(string.Format("querying server {0}...", server), false);
                var dblist = Repository.GetDatabases(server);
                dblist.Sort();
                if (dblist != null && dblist.Count > 0)
                {
                    this.cboCompareDatabase.Items.Clear();
                    this.cboCompareDatabase.Items.AddRange(dblist.ToArray());
                }
                log("done.", true);
            }
            catch (Exception ex)
            {
                log(ex.Message, true);
                log(ex.StackTrace, true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnDeleteServer_Click(object sender, EventArgs e)
        {
            if (!this.cboServers.SelectedItem.ToString().Equals(Repository.SERVER_LIST_DEFAULT_VALUE))
            {
                DialogResult dr = MessageBox.Show(
                    string.Format("Really delete this server? {0}", this.cboServers.SelectedItem.ToString()),
                    "Confirm Delete",
                    MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    Repository.DeleteServer(this.cboServers.SelectedItem.ToString());
                    updateServersList();
                }
            }
        }

        private void btnDeselectAllDbs_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lbDatabases.Items.Count; ++i)
            {
                this.lbDatabases.SetSelected(i, false);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lbDatabases.Items.Count; ++i)
            {
                this.lbDatabases.SetSelected(i, true);
            }
        }

        #endregion








    }
}
