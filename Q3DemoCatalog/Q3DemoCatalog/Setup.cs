using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Q3DemoCatalog
{
    public partial class Setup : Form
    {
        public string SourcePath = string.Empty;
        public string PrimaryPath = string.Empty;
        public string SecondaryPath = string.Empty;
        public string Baseq3Path = string.Empty;
        public string Executable = string.Empty;
        public string CustomConfig = string.Empty;

        public Setup()
        {
            InitializeComponent();
        }


        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            this.dlgFolderBrowser.ShowDialog();
            string path = this.dlgFolderBrowser.SelectedPath;
            if (path != null && path.Length > 0)
            {
                if (!ValidatePath(path, false))
                {
                    //dir does not exist
                    MessageBox.Show("Directory does not exist, or you do not have read permissions for it.");
                    path = string.Empty;
                }
                this.lblSourceDirectory.Text = path;
                SourcePath = path;
            }
        }

        private void btnBrowseSecondary_Click(object sender, EventArgs e)
        {
            this.dlgFolderBrowser.ShowDialog();
            string path = this.dlgFolderBrowser.SelectedPath;
            if (path != null && path.Length > 0)
            {
                if (!ValidatePath(path, true))
                {
                    //dir does not exist
                    MessageBox.Show("Directory does not exist, or you do not have write permissions for it.");
                    path = string.Empty;
                }
                this.lblSecondaryDirectory.Text = path;
                SecondaryPath = path;
            }
        }

        private void btnBrowsePrimary_Click(object sender, EventArgs e)
        {
            this.dlgFolderBrowser.ShowDialog();
            string path = this.dlgFolderBrowser.SelectedPath;
            if (path != null && path.Length > 0)
            {
                if (!ValidatePath(path, true))
                {
                    //dir does not exist
                    MessageBox.Show("Directory does not exist, or you do not have write permissions for it.");
                    path = string.Empty;
                }

                this.lblPrimaryDirectory.Text = path;
                PrimaryPath = path;
            }
        }

        private void btnSelectBaseq3_Click(object sender, EventArgs e)
        {
            this.dlgFolderBrowser.ShowDialog();
            string path = this.dlgFolderBrowser.SelectedPath;
            if (path != null && path.Length > 0)
            {
                if (!ValidatePath(path, true))
                {
                    //dir does not exist
                    MessageBox.Show("Directory does not exist, or you do not have write permissions for it.");
                    path = string.Empty;
                }

                this.lblBaseq3.Text = path;
                this.Baseq3Path = path;
            }
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private bool ValidatePath(string path, bool writeAccess)
        {
            DirectoryInfo dInfo = new DirectoryInfo(path);
            if (dInfo.Exists)
            {
                if (!writeAccess)
                {
                    return true;
                }

                FileInfo fInfo;
                try
                {
                    fInfo = new FileInfo(path + @"\" + "q3dcAT.splat");
                    using (StreamWriter sw = new StreamWriter(path + @"\" + "q3dcAT.splat"))
                    {
                        sw.WriteLine("write test.");
                        sw.Flush();
                    }
                }
                catch
                {
                    return false;
                }

                fInfo.Delete();
                return true;
            }

            return false;
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            this.lblSourceDirectory.Text = SourcePath;
            this.lblPrimaryDirectory.Text = PrimaryPath;
            this.lblSecondaryDirectory.Text = SecondaryPath;
            this.lblBaseq3.Text = Baseq3Path;
            this.txtExecutable.Text = Executable;
            this.txtCustomConfig.Text = CustomConfig;
        }

        private void txtExecutable_TextChanged(object sender, EventArgs e)
        {
            Executable = this.txtExecutable.Text;
        }

        private void txtCustomConfig_TextChanged(object sender, EventArgs e)
        {
            CustomConfig = this.txtCustomConfig.Text;
        }
    }
}