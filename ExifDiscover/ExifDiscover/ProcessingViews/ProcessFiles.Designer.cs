namespace ExifDiscover.ProcessingViews
{
  partial class ProcessFiles
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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDataManagement = new System.Windows.Forms.Button();
            this.btnMoveFiles = new System.Windows.Forms.Button();
            this.btnViewBadNames = new System.Windows.Forms.Button();
            this.btnProcessFiles = new System.Windows.Forms.Button();
            this.dlgBrowsForFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOneTime = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(845, 469);
            this.txtOutput.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtOutput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 469);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOneTime);
            this.panel2.Controls.Add(this.btnDataManagement);
            this.panel2.Controls.Add(this.btnMoveFiles);
            this.panel2.Controls.Add(this.btnViewBadNames);
            this.panel2.Controls.Add(this.btnProcessFiles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(845, 77);
            this.panel2.TabIndex = 2;
            // 
            // btnDataManagement
            // 
            this.btnDataManagement.Location = new System.Drawing.Point(325, 12);
            this.btnDataManagement.Name = "btnDataManagement";
            this.btnDataManagement.Size = new System.Drawing.Size(79, 53);
            this.btnDataManagement.TabIndex = 3;
            this.btnDataManagement.Text = "Data Management";
            this.btnDataManagement.UseVisualStyleBackColor = true;
            this.btnDataManagement.Click += new System.EventHandler(this.btnDataManagement_Click);
            // 
            // btnMoveFiles
            // 
            this.btnMoveFiles.Location = new System.Drawing.Point(174, 12);
            this.btnMoveFiles.Name = "btnMoveFiles";
            this.btnMoveFiles.Size = new System.Drawing.Size(79, 53);
            this.btnMoveFiles.TabIndex = 2;
            this.btnMoveFiles.Text = "Move Files";
            this.btnMoveFiles.UseVisualStyleBackColor = true;
            this.btnMoveFiles.Click += new System.EventHandler(this.btnMoveFiles_Click);
            // 
            // btnViewBadNames
            // 
            this.btnViewBadNames.Location = new System.Drawing.Point(93, 12);
            this.btnViewBadNames.Name = "btnViewBadNames";
            this.btnViewBadNames.Size = new System.Drawing.Size(75, 53);
            this.btnViewBadNames.TabIndex = 1;
            this.btnViewBadNames.Text = "View Bad Names";
            this.btnViewBadNames.UseVisualStyleBackColor = true;
            this.btnViewBadNames.Click += new System.EventHandler(this.btnViewBadNames_Click);
            // 
            // btnProcessFiles
            // 
            this.btnProcessFiles.Location = new System.Drawing.Point(12, 12);
            this.btnProcessFiles.Name = "btnProcessFiles";
            this.btnProcessFiles.Size = new System.Drawing.Size(75, 53);
            this.btnProcessFiles.TabIndex = 0;
            this.btnProcessFiles.Text = "Process Files";
            this.btnProcessFiles.UseVisualStyleBackColor = true;
            this.btnProcessFiles.Click += new System.EventHandler(this.btnProcessFiles_Click);
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "openFileDialog1";
            // 
            // btnOneTime
            // 
            this.btnOneTime.Location = new System.Drawing.Point(737, 12);
            this.btnOneTime.Name = "btnOneTime";
            this.btnOneTime.Size = new System.Drawing.Size(79, 53);
            this.btnOneTime.TabIndex = 4;
            this.btnOneTime.Text = "One Time";
            this.btnOneTime.UseVisualStyleBackColor = true;
            this.btnOneTime.Visible = false;
            this.btnOneTime.Click += new System.EventHandler(this.btnOneTime_Click);
            // 
            // ProcessFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 546);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ProcessFiles";
            this.Text = "ProcessFiles";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtOutput;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnProcessFiles;
    private System.Windows.Forms.Button btnViewBadNames;
    private System.Windows.Forms.FolderBrowserDialog dlgBrowsForFolder;
    private System.Windows.Forms.Button btnMoveFiles;
    private System.Windows.Forms.Button btnDataManagement;
    private System.Windows.Forms.OpenFileDialog dlgOpenFile;
    private System.Windows.Forms.Button btnOneTime;
  }
}