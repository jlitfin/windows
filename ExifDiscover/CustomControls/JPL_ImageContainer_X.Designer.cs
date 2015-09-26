namespace CustomControls
{
  partial class JPL_ImageContainer
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.pbImageCanvas = new System.Windows.Forms.PictureBox();
        this.pnlBackground = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)(this.pbImageCanvas)).BeginInit();
        this.pnlBackground.SuspendLayout();
        this.SuspendLayout();
        // 
        // pbImageCanvas
        // 
        this.pbImageCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pbImageCanvas.Location = new System.Drawing.Point(0, 0);
        this.pbImageCanvas.Margin = new System.Windows.Forms.Padding(0);
        this.pbImageCanvas.Name = "pbImageCanvas";
        this.pbImageCanvas.Size = new System.Drawing.Size(578, 308);
        this.pbImageCanvas.TabIndex = 0;
        this.pbImageCanvas.TabStop = false;
        this.pbImageCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JPL_ImageContainer_MouseDown);
        this.pbImageCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImageCanvas_MouseUp);
        // 
        // pnlBackground
        // 
        this.pnlBackground.Controls.Add(this.pbImageCanvas);
        this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlBackground.Location = new System.Drawing.Point(0, 0);
        this.pnlBackground.Margin = new System.Windows.Forms.Padding(0);
        this.pnlBackground.Name = "pnlBackground";
        this.pnlBackground.Size = new System.Drawing.Size(578, 308);
        this.pnlBackground.TabIndex = 1;
        // 
        // JPL_ImageContainer
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.Controls.Add(this.pnlBackground);
        this.Name = "JPL_ImageContainer";
        this.Size = new System.Drawing.Size(578, 308);
        this.Paint += new System.Windows.Forms.PaintEventHandler(this.JPL_ImageContainer_Paint);
        this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.JPL_ImageContainer_MouseMove);
        this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JPL_ImageContainer_MouseDown);
        this.Resize += new System.EventHandler(this.JPL_ImageContainer_Resize);
        this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JPL_ImageContainer_MouseUp);
        ((System.ComponentModel.ISupportInitialize)(this.pbImageCanvas)).EndInit();
        this.pnlBackground.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pbImageCanvas;
    private System.Windows.Forms.Panel pnlBackground;
  }
}
