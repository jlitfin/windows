namespace ExifDiscover
{
  partial class Form1
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
        this.btnInputView = new System.Windows.Forms.Button();
        this.btnClose = new System.Windows.Forms.Button();
        this.btnTest = new System.Windows.Forms.Button();
        this.btnImageTest = new System.Windows.Forms.Button();
        this.scControls = new System.Windows.Forms.SplitContainer();
        this.scMain = new System.Windows.Forms.SplitContainer();
        this.pnlDisplayList = new System.Windows.Forms.Panel();
        this.dlgBrowseFolders = new System.Windows.Forms.FolderBrowserDialog();
        this.scControls.Panel1.SuspendLayout();
        this.scControls.Panel2.SuspendLayout();
        this.scControls.SuspendLayout();
        this.scMain.Panel1.SuspendLayout();
        this.scMain.Panel2.SuspendLayout();
        this.scMain.SuspendLayout();
        this.SuspendLayout();
        // 
        // txtOutput
        // 
        this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
        this.txtOutput.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtOutput.Location = new System.Drawing.Point(0, 0);
        this.txtOutput.Multiline = true;
        this.txtOutput.Name = "txtOutput";
        this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtOutput.Size = new System.Drawing.Size(885, 96);
        this.txtOutput.TabIndex = 0;
        // 
        // btnInputView
        // 
        this.btnInputView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnInputView.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnInputView.Location = new System.Drawing.Point(5, 5);
        this.btnInputView.Name = "btnInputView";
        this.btnInputView.Size = new System.Drawing.Size(105, 61);
        this.btnInputView.TabIndex = 2;
        this.btnInputView.Text = "Input View";
        this.btnInputView.UseVisualStyleBackColor = true;
        this.btnInputView.Click += new System.EventHandler(this.btnInputView_Click);
        // 
        // btnClose
        // 
        this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnClose.Font = new System.Drawing.Font("Arial", 12F);
        this.btnClose.Location = new System.Drawing.Point(110, 5);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(105, 61);
        this.btnClose.TabIndex = 3;
        this.btnClose.Text = "Process Files View";
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        // 
        // btnTest
        // 
        this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnTest.Font = new System.Drawing.Font("Arial", 12F);
        this.btnTest.Location = new System.Drawing.Point(320, 5);
        this.btnTest.Name = "btnTest";
        this.btnTest.Size = new System.Drawing.Size(105, 61);
        this.btnTest.TabIndex = 1;
        this.btnTest.Text = "Test";
        this.btnTest.UseVisualStyleBackColor = true;
        this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
        // 
        // btnImageTest
        // 
        this.btnImageTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnImageTest.Font = new System.Drawing.Font("Arial", 12F);
        this.btnImageTest.Location = new System.Drawing.Point(215, 5);
        this.btnImageTest.Name = "btnImageTest";
        this.btnImageTest.Size = new System.Drawing.Size(105, 61);
        this.btnImageTest.TabIndex = 4;
        this.btnImageTest.Text = "Folder Photos";
        this.btnImageTest.UseVisualStyleBackColor = true;
        this.btnImageTest.Click += new System.EventHandler(this.btnImageTest_Click);
        // 
        // scControls
        // 
        this.scControls.Dock = System.Windows.Forms.DockStyle.Fill;
        this.scControls.Location = new System.Drawing.Point(0, 0);
        this.scControls.Name = "scControls";
        this.scControls.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // scControls.Panel1
        // 
        this.scControls.Panel1.Controls.Add(this.btnInputView);
        this.scControls.Panel1.Controls.Add(this.btnTest);
        this.scControls.Panel1.Controls.Add(this.btnImageTest);
        this.scControls.Panel1.Controls.Add(this.btnClose);
        // 
        // scControls.Panel2
        // 
        this.scControls.Panel2.Controls.Add(this.scMain);
        this.scControls.Size = new System.Drawing.Size(885, 518);
        this.scControls.SplitterDistance = 70;
        this.scControls.SplitterWidth = 8;
        this.scControls.TabIndex = 5;
        // 
        // scMain
        // 
        this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.scMain.Location = new System.Drawing.Point(0, 0);
        this.scMain.Name = "scMain";
        this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // scMain.Panel1
        // 
        this.scMain.Panel1.Controls.Add(this.pnlDisplayList);
        // 
        // scMain.Panel2
        // 
        this.scMain.Panel2.Controls.Add(this.txtOutput);
        this.scMain.Size = new System.Drawing.Size(885, 440);
        this.scMain.SplitterDistance = 336;
        this.scMain.SplitterWidth = 8;
        this.scMain.TabIndex = 1;
        // 
        // pnlDisplayList
        // 
        this.pnlDisplayList.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlDisplayList.Location = new System.Drawing.Point(0, 0);
        this.pnlDisplayList.Name = "pnlDisplayList";
        this.pnlDisplayList.Size = new System.Drawing.Size(885, 336);
        this.pnlDisplayList.TabIndex = 0;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(885, 518);
        this.Controls.Add(this.scControls);
        this.Name = "Form1";
        this.Text = "Unit Test";
        this.scControls.Panel1.ResumeLayout(false);
        this.scControls.Panel2.ResumeLayout(false);
        this.scControls.ResumeLayout(false);
        this.scMain.Panel1.ResumeLayout(false);
        this.scMain.Panel2.ResumeLayout(false);
        this.scMain.Panel2.PerformLayout();
        this.scMain.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtOutput;
    private System.Windows.Forms.Button btnInputView;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnTest;
    private System.Windows.Forms.Button btnImageTest;
    private System.Windows.Forms.SplitContainer scControls;
    private System.Windows.Forms.SplitContainer scMain;
    private System.Windows.Forms.Panel pnlDisplayList;
    private System.Windows.Forms.FolderBrowserDialog dlgBrowseFolders;
  }
}

