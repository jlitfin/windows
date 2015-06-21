namespace SmsFilter
{
    partial class SmsFilter
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpeakerTwoString = new System.Windows.Forms.TextBox();
            this.txtSpeakerOneString = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.dlgBrowseForFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.txtSpeakerOneAlias = new System.Windows.Forms.TextBox();
            this.txtSpeakerTwoAlias = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSourceFolder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Speaker One String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Speaker Two String";
            // 
            // txtSpeakerTwoString
            // 
            this.txtSpeakerTwoString.Location = new System.Drawing.Point(7, 142);
            this.txtSpeakerTwoString.Name = "txtSpeakerTwoString";
            this.txtSpeakerTwoString.Size = new System.Drawing.Size(399, 20);
            this.txtSpeakerTwoString.TabIndex = 2;
            this.txtSpeakerTwoString.TextChanged += new System.EventHandler(this.txtSpeakerTwoString_TextChanged);
            // 
            // txtSpeakerOneString
            // 
            this.txtSpeakerOneString.Location = new System.Drawing.Point(7, 91);
            this.txtSpeakerOneString.Name = "txtSpeakerOneString";
            this.txtSpeakerOneString.Size = new System.Drawing.Size(399, 20);
            this.txtSpeakerOneString.TabIndex = 3;
            this.txtSpeakerOneString.TextChanged += new System.EventHandler(this.txtSpeakerOneString_TextChanged);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(10, 197);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(710, 197);
            this.txtResult.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(9, 12);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(147, 23);
            this.btnSelectFolder.TabIndex = 6;
            this.btnSelectFolder.Text = "Select Source Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(10, 418);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(710, 114);
            this.txtOutput.TabIndex = 7;
            // 
            // btnTranslate
            // 
            this.btnTranslate.Location = new System.Drawing.Point(10, 41);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(146, 23);
            this.btnTranslate.TabIndex = 8;
            this.btnTranslate.Text = "Translate";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // txtSpeakerOneAlias
            // 
            this.txtSpeakerOneAlias.Location = new System.Drawing.Point(427, 91);
            this.txtSpeakerOneAlias.Name = "txtSpeakerOneAlias";
            this.txtSpeakerOneAlias.Size = new System.Drawing.Size(290, 20);
            this.txtSpeakerOneAlias.TabIndex = 12;
            // 
            // txtSpeakerTwoAlias
            // 
            this.txtSpeakerTwoAlias.Location = new System.Drawing.Point(427, 142);
            this.txtSpeakerTwoAlias.Name = "txtSpeakerTwoAlias";
            this.txtSpeakerTwoAlias.Size = new System.Drawing.Size(290, 20);
            this.txtSpeakerTwoAlias.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Speaker Two Alias";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Speaker One Alias";
            // 
            // lblSourceFolder
            // 
            this.lblSourceFolder.AutoSize = true;
            this.lblSourceFolder.Location = new System.Drawing.Point(162, 17);
            this.lblSourceFolder.Name = "lblSourceFolder";
            this.lblSourceFolder.Size = new System.Drawing.Size(135, 13);
            this.lblSourceFolder.TabIndex = 13;
            this.lblSourceFolder.Text = "No Source Folder Selected";
            // 
            // SmsFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 560);
            this.Controls.Add(this.lblSourceFolder);
            this.Controls.Add(this.txtSpeakerOneAlias);
            this.Controls.Add(this.txtSpeakerTwoAlias);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtSpeakerOneString);
            this.Controls.Add(this.txtSpeakerTwoString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SmsFilter";
            this.Text = "Sms Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSpeakerTwoString;
        private System.Windows.Forms.TextBox txtSpeakerOneString;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog dlgBrowseForFolder;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.TextBox txtSpeakerOneAlias;
        private System.Windows.Forms.TextBox txtSpeakerTwoAlias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSourceFolder;
    }
}