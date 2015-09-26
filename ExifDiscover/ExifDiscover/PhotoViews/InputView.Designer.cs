namespace ExifDiscover.PhotoViews
{
    partial class InputView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.icMain = new CustomControls.JPL_ImageContainer();
            this.tcImageData = new System.Windows.Forms.TabControl();
            this.tpPhotoData = new System.Windows.Forms.TabPage();
            this.dgvPhotoData = new System.Windows.Forms.DataGridView();
            this.bindPhotoGrid = new System.Windows.Forms.BindingSource(this.components);
            this.tpExifData = new System.Windows.Forms.TabPage();
            this.dgvExifData = new System.Windows.Forms.DataGridView();
            this.colExifField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExifValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindExifGrid = new System.Windows.Forms.BindingSource(this.components);
            this.colPropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tcImageData.SuspendLayout();
            this.tpPhotoData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotoData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindPhotoGrid)).BeginInit();
            this.tpExifData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExifData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindExifGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.icMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcImageData);
            this.splitContainer1.Size = new System.Drawing.Size(1192, 625);
            this.splitContainer1.SplitterDistance = 827;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // icMain
            // 
            this.icMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.icMain.Image = null;
            this.icMain.Location = new System.Drawing.Point(12, 12);
            this.icMain.Name = "icMain";
            this.icMain.Size = new System.Drawing.Size(800, 600);
            this.icMain.TabIndex = 0;
            this.icMain.Tag = "InputView";
            // 
            // tcImageData
            // 
            this.tcImageData.Controls.Add(this.tpPhotoData);
            this.tcImageData.Controls.Add(this.tpExifData);
            this.tcImageData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcImageData.Location = new System.Drawing.Point(0, 0);
            this.tcImageData.Name = "tcImageData";
            this.tcImageData.SelectedIndex = 0;
            this.tcImageData.Size = new System.Drawing.Size(357, 625);
            this.tcImageData.TabIndex = 1;
            // 
            // tpPhotoData
            // 
            this.tpPhotoData.Controls.Add(this.dgvPhotoData);
            this.tpPhotoData.Location = new System.Drawing.Point(4, 22);
            this.tpPhotoData.Name = "tpPhotoData";
            this.tpPhotoData.Padding = new System.Windows.Forms.Padding(3);
            this.tpPhotoData.Size = new System.Drawing.Size(349, 599);
            this.tpPhotoData.TabIndex = 0;
            this.tpPhotoData.Text = "Photo Data";
            this.tpPhotoData.UseVisualStyleBackColor = true;
            this.tpPhotoData.Enter += new System.EventHandler(this.tpPhotoData_Enter);
            // 
            // dgvPhotoData
            // 
            this.dgvPhotoData.AutoGenerateColumns = false;
            this.dgvPhotoData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPhotoData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhotoData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPropertyName,
            this.colPropertyValue});
            this.dgvPhotoData.DataSource = this.bindPhotoGrid;
            this.dgvPhotoData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhotoData.Location = new System.Drawing.Point(3, 3);
            this.dgvPhotoData.Name = "dgvPhotoData";
            this.dgvPhotoData.RowHeadersVisible = false;
            this.dgvPhotoData.Size = new System.Drawing.Size(343, 593);
            this.dgvPhotoData.TabIndex = 0;
            this.dgvPhotoData.Resize += new System.EventHandler(this.dgvPhotoData_Resize);
            // 
            // tpExifData
            // 
            this.tpExifData.Controls.Add(this.dgvExifData);
            this.tpExifData.Location = new System.Drawing.Point(4, 22);
            this.tpExifData.Name = "tpExifData";
            this.tpExifData.Padding = new System.Windows.Forms.Padding(3);
            this.tpExifData.Size = new System.Drawing.Size(349, 599);
            this.tpExifData.TabIndex = 1;
            this.tpExifData.Text = "Exif Data";
            this.tpExifData.UseVisualStyleBackColor = true;
            this.tpExifData.Enter += new System.EventHandler(this.tpExifData_Enter);
            // 
            // dgvExifData
            // 
            this.dgvExifData.AutoGenerateColumns = false;
            this.dgvExifData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvExifData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExifData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colExifField,
            this.colExifValue});
            this.dgvExifData.DataSource = this.bindExifGrid;
            this.dgvExifData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExifData.Location = new System.Drawing.Point(3, 3);
            this.dgvExifData.Name = "dgvExifData";
            this.dgvExifData.RowHeadersVisible = false;
            this.dgvExifData.Size = new System.Drawing.Size(343, 593);
            this.dgvExifData.TabIndex = 0;
            this.dgvExifData.Resize += new System.EventHandler(this.dgvExifData_Resize);
            // 
            // colExifField
            // 
            this.colExifField.DataPropertyName = "Name";
            this.colExifField.FillWeight = 20F;
            this.colExifField.HeaderText = "Exif Field";
            this.colExifField.Name = "colExifField";
            this.colExifField.ReadOnly = true;
            // 
            // colExifValue
            // 
            this.colExifValue.DataPropertyName = "BytesString";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colExifValue.DefaultCellStyle = dataGridViewCellStyle6;
            this.colExifValue.FillWeight = 80F;
            this.colExifValue.HeaderText = "Value";
            this.colExifValue.Name = "colExifValue";
            this.colExifValue.ReadOnly = true;
            // 
            // colPropertyName
            // 
            this.colPropertyName.DataPropertyName = "PropertyName";
            this.colPropertyName.HeaderText = "Property";
            this.colPropertyName.Name = "colPropertyName";
            this.colPropertyName.ReadOnly = true;
            this.colPropertyName.Width = 71;
            // 
            // colPropertyValue
            // 
            this.colPropertyValue.DataPropertyName = "PropertyValue";
            this.colPropertyValue.HeaderText = "Value";
            this.colPropertyValue.Name = "colPropertyValue";
            this.colPropertyValue.Width = 59;
            // 
            // InputView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1192, 625);
            this.Controls.Add(this.splitContainer1);
            this.Name = "InputView";
            this.Load += new System.EventHandler(this.InputView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tcImageData.ResumeLayout(false);
            this.tpPhotoData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotoData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindPhotoGrid)).EndInit();
            this.tpExifData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExifData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindExifGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CustomControls.JPL_ImageContainer icMain;
        private System.Windows.Forms.TabControl tcImageData;
        private System.Windows.Forms.TabPage tpPhotoData;
        private System.Windows.Forms.TabPage tpExifData;
        private System.Windows.Forms.DataGridView dgvExifData;
        private System.Windows.Forms.BindingSource bindExifGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExifField;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExifValue;
        private System.Windows.Forms.DataGridView dgvPhotoData;
        private System.Windows.Forms.BindingSource bindPhotoGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropertyValue;
    }
}
