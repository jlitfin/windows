namespace DatabaseInterrogator
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblConnection = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.cboServers = new System.Windows.Forms.ComboBox();
            this.btnDeleteServer = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitDbSelector = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDatabases = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeselectAllDbs = new System.Windows.Forms.Button();
            this.tabContext = new System.Windows.Forms.TabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.pnlSearchControls = new System.Windows.Forms.Panel();
            this.txtSearchResult = new System.Windows.Forms.RichTextBox();
            this.pnlSearcTabTop = new System.Windows.Forms.Panel();
            this.chkText = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabCompare = new System.Windows.Forms.TabPage();
            this.txtComparResult = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboCompareDatabase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCompareProcText = new System.Windows.Forms.CheckBox();
            this.cboCompareServer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDbSelector)).BeginInit();
            this.splitDbSelector.Panel1.SuspendLayout();
            this.splitDbSelector.Panel2.SuspendLayout();
            this.splitDbSelector.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabContext.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.pnlSearchControls.SuspendLayout();
            this.pnlSearcTabTop.SuspendLayout();
            this.tabCompare.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnection.Location = new System.Drawing.Point(16, 7);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(75, 13);
            this.lblConnection.TabIndex = 1;
            this.lblConnection.Text = "Primary Server";
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(1276, 121);
            this.txtOutput.TabIndex = 2;
            // 
            // btnAddServer
            // 
            this.btnAddServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddServer.Location = new System.Drawing.Point(365, 23);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(84, 24);
            this.btnAddServer.TabIndex = 6;
            this.btnAddServer.Text = "add";
            this.btnAddServer.UseVisualStyleBackColor = true;
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // cboServers
            // 
            this.cboServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServers.FormattingEnabled = true;
            this.cboServers.Location = new System.Drawing.Point(16, 24);
            this.cboServers.Name = "cboServers";
            this.cboServers.Size = new System.Drawing.Size(343, 21);
            this.cboServers.TabIndex = 7;
            this.cboServers.SelectedIndexChanged += new System.EventHandler(this.cboServers_SelectedIndexChanged);
            // 
            // btnDeleteServer
            // 
            this.btnDeleteServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteServer.Location = new System.Drawing.Point(454, 23);
            this.btnDeleteServer.Name = "btnDeleteServer";
            this.btnDeleteServer.Size = new System.Drawing.Size(84, 24);
            this.btnDeleteServer.TabIndex = 8;
            this.btnDeleteServer.Text = "delete";
            this.btnDeleteServer.UseVisualStyleBackColor = true;
            this.btnDeleteServer.Click += new System.EventHandler(this.btnDeleteServer_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cboServers);
            this.pnlTop.Controls.Add(this.btnDeleteServer);
            this.pnlTop.Controls.Add(this.lblConnection);
            this.pnlTop.Controls.Add(this.btnAddServer);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1276, 61);
            this.pnlTop.TabIndex = 9;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitMain.Location = new System.Drawing.Point(0, 61);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.splitDbSelector);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.txtOutput);
            this.splitMain.Size = new System.Drawing.Size(1276, 689);
            this.splitMain.SplitterDistance = 564;
            this.splitMain.TabIndex = 10;
            // 
            // splitDbSelector
            // 
            this.splitDbSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDbSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitDbSelector.Location = new System.Drawing.Point(0, 0);
            this.splitDbSelector.Name = "splitDbSelector";
            // 
            // splitDbSelector.Panel1
            // 
            this.splitDbSelector.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitDbSelector.Panel1.Controls.Add(this.panel2);
            this.splitDbSelector.Panel1MinSize = 250;
            // 
            // splitDbSelector.Panel2
            // 
            this.splitDbSelector.Panel2.BackColor = System.Drawing.Color.White;
            this.splitDbSelector.Panel2.Controls.Add(this.tabContext);
            this.splitDbSelector.Size = new System.Drawing.Size(1276, 564);
            this.splitDbSelector.SplitterDistance = 257;
            this.splitDbSelector.SplitterWidth = 8;
            this.splitDbSelector.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbDatabases);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.MinimumSize = new System.Drawing.Size(250, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(257, 564);
            this.panel2.TabIndex = 1;
            // 
            // lbDatabases
            // 
            this.lbDatabases.BackColor = System.Drawing.SystemColors.Control;
            this.lbDatabases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbDatabases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDatabases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDatabases.FormattingEnabled = true;
            this.lbDatabases.Location = new System.Drawing.Point(5, 36);
            this.lbDatabases.Name = "lbDatabases";
            this.lbDatabases.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbDatabases.Size = new System.Drawing.Size(243, 519);
            this.lbDatabases.TabIndex = 7;
            this.lbDatabases.SelectedIndexChanged += new System.EventHandler(this.lbDatabases_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnSelectAll);
            this.panel1.Controls.Add(this.btnDeselectAllDbs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 31);
            this.panel1.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(134, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(106, 23);
            this.btnSelectAll.TabIndex = 7;
            this.btnSelectAll.Text = " select all";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Visible = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAllDbs
            // 
            this.btnDeselectAllDbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeselectAllDbs.Location = new System.Drawing.Point(3, 3);
            this.btnDeselectAllDbs.Name = "btnDeselectAllDbs";
            this.btnDeselectAllDbs.Size = new System.Drawing.Size(106, 23);
            this.btnDeselectAllDbs.TabIndex = 6;
            this.btnDeselectAllDbs.Text = " deselect all";
            this.btnDeselectAllDbs.UseVisualStyleBackColor = true;
            this.btnDeselectAllDbs.Visible = false;
            this.btnDeselectAllDbs.Click += new System.EventHandler(this.btnDeselectAllDbs_Click);
            // 
            // tabContext
            // 
            this.tabContext.Controls.Add(this.tabSearch);
            this.tabContext.Controls.Add(this.tabCompare);
            this.tabContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabContext.Location = new System.Drawing.Point(0, 0);
            this.tabContext.Name = "tabContext";
            this.tabContext.SelectedIndex = 0;
            this.tabContext.Size = new System.Drawing.Size(1011, 564);
            this.tabContext.TabIndex = 0;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.pnlSearchControls);
            this.tabSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(1003, 538);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // pnlSearchControls
            // 
            this.pnlSearchControls.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearchControls.Controls.Add(this.txtSearchResult);
            this.pnlSearchControls.Controls.Add(this.pnlSearcTabTop);
            this.pnlSearchControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSearchControls.Location = new System.Drawing.Point(3, 3);
            this.pnlSearchControls.Name = "pnlSearchControls";
            this.pnlSearchControls.Size = new System.Drawing.Size(997, 532);
            this.pnlSearchControls.TabIndex = 7;
            this.pnlSearchControls.Visible = false;
            // 
            // txtSearchResult
            // 
            this.txtSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchResult.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchResult.Location = new System.Drawing.Point(0, 60);
            this.txtSearchResult.Name = "txtSearchResult";
            this.txtSearchResult.ReadOnly = true;
            this.txtSearchResult.Size = new System.Drawing.Size(997, 472);
            this.txtSearchResult.TabIndex = 6;
            this.txtSearchResult.Text = "";
            this.txtSearchResult.WordWrap = false;
            // 
            // pnlSearcTabTop
            // 
            this.pnlSearcTabTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearcTabTop.Controls.Add(this.chkText);
            this.pnlSearcTabTop.Controls.Add(this.label2);
            this.pnlSearcTabTop.Controls.Add(this.btnSearch);
            this.pnlSearcTabTop.Controls.Add(this.txtSearch);
            this.pnlSearcTabTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearcTabTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSearcTabTop.Location = new System.Drawing.Point(0, 0);
            this.pnlSearcTabTop.Name = "pnlSearcTabTop";
            this.pnlSearcTabTop.Size = new System.Drawing.Size(997, 60);
            this.pnlSearcTabTop.TabIndex = 0;
            // 
            // chkText
            // 
            this.chkText.AutoSize = true;
            this.chkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkText.Location = new System.Drawing.Point(464, 27);
            this.chkText.Name = "chkText";
            this.chkText.Size = new System.Drawing.Size(67, 17);
            this.chkText.TabIndex = 6;
            this.chkText.Text = "proc text";
            this.chkText.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search ";
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(364, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 24);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(15, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(343, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // tabCompare
            // 
            this.tabCompare.Controls.Add(this.txtComparResult);
            this.tabCompare.Controls.Add(this.panel4);
            this.tabCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCompare.Location = new System.Drawing.Point(4, 22);
            this.tabCompare.Name = "tabCompare";
            this.tabCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompare.Size = new System.Drawing.Size(1003, 538);
            this.tabCompare.TabIndex = 1;
            this.tabCompare.Text = "Compare";
            this.tabCompare.UseVisualStyleBackColor = true;
            // 
            // txtComparResult
            // 
            this.txtComparResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComparResult.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComparResult.Location = new System.Drawing.Point(3, 61);
            this.txtComparResult.Name = "txtComparResult";
            this.txtComparResult.ReadOnly = true;
            this.txtComparResult.Size = new System.Drawing.Size(997, 474);
            this.txtComparResult.TabIndex = 7;
            this.txtComparResult.Text = "";
            this.txtComparResult.WordWrap = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cboCompareDatabase);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.chkCompareProcText);
            this.panel4.Controls.Add(this.cboCompareServer);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnCompare);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(997, 58);
            this.panel4.TabIndex = 1;
            // 
            // cboCompareDatabase
            // 
            this.cboCompareDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompareDatabase.FormattingEnabled = true;
            this.cboCompareDatabase.Location = new System.Drawing.Point(368, 26);
            this.cboCompareDatabase.Name = "cboCompareDatabase";
            this.cboCompareDatabase.Size = new System.Drawing.Size(343, 21);
            this.cboCompareDatabase.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(366, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Compare Database";
            // 
            // chkCompareProcText
            // 
            this.chkCompareProcText.AutoSize = true;
            this.chkCompareProcText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompareProcText.Location = new System.Drawing.Point(809, 28);
            this.chkCompareProcText.Name = "chkCompareProcText";
            this.chkCompareProcText.Size = new System.Drawing.Size(67, 17);
            this.chkCompareProcText.TabIndex = 6;
            this.chkCompareProcText.Text = "proc text";
            this.chkCompareProcText.UseVisualStyleBackColor = true;
            // 
            // cboCompareServer
            // 
            this.cboCompareServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompareServer.FormattingEnabled = true;
            this.cboCompareServer.Location = new System.Drawing.Point(14, 26);
            this.cboCompareServer.Name = "cboCompareServer";
            this.cboCompareServer.Size = new System.Drawing.Size(343, 21);
            this.cboCompareServer.TabIndex = 0;
            this.cboCompareServer.SelectedIndexChanged += new System.EventHandler(this.cboCompareServer_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Compare Server";
            // 
            // btnCompare
            // 
            this.btnCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompare.Location = new System.Drawing.Point(717, 25);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(84, 24);
            this.btnCompare.TabIndex = 2;
            this.btnCompare.Text = "compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 750);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Interrogator";
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitDbSelector.Panel1.ResumeLayout(false);
            this.splitDbSelector.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDbSelector)).EndInit();
            this.splitDbSelector.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabContext.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.pnlSearchControls.ResumeLayout(false);
            this.pnlSearcTabTop.ResumeLayout(false);
            this.pnlSearcTabTop.PerformLayout();
            this.tabCompare.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnAddServer;
        private System.Windows.Forms.ComboBox cboServers;
        private System.Windows.Forms.Button btnDeleteServer;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TabControl tabContext;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TabPage tabCompare;
        private System.Windows.Forms.Panel pnlSearchControls;
        private System.Windows.Forms.SplitContainer splitDbSelector;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbDatabases;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkText;
        private System.Windows.Forms.RichTextBox txtSearchResult;
        private System.Windows.Forms.Panel pnlSearcTabTop;
        private System.Windows.Forms.ComboBox cboCompareServer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox txtComparResult;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkCompareProcText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.ComboBox cboCompareDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeselectAllDbs;
        private System.Windows.Forms.Button btnSelectAll;
    }
}