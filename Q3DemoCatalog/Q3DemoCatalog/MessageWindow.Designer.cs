namespace Q3DemoCatalog
{
  partial class MessageWindow
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
      this.txtMessages = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // txtMessages
      // 
      this.txtMessages.BackColor = System.Drawing.Color.Black;
      this.txtMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtMessages.ForeColor = System.Drawing.Color.Red;
      this.txtMessages.Location = new System.Drawing.Point(12, 12);
      this.txtMessages.Multiline = true;
      this.txtMessages.Name = "txtMessages";
      this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtMessages.Size = new System.Drawing.Size(456, 301);
      this.txtMessages.TabIndex = 0;
      // 
      // MessageWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(476, 325);
      this.ControlBox = false;
      this.Controls.Add(this.txtMessages);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "MessageWindow";
      this.Opacity = 0.8;
      this.Text = "MessageWindow";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtMessages;
  }
}