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
            this.lblConnection = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.cboServers = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.tabContext = new System.Windows.Forms.TabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.pnlSearchControls = new System.Windows.Forms.Panel();
            this.splitSearch = new System.Windows.Forms.SplitContainer();
            this.lbDatabases = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkDatabasesSelectAll = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabCompare = new System.Windows.Forms.TabPage();
            this.txtSearchResult = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.tabContext.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.pnlSearchControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSearch)).BeginInit();
            this.splitSearch.Panel1.SuspendLayout();
            this.splitSearch.Panel2.SuspendLayout();
            this.splitSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(16, 7);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(103, 11);
            this.lblConnection.TabIndex = 1;
            this.lblConnection.Text = "Primary Server";
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(1276, 221);
            this.txtOutput.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 11);
            this.label1.TabIndex = 4;
            this.label1.Text = "Databases";
            // 
            // btnAddServer
            // 
            this.btnAddServer.Location = new System.Drawing.Point(242, 23);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(84, 18);
            this.btnAddServer.TabIndex = 6;
            this.btnAddServer.Text = "add";
            this.btnAddServer.UseVisualStyleBackColor = true;
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // cboServers
            // 
            this.cboServers.FormattingEnabled = true;
            this.cboServers.Location = new System.Drawing.Point(16, 22);
            this.cboServers.Name = "cboServers";
            this.cboServers.Size = new System.Drawing.Size(221, 19);
            this.cboServers.TabIndex = 7;
            this.cboServers.SelectedIndexChanged += new System.EventHandler(this.cboServers_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(330, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 18);
            this.button1.TabIndex = 8;
            this.button1.Text = "delete";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cboServers);
            this.pnlTop.Controls.Add(this.button1);
            this.pnlTop.Controls.Add(this.lblConnection);
            this.pnlTop.Controls.Add(this.btnAddServer);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1276, 61);
            this.pnlTop.TabIndex = 9;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitMain.Location = new System.Drawing.Point(0, 61);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.tabContext);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.txtOutput);
            this.splitMain.Size = new System.Drawing.Size(1276, 689);
            this.splitMain.SplitterDistance = 464;
            this.splitMain.TabIndex = 10;
            // 
            // tabContext
            // 
            this.tabContext.Controls.Add(this.tabSearch);
            this.tabContext.Controls.Add(this.tabCompare);
            this.tabContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContext.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabContext.Location = new System.Drawing.Point(0, 0);
            this.tabContext.Name = "tabContext";
            this.tabContext.SelectedIndex = 0;
            this.tabContext.Size = new System.Drawing.Size(1276, 464);
            this.tabContext.TabIndex = 0;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.pnlSearchControls);
            this.tabSearch.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSearch.Location = new System.Drawing.Point(4, 21);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(1268, 439);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // pnlSearchControls
            // 
            this.pnlSearchControls.BackColor = System.Drawing.Color.LightGray;
            this.pnlSearchControls.Controls.Add(this.splitSearch);
            this.pnlSearchControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchControls.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSearchControls.Location = new System.Drawing.Point(3, 3);
            this.pnlSearchControls.Name = "pnlSearchControls";
            this.pnlSearchControls.Size = new System.Drawing.Size(1262, 433);
            this.pnlSearchControls.TabIndex = 7;
            this.pnlSearchControls.Visible = false;
            // 
            // splitSearch
            // 
            this.splitSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSearch.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitSearch.Location = new System.Drawing.Point(0, 0);
            this.splitSearch.Name = "splitSearch";
            // 
            // splitSearch.Panel1
            // 
            this.splitSearch.Panel1.BackColor = System.Drawing.Color.DarkGray;
            this.splitSearch.Panel1.Controls.Add(this.lbDatabases);
            this.splitSearch.Panel1.Controls.Add(this.panel1);
            // 
            // splitSearch.Panel2
            // 
            this.splitSearch.Panel2.BackColor = System.Drawing.Color.White;
            this.splitSearch.Panel2.Controls.Add(this.txtSearchResult);
            this.splitSearch.Panel2.Controls.Add(this.panel2);
            this.splitSearch.Size = new System.Drawing.Size(1262, 433);
            this.splitSearch.SplitterDistance = 255;
            this.splitSearch.SplitterWidth = 8;
            this.splitSearch.TabIndex = 7;
            // 
            // lbDatabases
            // 
            this.lbDatabases.BackColor = System.Drawing.SystemColors.Control;
            this.lbDatabases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbDatabases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDatabases.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDatabases.FormattingEnabled = true;
            this.lbDatabases.ItemHeight = 11;
            this.lbDatabases.Location = new System.Drawing.Point(0, 38);
            this.lbDatabases.Name = "lbDatabases";
            this.lbDatabases.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbDatabases.Size = new System.Drawing.Size(255, 395);
            this.lbDatabases.TabIndex = 7;
            this.lbDatabases.SelectedIndexChanged += new System.EventHandler(this.lbDatabases_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.chkDatabasesSelectAll);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 38);
            this.panel1.TabIndex = 0;
            // 
            // chkDatabasesSelectAll
            // 
            this.chkDatabasesSelectAll.AutoSize = true;
            this.chkDatabasesSelectAll.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDatabasesSelectAll.Location = new System.Drawing.Point(1, 17);
            this.chkDatabasesSelectAll.Name = "chkDatabasesSelectAll";
            this.chkDatabasesSelectAll.Size = new System.Drawing.Size(94, 15);
            this.chkDatabasesSelectAll.TabIndex = 5;
            this.chkDatabasesSelectAll.Text = "Select All";
            this.chkDatabasesSelectAll.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(999, 65);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 11);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search ";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(14, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(343, 18);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(363, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 18);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabCompare
            // 
            this.tabCompare.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCompare.Location = new System.Drawing.Point(4, 22);
            this.tabCompare.Name = "tabCompare";
            this.tabCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompare.Size = new System.Drawing.Size(1268, 438);
            this.tabCompare.TabIndex = 1;
            this.tabCompare.Text = "Compare";
            this.tabCompare.UseVisualStyleBackColor = true;
            // 
            // txtSearchResult
            // 
            this.txtSearchResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchResult.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchResult.Location = new System.Drawing.Point(0, 65);
            this.txtSearchResult.Multiline = true;
            this.txtSearchResult.Name = "txtSearchResult";
            this.txtSearchResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSearchResult.Size = new System.Drawing.Size(999, 368);
            this.txtSearchResult.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 750);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.tabContext.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.pnlSearchControls.ResumeLayout(false);
            this.splitSearch.Panel1.ResumeLayout(false);
            this.splitSearch.Panel2.ResumeLayout(false);
            this.splitSearch.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSearch)).EndInit();
            this.splitSearch.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddServer;
        private System.Windows.Forms.ComboBox cboServers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TabControl tabContext;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TabPage tabCompare;
        private System.Windows.Forms.Panel pnlSearchControls;
        private System.Windows.Forms.SplitContainer splitSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkDatabasesSelectAll;
        private System.Windows.Forms.ListBox lbDatabases;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSearchResult;
    }
}