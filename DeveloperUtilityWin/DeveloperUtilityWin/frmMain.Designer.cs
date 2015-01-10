namespace DeveloperUtilityWin
{
    partial class frmMain
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
            this.txtInputSet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProcName = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLeftBottom = new System.Windows.Forms.Panel();
            this.pnlLeftTop = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLookupKeyField = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrimaryKeyField = new System.Windows.Forms.TextBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.grpDatabase = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSchema = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCatalog = new System.Windows.Forms.TextBox();
            this.btnCheckDbTable = new System.Windows.Forms.Button();
            this.grpEDSClass = new System.Windows.Forms.GroupBox();
            this.btnEdsInsert = new System.Windows.Forms.Button();
            this.btnEdsSelect = new System.Windows.Forms.Button();
            this.btnEdsClass = new System.Windows.Forms.Button();
            this.grpStanardClass = new System.Windows.Forms.GroupBox();
            this.btnStandardUpsert = new System.Windows.Forms.Button();
            this.btnStandardUpdate = new System.Windows.Forms.Button();
            this.btnStandardInsert = new System.Windows.Forms.Button();
            this.btnStandardSelect = new System.Windows.Forms.Button();
            this.btnStandardRepository = new System.Windows.Forms.Button();
            this.btnCreateStandardClass = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tpObjectModel = new System.Windows.Forms.TabPage();
            this.tpDatabaseCompare = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCompareDbs = new System.Windows.Forms.Button();
            this.lblDbLeftDescription = new System.Windows.Forms.Label();
            this.txtDbCompare = new System.Windows.Forms.TextBox();
            this.pnlDbCompareRightTop = new System.Windows.Forms.Panel();
            this.lblDbRightDescription = new System.Windows.Forms.Label();
            this.lbTableList = new System.Windows.Forms.ListBox();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftBottom.SuspendLayout();
            this.pnlLeftTop.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpDatabase.SuspendLayout();
            this.grpEDSClass.SuspendLayout();
            this.grpStanardClass.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tpObjectModel.SuspendLayout();
            this.tpDatabaseCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlDbCompareRightTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInputSet
            // 
            this.txtInputSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInputSet.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputSet.Location = new System.Drawing.Point(0, 0);
            this.txtInputSet.Multiline = true;
            this.txtInputSet.Name = "txtInputSet";
            this.txtInputSet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInputSet.Size = new System.Drawing.Size(697, 634);
            this.txtInputSet.TabIndex = 0;
            this.txtInputSet.WordWrap = false;
            this.txtInputSet.TextChanged += new System.EventHandler(this.txtInputSet_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Paste Input Set";
            // 
            // txtProcName
            // 
            this.txtProcName.Location = new System.Drawing.Point(28, 208);
            this.txtProcName.Name = "txtProcName";
            this.txtProcName.Size = new System.Drawing.Size(309, 20);
            this.txtProcName.TabIndex = 3;
            this.txtProcName.TextChanged += new System.EventHandler(this.txtProcName_TextChanged);
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(28, 166);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(309, 20);
            this.txtTableName.TabIndex = 2;
            this.txtTableName.TextChanged += new System.EventHandler(this.txtTableName_TextChanged);
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(28, 34);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(309, 20);
            this.txtClassName.TabIndex = 1;
            this.txtClassName.TextChanged += new System.EventHandler(this.txtClassName_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Procedure Name (no suffix)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Table Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Class Name";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlLeftBottom);
            this.pnlLeft.Controls.Add(this.pnlLeftTop);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(697, 670);
            this.pnlLeft.TabIndex = 17;
            // 
            // pnlLeftBottom
            // 
            this.pnlLeftBottom.Controls.Add(this.txtInputSet);
            this.pnlLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftBottom.Location = new System.Drawing.Point(0, 36);
            this.pnlLeftBottom.Name = "pnlLeftBottom";
            this.pnlLeftBottom.Size = new System.Drawing.Size(697, 634);
            this.pnlLeftBottom.TabIndex = 3;
            // 
            // pnlLeftTop
            // 
            this.pnlLeftTop.Controls.Add(this.label1);
            this.pnlLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftTop.Name = "pnlLeftTop";
            this.pnlLeftTop.Size = new System.Drawing.Size(697, 36);
            this.pnlLeftTop.TabIndex = 2;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.label7);
            this.pnlRight.Controls.Add(this.txtLookupKeyField);
            this.pnlRight.Controls.Add(this.label6);
            this.pnlRight.Controls.Add(this.txtPrimaryKeyField);
            this.pnlRight.Controls.Add(this.chkAuto);
            this.pnlRight.Controls.Add(this.grpDatabase);
            this.pnlRight.Controls.Add(this.grpEDSClass);
            this.pnlRight.Controls.Add(this.grpStanardClass);
            this.pnlRight.Controls.Add(this.label4);
            this.pnlRight.Controls.Add(this.label9);
            this.pnlRight.Controls.Add(this.txtProcName);
            this.pnlRight.Controls.Add(this.label10);
            this.pnlRight.Controls.Add(this.txtTableName);
            this.pnlRight.Controls.Add(this.txtClassName);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(700, 3);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(368, 670);
            this.pnlRight.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Lookup Key Field (if secondary caching)";
            // 
            // txtLookupKeyField
            // 
            this.txtLookupKeyField.Location = new System.Drawing.Point(28, 122);
            this.txtLookupKeyField.Name = "txtLookupKeyField";
            this.txtLookupKeyField.Size = new System.Drawing.Size(309, 20);
            this.txtLookupKeyField.TabIndex = 24;
            this.txtLookupKeyField.TextChanged += new System.EventHandler(this.txtLookupKeyField_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Primary Key Field";
            // 
            // txtPrimaryKeyField
            // 
            this.txtPrimaryKeyField.Location = new System.Drawing.Point(28, 80);
            this.txtPrimaryKeyField.Name = "txtPrimaryKeyField";
            this.txtPrimaryKeyField.Size = new System.Drawing.Size(309, 20);
            this.txtPrimaryKeyField.TabIndex = 22;
            this.txtPrimaryKeyField.TextChanged += new System.EventHandler(this.txtPrimaryKeyField_TextChanged);
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(250, 14);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(86, 17);
            this.chkAuto.TabIndex = 21;
            this.chkAuto.Text = "Auto Update";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // grpDatabase
            // 
            this.grpDatabase.Controls.Add(this.label5);
            this.grpDatabase.Controls.Add(this.txtConnectionString);
            this.grpDatabase.Controls.Add(this.label3);
            this.grpDatabase.Controls.Add(this.txtSchema);
            this.grpDatabase.Controls.Add(this.label2);
            this.grpDatabase.Controls.Add(this.txtCatalog);
            this.grpDatabase.Controls.Add(this.btnCheckDbTable);
            this.grpDatabase.Location = new System.Drawing.Point(28, 490);
            this.grpDatabase.Name = "grpDatabase";
            this.grpDatabase.Size = new System.Drawing.Size(309, 160);
            this.grpDatabase.TabIndex = 20;
            this.grpDatabase.TabStop = false;
            this.grpDatabase.Text = "Database";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Connection";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(17, 35);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(101, 20);
            this.txtConnectionString.TabIndex = 4;
            this.txtConnectionString.TextChanged += new System.EventHandler(this.txtConnectionString_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Schema";
            // 
            // txtSchema
            // 
            this.txtSchema.Location = new System.Drawing.Point(17, 130);
            this.txtSchema.Name = "txtSchema";
            this.txtSchema.Size = new System.Drawing.Size(101, 20);
            this.txtSchema.TabIndex = 6;
            this.txtSchema.Text = "dbo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Catalog";
            // 
            // txtCatalog
            // 
            this.txtCatalog.Location = new System.Drawing.Point(17, 83);
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(101, 20);
            this.txtCatalog.TabIndex = 5;
            // 
            // btnCheckDbTable
            // 
            this.btnCheckDbTable.Location = new System.Drawing.Point(162, 35);
            this.btnCheckDbTable.Name = "btnCheckDbTable";
            this.btnCheckDbTable.Size = new System.Drawing.Size(130, 23);
            this.btnCheckDbTable.TabIndex = 20;
            this.btnCheckDbTable.TabStop = false;
            this.btnCheckDbTable.Text = "Compare To Table";
            this.btnCheckDbTable.UseVisualStyleBackColor = true;
            this.btnCheckDbTable.Click += new System.EventHandler(this.btnCheckDbTable_Click);
            // 
            // grpEDSClass
            // 
            this.grpEDSClass.Controls.Add(this.btnEdsInsert);
            this.grpEDSClass.Controls.Add(this.btnEdsSelect);
            this.grpEDSClass.Controls.Add(this.btnEdsClass);
            this.grpEDSClass.Location = new System.Drawing.Point(28, 395);
            this.grpEDSClass.Name = "grpEDSClass";
            this.grpEDSClass.Size = new System.Drawing.Size(309, 89);
            this.grpEDSClass.TabIndex = 19;
            this.grpEDSClass.TabStop = false;
            this.grpEDSClass.Text = "EDS Class";
            // 
            // btnEdsInsert
            // 
            this.btnEdsInsert.Location = new System.Drawing.Point(162, 57);
            this.btnEdsInsert.Name = "btnEdsInsert";
            this.btnEdsInsert.Size = new System.Drawing.Size(130, 23);
            this.btnEdsInsert.TabIndex = 19;
            this.btnEdsInsert.TabStop = false;
            this.btnEdsInsert.Text = "EDS Insert";
            this.btnEdsInsert.UseVisualStyleBackColor = true;
            this.btnEdsInsert.Click += new System.EventHandler(this.btnEdsInsert_Click);
            // 
            // btnEdsSelect
            // 
            this.btnEdsSelect.Location = new System.Drawing.Point(162, 28);
            this.btnEdsSelect.Name = "btnEdsSelect";
            this.btnEdsSelect.Size = new System.Drawing.Size(130, 23);
            this.btnEdsSelect.TabIndex = 18;
            this.btnEdsSelect.TabStop = false;
            this.btnEdsSelect.Text = "EDS Select";
            this.btnEdsSelect.UseVisualStyleBackColor = true;
            this.btnEdsSelect.Click += new System.EventHandler(this.btnEdsSelect_Click);
            // 
            // btnEdsClass
            // 
            this.btnEdsClass.Location = new System.Drawing.Point(17, 28);
            this.btnEdsClass.Name = "btnEdsClass";
            this.btnEdsClass.Size = new System.Drawing.Size(130, 23);
            this.btnEdsClass.TabIndex = 17;
            this.btnEdsClass.TabStop = false;
            this.btnEdsClass.Text = "EDS Class";
            this.btnEdsClass.UseVisualStyleBackColor = true;
            this.btnEdsClass.Click += new System.EventHandler(this.btnEdsClass_Click);
            // 
            // grpStanardClass
            // 
            this.grpStanardClass.Controls.Add(this.btnStandardUpsert);
            this.grpStanardClass.Controls.Add(this.btnStandardUpdate);
            this.grpStanardClass.Controls.Add(this.btnStandardInsert);
            this.grpStanardClass.Controls.Add(this.btnStandardSelect);
            this.grpStanardClass.Controls.Add(this.btnStandardRepository);
            this.grpStanardClass.Controls.Add(this.btnCreateStandardClass);
            this.grpStanardClass.Location = new System.Drawing.Point(28, 241);
            this.grpStanardClass.Name = "grpStanardClass";
            this.grpStanardClass.Size = new System.Drawing.Size(309, 148);
            this.grpStanardClass.TabIndex = 18;
            this.grpStanardClass.TabStop = false;
            this.grpStanardClass.Text = "Standard Class";
            // 
            // btnStandardUpsert
            // 
            this.btnStandardUpsert.Location = new System.Drawing.Point(162, 110);
            this.btnStandardUpsert.Name = "btnStandardUpsert";
            this.btnStandardUpsert.Size = new System.Drawing.Size(130, 23);
            this.btnStandardUpsert.TabIndex = 22;
            this.btnStandardUpsert.TabStop = false;
            this.btnStandardUpsert.Text = "Standard UpSERT";
            this.btnStandardUpsert.UseVisualStyleBackColor = true;
            this.btnStandardUpsert.Click += new System.EventHandler(this.btnStandardUpsert_Click);
            // 
            // btnStandardUpdate
            // 
            this.btnStandardUpdate.Location = new System.Drawing.Point(162, 81);
            this.btnStandardUpdate.Name = "btnStandardUpdate";
            this.btnStandardUpdate.Size = new System.Drawing.Size(130, 23);
            this.btnStandardUpdate.TabIndex = 21;
            this.btnStandardUpdate.TabStop = false;
            this.btnStandardUpdate.Text = "Standard Update";
            this.btnStandardUpdate.UseVisualStyleBackColor = true;
            this.btnStandardUpdate.Click += new System.EventHandler(this.btnStandardUpdate_Click);
            // 
            // btnStandardInsert
            // 
            this.btnStandardInsert.Location = new System.Drawing.Point(162, 52);
            this.btnStandardInsert.Name = "btnStandardInsert";
            this.btnStandardInsert.Size = new System.Drawing.Size(130, 23);
            this.btnStandardInsert.TabIndex = 20;
            this.btnStandardInsert.TabStop = false;
            this.btnStandardInsert.Text = "Standard Insert";
            this.btnStandardInsert.UseVisualStyleBackColor = true;
            this.btnStandardInsert.Click += new System.EventHandler(this.btnStandardInsert_Click);
            // 
            // btnStandardSelect
            // 
            this.btnStandardSelect.Location = new System.Drawing.Point(162, 23);
            this.btnStandardSelect.Name = "btnStandardSelect";
            this.btnStandardSelect.Size = new System.Drawing.Size(130, 23);
            this.btnStandardSelect.TabIndex = 19;
            this.btnStandardSelect.TabStop = false;
            this.btnStandardSelect.Text = "Standard Select";
            this.btnStandardSelect.UseVisualStyleBackColor = true;
            this.btnStandardSelect.Click += new System.EventHandler(this.btnStandardSelect_Click);
            // 
            // btnStandardRepository
            // 
            this.btnStandardRepository.Location = new System.Drawing.Point(17, 52);
            this.btnStandardRepository.Name = "btnStandardRepository";
            this.btnStandardRepository.Size = new System.Drawing.Size(130, 23);
            this.btnStandardRepository.TabIndex = 18;
            this.btnStandardRepository.TabStop = false;
            this.btnStandardRepository.Text = "Standard Repository";
            this.btnStandardRepository.UseVisualStyleBackColor = true;
            this.btnStandardRepository.Click += new System.EventHandler(this.btnStandardRepository_Click);
            // 
            // btnCreateStandardClass
            // 
            this.btnCreateStandardClass.Location = new System.Drawing.Point(17, 23);
            this.btnCreateStandardClass.Name = "btnCreateStandardClass";
            this.btnCreateStandardClass.Size = new System.Drawing.Size(130, 23);
            this.btnCreateStandardClass.TabIndex = 17;
            this.btnCreateStandardClass.TabStop = false;
            this.btnCreateStandardClass.Text = "Standard Class";
            this.btnCreateStandardClass.UseVisualStyleBackColor = true;
            this.btnCreateStandardClass.Click += new System.EventHandler(this.btnCreateStandardClass_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tpObjectModel);
            this.tabControlMain.Controls.Add(this.tpDatabaseCompare);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1079, 702);
            this.tabControlMain.TabIndex = 19;
            // 
            // tpObjectModel
            // 
            this.tpObjectModel.Controls.Add(this.pnlLeft);
            this.tpObjectModel.Controls.Add(this.pnlRight);
            this.tpObjectModel.Location = new System.Drawing.Point(4, 22);
            this.tpObjectModel.Name = "tpObjectModel";
            this.tpObjectModel.Padding = new System.Windows.Forms.Padding(3);
            this.tpObjectModel.Size = new System.Drawing.Size(1071, 676);
            this.tpObjectModel.TabIndex = 0;
            this.tpObjectModel.Text = "Object Model";
            this.tpObjectModel.UseVisualStyleBackColor = true;
            // 
            // tpDatabaseCompare
            // 
            this.tpDatabaseCompare.Controls.Add(this.splitContainer1);
            this.tpDatabaseCompare.Location = new System.Drawing.Point(4, 22);
            this.tpDatabaseCompare.Name = "tpDatabaseCompare";
            this.tpDatabaseCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tpDatabaseCompare.Size = new System.Drawing.Size(1071, 676);
            this.tpDatabaseCompare.TabIndex = 1;
            this.tpDatabaseCompare.Text = "Database Compare";
            this.tpDatabaseCompare.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbTableList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtDbCompare);
            this.splitContainer1.Panel2.Controls.Add(this.pnlDbCompareRightTop);
            this.splitContainer1.Size = new System.Drawing.Size(1065, 670);
            this.splitContainer1.SplitterDistance = 271;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnCompareDbs
            // 
            this.btnCompareDbs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompareDbs.Location = new System.Drawing.Point(699, 34);
            this.btnCompareDbs.Name = "btnCompareDbs";
            this.btnCompareDbs.Size = new System.Drawing.Size(75, 23);
            this.btnCompareDbs.TabIndex = 5;
            this.btnCompareDbs.Text = "Compare";
            this.btnCompareDbs.UseVisualStyleBackColor = true;
            this.btnCompareDbs.Click += new System.EventHandler(this.btnCompareDbs_Click);
            // 
            // lblDbLeftDescription
            // 
            this.lblDbLeftDescription.AutoSize = true;
            this.lblDbLeftDescription.Location = new System.Drawing.Point(12, 10);
            this.lblDbLeftDescription.Name = "lblDbLeftDescription";
            this.lblDbLeftDescription.Size = new System.Drawing.Size(127, 13);
            this.lblDbLeftDescription.TabIndex = 0;
            this.lblDbLeftDescription.Text = "DB LEFT DESCRIPTION";
            // 
            // txtDbCompare
            // 
            this.txtDbCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDbCompare.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbCompare.Location = new System.Drawing.Point(0, 63);
            this.txtDbCompare.Multiline = true;
            this.txtDbCompare.Name = "txtDbCompare";
            this.txtDbCompare.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDbCompare.Size = new System.Drawing.Size(790, 607);
            this.txtDbCompare.TabIndex = 2;
            // 
            // pnlDbCompareRightTop
            // 
            this.pnlDbCompareRightTop.Controls.Add(this.btnCompareDbs);
            this.pnlDbCompareRightTop.Controls.Add(this.lblDbRightDescription);
            this.pnlDbCompareRightTop.Controls.Add(this.lblDbLeftDescription);
            this.pnlDbCompareRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDbCompareRightTop.Location = new System.Drawing.Point(0, 0);
            this.pnlDbCompareRightTop.Name = "pnlDbCompareRightTop";
            this.pnlDbCompareRightTop.Size = new System.Drawing.Size(790, 63);
            this.pnlDbCompareRightTop.TabIndex = 1;
            // 
            // lblDbRightDescription
            // 
            this.lblDbRightDescription.AutoSize = true;
            this.lblDbRightDescription.Location = new System.Drawing.Point(12, 32);
            this.lblDbRightDescription.Name = "lblDbRightDescription";
            this.lblDbRightDescription.Size = new System.Drawing.Size(135, 13);
            this.lblDbRightDescription.TabIndex = 1;
            this.lblDbRightDescription.Text = "DB RIGHT DESCRIPTION";
            // 
            // lbTableList
            // 
            this.lbTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTableList.FormattingEnabled = true;
            this.lbTableList.Location = new System.Drawing.Point(0, 0);
            this.lbTableList.Name = "lbTableList";
            this.lbTableList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbTableList.Size = new System.Drawing.Size(271, 670);
            this.lbTableList.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 702);
            this.Controls.Add(this.tabControlMain);
            this.Name = "frmMain";
            this.Text = "Developer Utility";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeftBottom.ResumeLayout(false);
            this.pnlLeftBottom.PerformLayout();
            this.pnlLeftTop.ResumeLayout(false);
            this.pnlLeftTop.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.grpDatabase.ResumeLayout(false);
            this.grpDatabase.PerformLayout();
            this.grpEDSClass.ResumeLayout(false);
            this.grpStanardClass.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tpObjectModel.ResumeLayout(false);
            this.tpDatabaseCompare.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlDbCompareRightTop.ResumeLayout(false);
            this.pnlDbCompareRightTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProcName;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlLeftBottom;
        private System.Windows.Forms.Panel pnlLeftTop;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnCreateStandardClass;
        private System.Windows.Forms.GroupBox grpEDSClass;
        private System.Windows.Forms.Button btnEdsClass;
        private System.Windows.Forms.GroupBox grpStanardClass;
        private System.Windows.Forms.Button btnStandardRepository;
        private System.Windows.Forms.Button btnEdsInsert;
        private System.Windows.Forms.Button btnEdsSelect;
        private System.Windows.Forms.GroupBox grpDatabase;
        private System.Windows.Forms.Button btnCheckDbTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSchema;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCatalog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnStandardInsert;
        private System.Windows.Forms.Button btnStandardSelect;
        private System.Windows.Forms.Button btnStandardUpdate;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.Button btnStandardUpsert;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLookupKeyField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrimaryKeyField;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tpObjectModel;
        private System.Windows.Forms.TabPage tpDatabaseCompare;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlDbCompareRightTop;
        private System.Windows.Forms.Button btnCompareDbs;
        private System.Windows.Forms.Label lblDbLeftDescription;
        private System.Windows.Forms.Label lblDbRightDescription;
        private System.Windows.Forms.TextBox txtDbCompare;
        private System.Windows.Forms.ListBox lbTableList;

    }
}

