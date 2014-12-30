using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeveloperUtilityWin
{
    public partial class frmMain : Form
    {

        private TextTransform __xform = new TextTransform();

        private frmDisplayResult __edsClass;
        private frmDisplayResult __edsInsert;
        private frmDisplayResult __edsSelect;
        private frmDisplayResult __standardClass;
        private frmDisplayResult __standardInsert;
        private frmDisplayResult __standardRepository;
        private frmDisplayResult __standardSelect;
        private frmDisplayResult __standardUpdate;
        private frmDisplayResult __standardUpsert;
        private frmDisplayResult __tableCompare;


        public frmMain()
        {
            InitializeComponent();
        }

        private List<string> Lines
        {
            get
            {
                List<string> lines = new List<string>();
                for (int i = 0; i < txtInputSet.Lines.Length; ++i)
                {
                    if (!string.IsNullOrWhiteSpace(txtInputSet.Lines[i]))
                    {
                        lines.Add(txtInputSet.Lines[i]);
                    }
                }
                return lines;
            }
            set
            {
            }
        }
            
        private void txtInputSet_TextChanged(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();
            StringBuilder replace = new StringBuilder();

            for (int i = 0; i < txtInputSet.Lines.Length; ++i)
            {
                if (!string.IsNullOrWhiteSpace(txtInputSet.Lines[i]))
                {
                    lines.Add(txtInputSet.Lines[i]);
                    replace.AppendLine(txtInputSet.Lines[i]);
                }
            }

            this.txtInputSet.Text = replace.ToString();
        }

        private void txtTableName_TextChanged(object sender, EventArgs e)
        {
            if (__edsSelect != null && !__edsSelect.Disposing)
            {
                __edsSelect.DisplayText = __xform.GetEDSSelectAsFromTable(Lines, txtTableName.Text, txtProcName.Text);
            }

            if (__edsInsert != null && !__edsInsert.Disposing)
            {
                __edsInsert.DisplayText = __xform.GetEDSInsertProcFromTable(Lines, txtTableName.Text, txtProcName.Text);
            }
        }

        private void txtProcName_TextChanged(object sender, EventArgs e)
        {
            if (__edsSelect != null && !__edsSelect.Disposing)
            {
                __edsSelect.DisplayText = __xform.GetEDSSelectAsFromTable(Lines, txtTableName.Text, txtProcName.Text);
            }

            if (__edsInsert != null && !__edsInsert.Disposing)
            {
                __edsInsert.DisplayText = __xform.GetEDSInsertProcFromTable(Lines, txtTableName.Text, txtProcName.Text);
            }
        }

        private void txtClassName_TextChanged(object sender, EventArgs e)
        {
            if (__standardClass != null && !__standardClass.Disposing)
            {
                __standardClass.DisplayText = __xform.GetObjectFromTable(Lines, txtClassName.Text);
            }

            if (this.chkAuto.Checked)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("t_");
                sb.Append(__xform.SQLCase(txtClassName.Text));
                this.txtTableName.Text = sb.ToString();

                sb.Clear();
                sb.Append("dbo.prc_");
                sb.Append(__xform.SQLCase(txtClassName.Text));
                this.txtProcName.Text = sb.ToString();
            }
        }

        private void btnCreateStandardClass_Click(object sender, EventArgs e)
        {
            if (__standardClass != null)
            {
                __standardClass.Visible = false;
                __standardClass.Dispose();
            }

            __standardClass = new frmDisplayResult(__xform.GetObjectFromTable(Lines, txtClassName.Text));
            __standardClass.Text = "Standard Class";
            __standardClass.WindowState = FormWindowState.Normal;
            __standardClass.Visible = true;

        }

        private void btnStandardRepository_Click(object sender, EventArgs e)
        {
            if (__standardRepository != null)
            {
                __standardRepository.Visible = false;
                __standardRepository.Dispose();
            }
            __standardRepository = new frmDisplayResult(__xform.GetRepositoryMethods(Lines, txtClassName.Text));
            __standardRepository.Text = "Standard Repository";
            __standardRepository.WindowState = FormWindowState.Normal;
            __standardRepository.Visible = true;

        }

        private void btnEdsClass_Click(object sender, EventArgs e)
        {
            if (__edsClass != null)
            {
                __edsClass.Visible = false;
                __edsClass.Dispose();
            }

            __edsClass = new frmDisplayResult(__xform.GetEDSObjectFromTable(Lines, txtClassName.Text));
            __edsClass.Text = "EDS Class";
            __edsClass.WindowState = FormWindowState.Normal;
            __edsClass.Visible = true;
        }

        private void btnEdsSelect_Click(object sender, EventArgs e)
        {
            if (__edsSelect != null)
            {
                __edsSelect.Visible = false;
                __edsSelect.Dispose();
            }

            __edsSelect = new frmDisplayResult(__xform.GetEDSSelectAsFromTable(Lines, txtTableName.Text, txtProcName.Text));
            __edsSelect.Text = "EDS Select";
            __edsSelect.WindowState = FormWindowState.Normal;
            __edsSelect.Visible = true;
        }

        private void btnEdsInsert_Click(object sender, EventArgs e)
        {
            if (__edsInsert != null)
            {
                __edsInsert.Visible = false;
                __edsInsert.Dispose();
            }

            __edsInsert = new frmDisplayResult(__xform.GetEDSInsertProcFromTable(Lines, txtTableName.Text, txtProcName.Text));
            __edsInsert.Text = "EDS Insert";
            __edsInsert.WindowState = FormWindowState.Normal;
            __edsInsert.Visible = true;
        }

        private void btnCheckDbTable_Click(object sender, EventArgs e)
        {
            if (txtTableName.Text != null && txtTableName.Text.Length > 0 && txtCatalog.Text.Length > 0 && txtSchema.Text.Length > 0)
            {
                __tableCompare = new frmDisplayResult(__xform.GetTableComparison(Lines, txtCatalog.Text, txtSchema.Text, txtTableName.Text));
                __tableCompare.Text = "Table Comparison";
                __tableCompare.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                __tableCompare.WindowState = FormWindowState.Normal;
                __tableCompare.Visible = true;
            }
        }

        private void btnStandardSelect_Click(object sender, EventArgs e)
        {
            if (__standardSelect != null)
            {
                __standardSelect.Visible = false;
                __standardSelect.Dispose();
            }

            __standardSelect = new frmDisplayResult(__xform.GetSelectFromTable(Lines, txtTableName.Text, txtProcName.Text));
            __standardSelect.Text = "Standard Select";
            __standardSelect.WindowState = FormWindowState.Normal;
            __standardSelect.Visible = true;
        }

        private void btnStandardInsert_Click(object sender, EventArgs e)
        {
            if (__standardInsert != null)
            {
                __standardInsert.Visible = false;
                __standardInsert.Dispose();
            }

            __standardInsert = new frmDisplayResult(__xform.GetInsertProcFromTable(Lines, txtTableName.Text, txtProcName.Text));
            __standardInsert.Text = "Standard Insert";
            __standardInsert.WindowState = FormWindowState.Normal;
            __standardInsert.Visible = true;
        }

        private void btnStandardUpdate_Click(object sender, EventArgs e)
        {
            if (__standardUpdate != null)
            {
                __standardUpdate.Visible = false;
                __standardUpdate.Dispose();
            }

            __standardUpdate = new frmDisplayResult(__xform.GetUpdateFromTable(Lines, txtTableName.Text, txtProcName.Text));
            __standardUpdate.Text = "Standard Update";
            __standardUpdate.WindowState = FormWindowState.Normal;
            __standardUpdate.Visible = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            UtilityDataAccess.ConnectionString = txtConnectionString.Text;
        }

        private void btnStandardUpsert_Click(object sender, EventArgs e)
        {
            if (__standardUpsert != null)
            {
                __standardUpsert.Visible = false;
                __standardUpsert.Dispose();
            }

            __standardUpsert = new frmDisplayResult(__xform.GetUpsertProcFromTable(Lines, txtTableName.Text, txtClassName.Text, txtProcName.Text));
            __standardUpsert.Text = "Standard UpSERT";
            __standardUpsert.WindowState = FormWindowState.Normal;
            __standardUpsert.Visible = true;
        }




    }
}
