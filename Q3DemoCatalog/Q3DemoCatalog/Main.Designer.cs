namespace Q3DemoCatalog
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.lblBaseQ3Directory = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkMirrorFiles = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkProcessPlayers = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSourceDirectory = new System.Windows.Forms.Label();
            this.chkDeleteDemos = new System.Windows.Forms.CheckBox();
            this.lblPrimaryDestination = new System.Windows.Forms.Label();
            this.lblFilesFound = new System.Windows.Forms.Label();
            this.lblSecondaryDestination = new System.Windows.Forms.Label();
            this.pnlOutput = new System.Windows.Forms.Panel();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.pnlPlayers = new System.Windows.Forms.Panel();
            this.scPlayers = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPlayers = new System.Windows.Forms.ListBox();
            this.lbGames = new System.Windows.Forms.ListBox();
            this.lblSelectAGame = new System.Windows.Forms.Label();
            this.pnlPlayersButtons = new System.Windows.Forms.Panel();
            this.btnWatchDemo = new System.Windows.Forms.Button();
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.lblExecutable = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            this.pnlOutput.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlPlayers.SuspendLayout();
            this.scPlayers.Panel1.SuspendLayout();
            this.scPlayers.Panel2.SuspendLayout();
            this.scPlayers.SuspendLayout();
            this.pnlPlayersButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.pnlDisplay);
            this.pnlMain.Controls.Add(this.pnlOutput);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.ForeColor = System.Drawing.Color.Gray;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(988, 648);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.AutoScroll = true;
            this.pnlDisplay.AutoScrollMinSize = new System.Drawing.Size(700, 345);
            this.pnlDisplay.BackColor = System.Drawing.Color.Transparent;
            this.pnlDisplay.Controls.Add(this.lblExecutable);
            this.pnlDisplay.Controls.Add(this.label10);
            this.pnlDisplay.Controls.Add(this.lblBaseQ3Directory);
            this.pnlDisplay.Controls.Add(this.label8);
            this.pnlDisplay.Controls.Add(this.btnProcess);
            this.pnlDisplay.Controls.Add(this.label1);
            this.pnlDisplay.Controls.Add(this.label3);
            this.pnlDisplay.Controls.Add(this.label4);
            this.pnlDisplay.Controls.Add(this.chkMirrorFiles);
            this.pnlDisplay.Controls.Add(this.label5);
            this.pnlDisplay.Controls.Add(this.chkProcessPlayers);
            this.pnlDisplay.Controls.Add(this.label6);
            this.pnlDisplay.Controls.Add(this.label7);
            this.pnlDisplay.Controls.Add(this.lblSourceDirectory);
            this.pnlDisplay.Controls.Add(this.chkDeleteDemos);
            this.pnlDisplay.Controls.Add(this.lblPrimaryDestination);
            this.pnlDisplay.Controls.Add(this.lblFilesFound);
            this.pnlDisplay.Controls.Add(this.lblSecondaryDestination);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(0, 0);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(988, 380);
            this.pnlDisplay.TabIndex = 21;
            // 
            // lblBaseQ3Directory
            // 
            this.lblBaseQ3Directory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaseQ3Directory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblBaseQ3Directory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBaseQ3Directory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseQ3Directory.ForeColor = System.Drawing.Color.Orange;
            this.lblBaseQ3Directory.Location = new System.Drawing.Point(135, 93);
            this.lblBaseQ3Directory.Name = "lblBaseQ3Directory";
            this.lblBaseQ3Directory.Size = new System.Drawing.Size(828, 23);
            this.lblBaseQ3Directory.TabIndex = 19;
            this.lblBaseQ3Directory.Text = "None selected (use setup)";
            this.lblBaseQ3Directory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(19, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "BaseQ3 Dir:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnProcess.FlatAppearance.BorderSize = 0;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.Color.Orange;
            this.btnProcess.Location = new System.Drawing.Point(888, 186);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 24);
            this.btnProcess.TabIndex = 15;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source directory:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(19, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Files found:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(19, -182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Status:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkMirrorFiles
            // 
            this.chkMirrorFiles.AutoSize = true;
            this.chkMirrorFiles.BackColor = System.Drawing.Color.Transparent;
            this.chkMirrorFiles.FlatAppearance.BorderSize = 0;
            this.chkMirrorFiles.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.chkMirrorFiles.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMirrorFiles.ForeColor = System.Drawing.Color.Gray;
            this.chkMirrorFiles.Location = new System.Drawing.Point(22, 213);
            this.chkMirrorFiles.Name = "chkMirrorFiles";
            this.chkMirrorFiles.Size = new System.Drawing.Size(263, 18);
            this.chkMirrorFiles.TabIndex = 17;
            this.chkMirrorFiles.Text = "Mirror files to Secondary (mirror) directory";
            this.chkMirrorFiles.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(19, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Primary:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkProcessPlayers
            // 
            this.chkProcessPlayers.AutoSize = true;
            this.chkProcessPlayers.BackColor = System.Drawing.Color.Transparent;
            this.chkProcessPlayers.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProcessPlayers.ForeColor = System.Drawing.Color.Gray;
            this.chkProcessPlayers.Location = new System.Drawing.Point(22, 250);
            this.chkProcessPlayers.Name = "chkProcessPlayers";
            this.chkProcessPlayers.Size = new System.Drawing.Size(116, 18);
            this.chkProcessPlayers.TabIndex = 3;
            this.chkProcessPlayers.Text = "Process Players";
            this.chkProcessPlayers.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(19, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Secondary:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(19, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Options:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSourceDirectory
            // 
            this.lblSourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSourceDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblSourceDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSourceDirectory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceDirectory.ForeColor = System.Drawing.Color.Orange;
            this.lblSourceDirectory.Location = new System.Drawing.Point(135, 9);
            this.lblSourceDirectory.Name = "lblSourceDirectory";
            this.lblSourceDirectory.Size = new System.Drawing.Size(828, 23);
            this.lblSourceDirectory.TabIndex = 6;
            this.lblSourceDirectory.Text = "None selected (use setup)";
            this.lblSourceDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDeleteDemos
            // 
            this.chkDeleteDemos.AutoSize = true;
            this.chkDeleteDemos.BackColor = System.Drawing.Color.Transparent;
            this.chkDeleteDemos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeleteDemos.ForeColor = System.Drawing.Color.Gray;
            this.chkDeleteDemos.Location = new System.Drawing.Point(22, 232);
            this.chkDeleteDemos.Name = "chkDeleteDemos";
            this.chkDeleteDemos.Size = new System.Drawing.Size(165, 18);
            this.chkDeleteDemos.TabIndex = 2;
            this.chkDeleteDemos.Text = "Delete source demo files";
            this.chkDeleteDemos.UseVisualStyleBackColor = false;
            // 
            // lblPrimaryDestination
            // 
            this.lblPrimaryDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrimaryDestination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblPrimaryDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrimaryDestination.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimaryDestination.ForeColor = System.Drawing.Color.Orange;
            this.lblPrimaryDestination.Location = new System.Drawing.Point(135, 37);
            this.lblPrimaryDestination.Name = "lblPrimaryDestination";
            this.lblPrimaryDestination.Size = new System.Drawing.Size(828, 23);
            this.lblPrimaryDestination.TabIndex = 7;
            this.lblPrimaryDestination.Text = "None selected (use setup)";
            this.lblPrimaryDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilesFound
            // 
            this.lblFilesFound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilesFound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblFilesFound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFilesFound.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesFound.ForeColor = System.Drawing.Color.Orange;
            this.lblFilesFound.Location = new System.Drawing.Point(135, 147);
            this.lblFilesFound.Name = "lblFilesFound";
            this.lblFilesFound.Size = new System.Drawing.Size(828, 23);
            this.lblFilesFound.TabIndex = 9;
            this.lblFilesFound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSecondaryDestination
            // 
            this.lblSecondaryDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSecondaryDestination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblSecondaryDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecondaryDestination.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondaryDestination.ForeColor = System.Drawing.Color.Orange;
            this.lblSecondaryDestination.Location = new System.Drawing.Point(135, 65);
            this.lblSecondaryDestination.Name = "lblSecondaryDestination";
            this.lblSecondaryDestination.Size = new System.Drawing.Size(828, 23);
            this.lblSecondaryDestination.TabIndex = 8;
            this.lblSecondaryDestination.Text = "None selected (use setup)";
            this.lblSecondaryDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlOutput
            // 
            this.pnlOutput.BackColor = System.Drawing.Color.Transparent;
            this.pnlOutput.Controls.Add(this.txtOutput);
            this.pnlOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOutput.Location = new System.Drawing.Point(0, 380);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(988, 228);
            this.pnlOutput.TabIndex = 19;
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.Orange;
            this.txtOutput.Location = new System.Drawing.Point(19, 5);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(10);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(944, 219);
            this.txtOutput.TabIndex = 18;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlButtons.Controls.Add(this.btnPlayers);
            this.pnlButtons.Controls.Add(this.btnQuit);
            this.pnlButtons.Controls.Add(this.btnSetup);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 608);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(988, 40);
            this.pnlButtons.TabIndex = 20;
            // 
            // btnPlayers
            // 
            this.btnPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnPlayers.FlatAppearance.BorderSize = 0;
            this.btnPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayers.ForeColor = System.Drawing.Color.Orange;
            this.btnPlayers.Location = new System.Drawing.Point(888, 6);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(75, 24);
            this.btnPlayers.TabIndex = 17;
            this.btnPlayers.Text = "Demos";
            this.btnPlayers.UseVisualStyleBackColor = false;
            this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnQuit.FlatAppearance.BorderSize = 0;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.Color.Orange;
            this.btnQuit.Location = new System.Drawing.Point(19, 6);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 24);
            this.btnQuit.TabIndex = 14;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnSetup.FlatAppearance.BorderSize = 0;
            this.btnSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetup.ForeColor = System.Drawing.Color.Orange;
            this.btnSetup.Location = new System.Drawing.Point(807, 6);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(75, 24);
            this.btnSetup.TabIndex = 16;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = false;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // pnlPlayers
            // 
            this.pnlPlayers.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlayers.Controls.Add(this.scPlayers);
            this.pnlPlayers.Controls.Add(this.pnlPlayersButtons);
            this.pnlPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayers.Location = new System.Drawing.Point(0, 0);
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.Size = new System.Drawing.Size(988, 648);
            this.pnlPlayers.TabIndex = 1;
            this.pnlPlayers.Visible = false;
            this.pnlPlayers.VisibleChanged += new System.EventHandler(this.pnlPlayers_VisibleChanged);
            // 
            // scPlayers
            // 
            this.scPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.scPlayers.Location = new System.Drawing.Point(19, 12);
            this.scPlayers.Name = "scPlayers";
            // 
            // scPlayers.Panel1
            // 
            this.scPlayers.Panel1.Controls.Add(this.label2);
            this.scPlayers.Panel1.Controls.Add(this.lbPlayers);
            this.scPlayers.Panel1MinSize = 60;
            // 
            // scPlayers.Panel2
            // 
            this.scPlayers.Panel2.Controls.Add(this.lbGames);
            this.scPlayers.Panel2.Controls.Add(this.lblSelectAGame);
            this.scPlayers.Size = new System.Drawing.Size(944, 585);
            this.scPlayers.SplitterDistance = 238;
            this.scPlayers.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select A Player";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPlayers
            // 
            this.lbPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lbPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPlayers.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayers.ForeColor = System.Drawing.Color.Orange;
            this.lbPlayers.FormattingEnabled = true;
            this.lbPlayers.Location = new System.Drawing.Point(7, 34);
            this.lbPlayers.Name = "lbPlayers";
            this.lbPlayers.Size = new System.Drawing.Size(228, 522);
            this.lbPlayers.TabIndex = 0;
            this.lbPlayers.SelectedIndexChanged += new System.EventHandler(this.lbPlayers_SelectedIndexChanged);
            // 
            // lbGames
            // 
            this.lbGames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lbGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbGames.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGames.ForeColor = System.Drawing.Color.Orange;
            this.lbGames.FormattingEnabled = true;
            this.lbGames.ItemHeight = 14;
            this.lbGames.Location = new System.Drawing.Point(3, 34);
            this.lbGames.Name = "lbGames";
            this.lbGames.Size = new System.Drawing.Size(696, 520);
            this.lbGames.TabIndex = 0;
            // 
            // lblSelectAGame
            // 
            this.lblSelectAGame.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectAGame.ForeColor = System.Drawing.Color.Gray;
            this.lblSelectAGame.Location = new System.Drawing.Point(3, 10);
            this.lblSelectAGame.Name = "lblSelectAGame";
            this.lblSelectAGame.Size = new System.Drawing.Size(220, 23);
            this.lblSelectAGame.TabIndex = 2;
            this.lblSelectAGame.Text = "Select A Game to watch";
            this.lblSelectAGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPlayersButtons
            // 
            this.pnlPlayersButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlayersButtons.Controls.Add(this.btnWatchDemo);
            this.pnlPlayersButtons.Controls.Add(this.btnBackToMain);
            this.pnlPlayersButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPlayersButtons.Location = new System.Drawing.Point(0, 608);
            this.pnlPlayersButtons.Name = "pnlPlayersButtons";
            this.pnlPlayersButtons.Size = new System.Drawing.Size(988, 40);
            this.pnlPlayersButtons.TabIndex = 4;
            // 
            // btnWatchDemo
            // 
            this.btnWatchDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWatchDemo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnWatchDemo.FlatAppearance.BorderSize = 0;
            this.btnWatchDemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWatchDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWatchDemo.ForeColor = System.Drawing.Color.Orange;
            this.btnWatchDemo.Location = new System.Drawing.Point(864, 6);
            this.btnWatchDemo.Name = "btnWatchDemo";
            this.btnWatchDemo.Size = new System.Drawing.Size(99, 23);
            this.btnWatchDemo.TabIndex = 1;
            this.btnWatchDemo.Text = "Watch Demo";
            this.btnWatchDemo.UseVisualStyleBackColor = false;
            this.btnWatchDemo.Click += new System.EventHandler(this.btnWatchDemo_Click);
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnBackToMain.FlatAppearance.BorderSize = 0;
            this.btnBackToMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToMain.ForeColor = System.Drawing.Color.Orange;
            this.btnBackToMain.Location = new System.Drawing.Point(19, 6);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(75, 23);
            this.btnBackToMain.TabIndex = 0;
            this.btnBackToMain.Text = "Back";
            this.btnBackToMain.UseVisualStyleBackColor = false;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            // 
            // lblExecutable
            // 
            this.lblExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExecutable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblExecutable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExecutable.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExecutable.ForeColor = System.Drawing.Color.Orange;
            this.lblExecutable.Location = new System.Drawing.Point(135, 120);
            this.lblExecutable.Name = "lblExecutable";
            this.lblExecutable.Size = new System.Drawing.Size(828, 23);
            this.lblExecutable.TabIndex = 21;
            this.lblExecutable.Text = "None selected (use setup)";
            this.lblExecutable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(19, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 20;
            this.label10.Text = "Executable";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(988, 648);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlPlayers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Q3DC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlDisplay.ResumeLayout(false);
            this.pnlDisplay.PerformLayout();
            this.pnlOutput.ResumeLayout(false);
            this.pnlOutput.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlPlayers.ResumeLayout(false);
            this.scPlayers.Panel1.ResumeLayout(false);
            this.scPlayers.Panel2.ResumeLayout(false);
            this.scPlayers.ResumeLayout(false);
            this.pnlPlayersButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

      private System.Windows.Forms.Panel pnlMain;
      private System.Windows.Forms.CheckBox chkDeleteDemos;
      private System.Windows.Forms.CheckBox chkProcessPlayers;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label lblFilesFound;
      private System.Windows.Forms.Label lblSecondaryDestination;
      private System.Windows.Forms.Label lblPrimaryDestination;
      private System.Windows.Forms.Label lblSourceDirectory;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Button btnSetup;
      private System.Windows.Forms.Button btnProcess;
      private System.Windows.Forms.Button btnQuit;
      private System.Windows.Forms.CheckBox chkMirrorFiles;
      private System.Windows.Forms.TextBox txtOutput;
      private System.Windows.Forms.Panel pnlDisplay;
      private System.Windows.Forms.Panel pnlButtons;
      private System.Windows.Forms.Panel pnlOutput;
      private System.Windows.Forms.Button btnPlayers;
      private System.Windows.Forms.Panel pnlPlayers;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ListBox lbPlayers;
      private System.Windows.Forms.Label lblSelectAGame;
      private System.Windows.Forms.ListBox lbGames;
      private System.Windows.Forms.SplitContainer scPlayers;
      private System.Windows.Forms.Panel pnlPlayersButtons;
      private System.Windows.Forms.Button btnBackToMain;
      private System.Windows.Forms.Button btnWatchDemo;
      private System.Windows.Forms.Label lblBaseQ3Directory;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label lblExecutable;
      private System.Windows.Forms.Label label10;


      }
}