namespace ReportListBuilder
{
    partial class frmReportFileBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportFileBuilder));
            this.pnlOutput = new System.Windows.Forms.Panel();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblSaveLocation = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnSelectSaveLocation = new System.Windows.Forms.Button();
            this.lblReportFileLocation = new System.Windows.Forms.Label();
            this.txtReportFileSourcePath = new System.Windows.Forms.TextBox();
            this.btnSourceFileSelect = new System.Windows.Forms.Button();
            this.dlgBrowseFolders = new System.Windows.Forms.FolderBrowserDialog();
            this.btnPreview = new System.Windows.Forms.Button();
            this.pnlOutput.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.grpControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOutput
            // 
            this.pnlOutput.Controls.Add(this.txtOutput);
            this.pnlOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOutput.Location = new System.Drawing.Point(0, 235);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(1110, 496);
            this.pnlOutput.TabIndex = 0;
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(1110, 496);
            this.txtOutput.TabIndex = 0;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.grpControls);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1110, 235);
            this.pnlControls.TabIndex = 1;
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.btnPreview);
            this.grpControls.Controls.Add(this.btnProcess);
            this.grpControls.Controls.Add(this.lblSaveLocation);
            this.grpControls.Controls.Add(this.txtSavePath);
            this.grpControls.Controls.Add(this.btnSelectSaveLocation);
            this.grpControls.Controls.Add(this.lblReportFileLocation);
            this.grpControls.Controls.Add(this.txtReportFileSourcePath);
            this.grpControls.Controls.Add(this.btnSourceFileSelect);
            this.grpControls.Location = new System.Drawing.Point(12, 12);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(1082, 187);
            this.grpControls.TabIndex = 0;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "Report File Selector";
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(979, 139);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblSaveLocation
            // 
            this.lblSaveLocation.AutoSize = true;
            this.lblSaveLocation.Location = new System.Drawing.Point(12, 80);
            this.lblSaveLocation.Name = "lblSaveLocation";
            this.lblSaveLocation.Size = new System.Drawing.Size(149, 13);
            this.lblSaveLocation.TabIndex = 5;
            this.lblSaveLocation.Text = "Report List File Save Location";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(12, 95);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(961, 20);
            this.txtSavePath.TabIndex = 4;
            this.txtSavePath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // btnSelectSaveLocation
            // 
            this.btnSelectSaveLocation.Location = new System.Drawing.Point(979, 93);
            this.btnSelectSaveLocation.Name = "btnSelectSaveLocation";
            this.btnSelectSaveLocation.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSaveLocation.TabIndex = 3;
            this.btnSelectSaveLocation.Text = "Select";
            this.btnSelectSaveLocation.UseVisualStyleBackColor = true;
            this.btnSelectSaveLocation.Click += new System.EventHandler(this.btnSelectSaveLocation_Click);
            // 
            // lblReportFileLocation
            // 
            this.lblReportFileLocation.AutoSize = true;
            this.lblReportFileLocation.Location = new System.Drawing.Point(12, 31);
            this.lblReportFileLocation.Name = "lblReportFileLocation";
            this.lblReportFileLocation.Size = new System.Drawing.Size(139, 13);
            this.lblReportFileLocation.TabIndex = 2;
            this.lblReportFileLocation.Text = "Report File Source Location";
            // 
            // txtReportFileSourcePath
            // 
            this.txtReportFileSourcePath.Location = new System.Drawing.Point(12, 46);
            this.txtReportFileSourcePath.Name = "txtReportFileSourcePath";
            this.txtReportFileSourcePath.Size = new System.Drawing.Size(961, 20);
            this.txtReportFileSourcePath.TabIndex = 1;
            this.txtReportFileSourcePath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // btnSourceFileSelect
            // 
            this.btnSourceFileSelect.Location = new System.Drawing.Point(979, 44);
            this.btnSourceFileSelect.Name = "btnSourceFileSelect";
            this.btnSourceFileSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSourceFileSelect.TabIndex = 0;
            this.btnSourceFileSelect.Text = "Select";
            this.btnSourceFileSelect.UseVisualStyleBackColor = true;
            this.btnSourceFileSelect.Click += new System.EventHandler(this.btnSourceFileSelect_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Enabled = false;
            this.btnPreview.Location = new System.Drawing.Point(898, 139);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // frmReportFileBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 731);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportFileBuilder";
            this.Text = "Report File Builder";
            this.Load += new System.EventHandler(this.frmReportFileBuilder_Load);
            this.pnlOutput.ResumeLayout(false);
            this.pnlOutput.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOutput;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblSaveLocation;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnSelectSaveLocation;
        private System.Windows.Forms.Label lblReportFileLocation;
        private System.Windows.Forms.TextBox txtReportFileSourcePath;
        private System.Windows.Forms.Button btnSourceFileSelect;
        private System.Windows.Forms.FolderBrowserDialog dlgBrowseFolders;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnPreview;
    }
}

