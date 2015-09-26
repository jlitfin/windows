namespace Q3DemoCatalog
{
  partial class Setup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPrimaryDirectory = new System.Windows.Forms.Label();
            this.lblSecondaryDirectory = new System.Windows.Forms.Label();
            this.btnBrowsePrimary = new System.Windows.Forms.Button();
            this.btnBrowseSecondary = new System.Windows.Forms.Button();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSourceDirectory = new System.Windows.Forms.Label();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBaseq3 = new System.Windows.Forms.Label();
            this.btnSelectBaseq3 = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExecutable = new System.Windows.Forms.TextBox();
            this.txtCustomConfig = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(11, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primary";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(11, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Secondary (Mirror Directory)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(598, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select the source directory in which to search for files as well as the primary a" +
    "nd secondary (if desired) directories into which cataloged files should be place" +
    "d";
            // 
            // lblPrimaryDirectory
            // 
            this.lblPrimaryDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrimaryDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblPrimaryDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrimaryDirectory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimaryDirectory.ForeColor = System.Drawing.Color.Orange;
            this.lblPrimaryDirectory.Location = new System.Drawing.Point(45, 121);
            this.lblPrimaryDirectory.Name = "lblPrimaryDirectory";
            this.lblPrimaryDirectory.Size = new System.Drawing.Size(602, 23);
            this.lblPrimaryDirectory.TabIndex = 3;
            this.lblPrimaryDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSecondaryDirectory
            // 
            this.lblSecondaryDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSecondaryDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblSecondaryDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecondaryDirectory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondaryDirectory.ForeColor = System.Drawing.Color.Orange;
            this.lblSecondaryDirectory.Location = new System.Drawing.Point(45, 178);
            this.lblSecondaryDirectory.Name = "lblSecondaryDirectory";
            this.lblSecondaryDirectory.Size = new System.Drawing.Size(602, 23);
            this.lblSecondaryDirectory.TabIndex = 4;
            this.lblSecondaryDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowsePrimary
            // 
            this.btnBrowsePrimary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnBrowsePrimary.FlatAppearance.BorderSize = 0;
            this.btnBrowsePrimary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowsePrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowsePrimary.ForeColor = System.Drawing.Color.Orange;
            this.btnBrowsePrimary.Location = new System.Drawing.Point(15, 120);
            this.btnBrowsePrimary.Name = "btnBrowsePrimary";
            this.btnBrowsePrimary.Size = new System.Drawing.Size(24, 24);
            this.btnBrowsePrimary.TabIndex = 5;
            this.btnBrowsePrimary.Text = "...";
            this.btnBrowsePrimary.UseVisualStyleBackColor = false;
            this.btnBrowsePrimary.Click += new System.EventHandler(this.btnBrowsePrimary_Click);
            // 
            // btnBrowseSecondary
            // 
            this.btnBrowseSecondary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnBrowseSecondary.FlatAppearance.BorderSize = 0;
            this.btnBrowseSecondary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseSecondary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSecondary.ForeColor = System.Drawing.Color.Orange;
            this.btnBrowseSecondary.Location = new System.Drawing.Point(15, 177);
            this.btnBrowseSecondary.Name = "btnBrowseSecondary";
            this.btnBrowseSecondary.Size = new System.Drawing.Size(24, 24);
            this.btnBrowseSecondary.TabIndex = 6;
            this.btnBrowseSecondary.Text = "...";
            this.btnBrowseSecondary.UseVisualStyleBackColor = false;
            this.btnBrowseSecondary.Click += new System.EventHandler(this.btnBrowseSecondary_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(11, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Source";
            // 
            // lblSourceDirectory
            // 
            this.lblSourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSourceDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblSourceDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSourceDirectory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceDirectory.ForeColor = System.Drawing.Color.Orange;
            this.lblSourceDirectory.Location = new System.Drawing.Point(44, 64);
            this.lblSourceDirectory.Name = "lblSourceDirectory";
            this.lblSourceDirectory.Size = new System.Drawing.Size(604, 23);
            this.lblSourceDirectory.TabIndex = 10;
            this.lblSourceDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnBrowseSource.FlatAppearance.BorderSize = 0;
            this.btnBrowseSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSource.ForeColor = System.Drawing.Color.Orange;
            this.btnBrowseSource.Location = new System.Drawing.Point(14, 63);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(25, 24);
            this.btnBrowseSource.TabIndex = 11;
            this.btnBrowseSource.Text = "...";
            this.btnBrowseSource.UseVisualStyleBackColor = false;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.Orange;
            this.btnOK.Location = new System.Drawing.Point(505, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.lblOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Orange;
            this.btnCancel.Location = new System.Drawing.Point(586, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.lblCancel_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Controls.Add(this.txtCustomConfig);
            this.pnlContent.Controls.Add(this.label7);
            this.pnlContent.Controls.Add(this.txtExecutable);
            this.pnlContent.Controls.Add(this.label6);
            this.pnlContent.Controls.Add(this.label5);
            this.pnlContent.Controls.Add(this.lblBaseq3);
            this.pnlContent.Controls.Add(this.btnSelectBaseq3);
            this.pnlContent.Controls.Add(this.label3);
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Controls.Add(this.label2);
            this.pnlContent.Controls.Add(this.btnBrowseSource);
            this.pnlContent.Controls.Add(this.lblPrimaryDirectory);
            this.pnlContent.Controls.Add(this.lblSourceDirectory);
            this.pnlContent.Controls.Add(this.lblSecondaryDirectory);
            this.pnlContent.Controls.Add(this.label4);
            this.pnlContent.Controls.Add(this.btnBrowsePrimary);
            this.pnlContent.Controls.Add(this.btnBrowseSecondary);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(673, 402);
            this.pnlContent.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(12, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Select your baseq3 directory";
            // 
            // lblBaseq3
            // 
            this.lblBaseq3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaseq3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblBaseq3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBaseq3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseq3.ForeColor = System.Drawing.Color.Orange;
            this.lblBaseq3.Location = new System.Drawing.Point(46, 237);
            this.lblBaseq3.Name = "lblBaseq3";
            this.lblBaseq3.Size = new System.Drawing.Size(602, 23);
            this.lblBaseq3.TabIndex = 13;
            this.lblBaseq3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectBaseq3
            // 
            this.btnSelectBaseq3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnSelectBaseq3.FlatAppearance.BorderSize = 0;
            this.btnSelectBaseq3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectBaseq3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectBaseq3.ForeColor = System.Drawing.Color.Orange;
            this.btnSelectBaseq3.Location = new System.Drawing.Point(16, 236);
            this.btnSelectBaseq3.Name = "btnSelectBaseq3";
            this.btnSelectBaseq3.Size = new System.Drawing.Size(24, 24);
            this.btnSelectBaseq3.TabIndex = 14;
            this.btnSelectBaseq3.Text = "...";
            this.btnSelectBaseq3.UseVisualStyleBackColor = false;
            this.btnSelectBaseq3.Click += new System.EventHandler(this.btnSelectBaseq3_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 402);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(673, 47);
            this.pnlButtons.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(12, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Type Exectuable";
            // 
            // txtExecutable
            // 
            this.txtExecutable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtExecutable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExecutable.ForeColor = System.Drawing.Color.Orange;
            this.txtExecutable.Location = new System.Drawing.Point(46, 294);
            this.txtExecutable.Name = "txtExecutable";
            this.txtExecutable.Size = new System.Drawing.Size(602, 20);
            this.txtExecutable.TabIndex = 17;
            this.txtExecutable.Text = "quake3.exe";
            this.txtExecutable.TextChanged += new System.EventHandler(this.txtExecutable_TextChanged);
            // 
            // txtCustomConfig
            // 
            this.txtCustomConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtCustomConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomConfig.ForeColor = System.Drawing.Color.Orange;
            this.txtCustomConfig.Location = new System.Drawing.Point(45, 350);
            this.txtCustomConfig.Name = "txtCustomConfig";
            this.txtCustomConfig.Size = new System.Drawing.Size(602, 20);
            this.txtCustomConfig.TabIndex = 19;
            this.txtCustomConfig.TextChanged += new System.EventHandler(this.txtCustomConfig_TextChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(11, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Custom Config?";
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(673, 449);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setup";
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.Setup_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblPrimaryDirectory;
    private System.Windows.Forms.Label lblSecondaryDirectory;
    private System.Windows.Forms.Button btnBrowsePrimary;
    private System.Windows.Forms.Button btnBrowseSecondary;
    private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lblSourceDirectory;
    private System.Windows.Forms.Button btnBrowseSource;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Panel pnlContent;
    private System.Windows.Forms.Panel pnlButtons;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblBaseq3;
    private System.Windows.Forms.Button btnSelectBaseq3;
    private System.Windows.Forms.TextBox txtExecutable;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtCustomConfig;
    private System.Windows.Forms.Label label7;
  }
}