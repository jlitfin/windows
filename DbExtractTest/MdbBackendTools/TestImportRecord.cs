using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MdbExtractor;

namespace MdbBackendTools
{
    public partial class TestImportRecord : Form
    {
        public TestImportRecord()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var dlg = ofdRecordFile.ShowDialog();
            if (dlg.Equals(DialogResult.OK))
            {
                txtOpenFilePath.Text = ofdRecordFile.FileName;
                txtOutput.Clear();
                Application.DoEvents();
                using (var db = new MdbContext())
                using (var sr = new StreamReader(txtOpenFilePath.Text))
                {
                    var action = sr.ReadLine();
                    var fileDetail = db.FileDataDetails.SingleOrDefault(f => f.FileName == action);
                    if (fileDetail != null)
                    {
                        using (var repo = FileItemRepositoryFactory.GetInstance(fileDetail.ItemClassName))
                        {
                                var peek = string.Empty;
                                string source = null;

                                var sb = new StringBuilder();
                                while (true)
                                {
                                    try
                                    {
                                        //
                                        // capture read of new record open encountered below
                                        //
                                        sb = new StringBuilder();
                                        if (source != null)
                                        {
                                            sb = new StringBuilder();
                                            sb.AppendLine(source);
                                            printL(source);
                                            source = null;
                                        }

                                        
                                        peek = sr.ReadLine();
                                        if (peek == null)
                                        {
                                            break;
                                        }
                                        sb.AppendLine(peek);
                                        printL(peek);


                                        if (fileDetail.ReadAheadFor != null)
                                        {
                                            while ((peek = sr.ReadLine()) != null)
                                            {
                                                if (Regex.IsMatch(peek, fileDetail.ReadAheadFor))
                                                {
                                                    source = peek;
                                                    break;
                                                }

                                                if (!string.IsNullOrEmpty(peek))
                                                {
                                                    sb.AppendLine(peek);
                                                    printL(peek);
                                                }

                                            }
                                        }
                                        repo.AddOrUpdate(fileDetail.Id, sb.ToString());
                                    }

                                    catch (Exception ex)
                                    {
                                        printL();
                                        printL(ex.Message);
                                    }
                                }
                            
                        }
                    }
                }
            }
        }

        private void printL(string val = null)
        {
            if (!string.IsNullOrEmpty(val))
            {
                val = val.Trim();
                this.txtOutput.AppendText(val);
            }
            this.txtOutput.AppendText(Environment.NewLine);
            Application.DoEvents();
        }

    }
}
