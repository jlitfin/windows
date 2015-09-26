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
      this.pnlBackground = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // pnlBackground
      // 
      this.pnlBackground.BackColor = System.Drawing.Color.Transparent;
      this.pnlBackground.Location = new System.Drawing.Point(0, 0);
      this.pnlBackground.Name = "pnlBackground";
      this.pnlBackground.Size = new System.Drawing.Size(200, 100);
      this.pnlBackground.TabIndex = 0;
      // 
      // JPL_ImageContainer
      // 
      this.Layout += new System.Windows.Forms.LayoutEventHandler(this.JPL_ImageContainer_Layout);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlBackground;
  }
}
