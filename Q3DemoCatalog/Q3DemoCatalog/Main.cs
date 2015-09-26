using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Q3DemoCatalog
{
    public partial class MainForm : Form
    {
        #region Private Members

        DirectoryInfo __sourceDir;
        private FileInfo[] __fileInfos;
        private string __destinationPath = string.Empty;
        private string __mirrorPath = string.Empty;
        private string __sourcePath = string.Empty;
        private string __baseq3Path = string.Empty;
        private string __executable = string.Empty;
        private string __customConfig = string.Empty;
        private Dictionary<string, List<DemoRecord>> __players;

        private const string EMPTY_FIELD = "None selected (use setup)";
        private const int COL_WIDTH_1 = 30;
        private const int COL_WIDTH_2 = 30;
        private const int COL_WIDTH_3 = 10;
        private const int COL_WIDTH_4 = 30;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void BuildPlayerList(string srcPath)
        {
            //create a hashtable for player/game maps for all games
            //in source directory
            if (__players != null)
            {
                try
                {
                    DirectoryInfo srcDir = new DirectoryInfo(srcPath);
                    if (srcDir.Exists)
                    {
                        //check for files to search for players
                        FileInfo[] files = srcDir.GetFiles();
                        for (int i = 0; i < files.Length; ++i)
                        {
                            string fileName = files[i].Name;
                            if (fileName.Contains("-vs-"))
                            {
                                //-----   duel format  ------
                                int vsIndex = fileName.IndexOf("-vs-");
                                string p1 = fileName.Substring(0, vsIndex);
                                string p2 = fileName.Substring(vsIndex + 4);
                                p2 = p2.Substring(0, p2.IndexOf("-"));

                                p1 = CleanPlayerName(p1);
                                p2 = CleanPlayerName(p2);

                                //add if new
                                if (!__players.ContainsKey(p1))
                                {
                                    __players.Add(p1, new List<DemoRecord>());
                                }
                                if (!__players.ContainsKey(p2))
                                {
                                    __players.Add(p2, new List<DemoRecord>());
                                }

                                //add this game to this players list
                                //create demo record
                                DemoRecord dr = new DemoRecord();
                                dr.FullName = files[i].FullName.Substring(__destinationPath.Length);
                                dr.GameDateTime = files[i].LastWriteTime;
                                dr.Player1 = p1;
                                dr.Player2 = p2;
                                //dr.DisplayName = GetDuelDisplayName(files[i].LastWriteTime, dr.FullName, 1);

                                __players[p1].Add(dr);

                                dr = new DemoRecord();
                                dr.FullName = files[i].FullName.Substring(__destinationPath.Length);
                                dr.GameDateTime = files[i].LastWriteTime;
                                dr.Player1 = p2;
                                dr.Player2 = p1;
                                //dr.DisplayName = GetDuelDisplayName(files[i].LastWriteTime, dr.FullName, 2);

                                __players[p2].Add(dr);

                            }
                        }

                        //get subdirectories
                        DirectoryInfo[] subDirs = srcDir.GetDirectories();
                        for (int i = 0; i < subDirs.Length; ++i)
                        {
                            string subPath = subDirs[i].FullName.Substring(srcPath.Length);
                            BuildPlayerList(srcPath + subPath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    System.Console.WriteLine(msg);
                }
            }
        }

        private string CleanPlayerName(string name)
        {
            string retStr = name;
            if (retStr.Contains("(POV)"))
            {
                retStr = retStr.Replace("(POV)", "");
            }

            if (retStr.Contains("(MVD)"))
            {
                retStr = retStr.Replace("(MVD)", "");
            }

            if (retStr.Contains("-MVD-"))
            {
                retStr = retStr.Replace("-MVD-", "");
            }

            return retStr;
        }

        private string CreateDirectoryForFileDate(DateTime fileDate)
        {
            string month = fileDate.Month < 10 ? "0" + fileDate.Month.ToString() : fileDate.Month.ToString();
            string day = fileDate.Day < 10 ? "0" + fileDate.Day.ToString() : fileDate.Day.ToString();

            StringBuilder sb = new StringBuilder()
            .Append(__destinationPath)
            .Append(@"\")
            .Append(fileDate.Year.ToString())
            .Append(@"\")
            .Append(month)
            .Append(@"\")
            .Append(day);
            DirectoryInfo dirInfo = new DirectoryInfo(sb.ToString());

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                PrintF("[Creating Directory]: " + dirInfo.FullName, true);
            }

            return sb.ToString();
        }

        private string GetDuelDisplayName(DateTime fileTime, string fullName, int player)
        {
            //first remove the date crap from the front of the path
            string dName = fullName.Substring(12);

            //now clean the players
            //-----   duel format  ------
            //PLAYER 1
            int vsIndex = dName.IndexOf("-vs-");
            string p1 = dName.Substring(0, vsIndex);
            p1 = CleanPlayerName(p1);

            //MAP
            //get the starting index of the time which immediately follows
            //the map
            string mnth = fileTime.Month < 10 ? "0" + fileTime.Month.ToString() : fileTime.Month.ToString();
            string day = fileTime.Day < 10 ? "0" + fileTime.Day.ToString() : fileTime.Day.ToString();
            string timeString = fileTime.Year.ToString() + "_" + mnth + "_" + day;
            int eMapIndex = dName.IndexOf(timeString) - 1;
            int sMapIndex = eMapIndex;
            for (int i = eMapIndex; i > 0; --i)
            {
                //search backwards for hyphen which signals start of map name
                //and end of player 2 name
                if (dName[i] == '-')
                {
                    sMapIndex = i + 1;
                    break;
                }
            }
            string map = dName.Substring(sMapIndex, eMapIndex - sMapIndex);

            //PLAYER 2 -- should start after -vs- and end before map (may include MVD chars which we clean)
            string p2 = dName.Substring(vsIndex + 4, sMapIndex - vsIndex + 4 - 1);
            p2 = CleanPlayerName(p2);

            StringBuilder sb = new StringBuilder();
            if (player == 1)
            {
                sb.Append(p1);
                for (int i = 0; i < COL_WIDTH_1 - p1.Length; ++i)
                {
                    sb.Append(" ");
                }

                sb.Append(p2);
                for (int i = 0; i < COL_WIDTH_2 - p2.Length; ++i)
                {
                    sb.Append(" ");
                }


                sb.Append(map);
                for (int i = 0; i < COL_WIDTH_3 - map.Length; ++i)
                {
                    sb.Append(" ");
                }

                //gametime
                string dtTime = fileTime.ToShortDateString() + " " + fileTime.ToShortTimeString();
                sb.Append(dtTime);

                return sb.ToString();
            }
            else if (player == 2)
            {
                sb.Append(p2);
                for (int i = 0; i < COL_WIDTH_1 - p2.Length; ++i)
                {
                    sb.Append(" ");
                }

                sb.Append(p1);
                for (int i = 0; i < COL_WIDTH_2 - p1.Length; ++i)
                {
                    sb.Append(" ");
                }

                sb.Append(map);
                for (int i = 0; i < COL_WIDTH_3 - map.Length; ++i)
                {
                    sb.Append(" ");
                }

                //gametime
                string dtTime = fileTime.ToShortDateString() + " " + fileTime.ToShortTimeString();
                sb.Append(dtTime);

                return sb.ToString();
            }
            else
            {
                return fullName;
            }
        }

        private void MirrorFiles(string srcPath, string destPath)
        {
            try
            {
                DirectoryInfo srcDir = new DirectoryInfo(srcPath);
                if (srcDir.Exists)
                {
                    //dirs to mirror
                    DirectoryInfo[] subDirs = srcDir.GetDirectories();

                    //verify that the destPath is not one of the subdirs
                    for (int i = 0; i < subDirs.Length; ++i)
                    {
                        if (subDirs[i].FullName.Equals(destPath))
                        {
                            PrintF("[ERROR]: Mirror directory can not be a subdirectory of source directory, Mirror Aborted", true);
                            return;
                        }
                    }

                    for (int i = 0; i < subDirs.Length; ++i)
                    {
                        string mPath = subDirs[i].FullName.Substring(srcPath.Length);

                        //create dir in mirror if not exists
                        DirectoryInfo mDir = new DirectoryInfo(destPath + mPath);
                        if (!mDir.Exists)
                        {
                            mDir.Create();
                        }
                        this.MirrorFiles(subDirs[i].FullName, destPath + mPath);
                    }

                    //check for files to copy
                    FileInfo[] files = srcDir.GetFiles();
                    for (int i = 0; i < files.Length; ++i)
                    {
                        string mPath = files[i].FullName.Substring(srcPath.Length);
                        FileInfo fileChk = new FileInfo(destPath + mPath);
                        if (!fileChk.Exists)
                        {
                            files[i].CopyTo(destPath + mPath, false);
                            PrintF("|", false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                System.Console.WriteLine(msg);
            }
        }

        private void OpenPlayerList()
        {
            FileInfo info = new FileInfo("q3dcinfo.splat");
            ArrayList playerList = new ArrayList();
            if (info.Exists)
            {
                FileInfo playerFile = new FileInfo("q3dcPlayers.splat");
                if (playerFile.Exists)
                {
                    using (StreamReader sr = new StreamReader("q3dcPlayers.splat"))
                    {
                        string line = sr.ReadLine();
                        while (line != null && line.Length >= 0)
                        {
                            playerList.Add(line);
                            line = sr.ReadLine();
                        }
                    }
                }
            }

            //now parse out player/game list
            __players = new Dictionary<string, List<DemoRecord>>();
            foreach (string pg in playerList)
            {
                string player = pg.Substring(0, pg.IndexOf(";"));
                string game = pg.Substring(pg.IndexOf(";") + 1);

                if (!__players.ContainsKey(player))
                {
                    __players.Add(player, new List<DemoRecord>());
                }

                DemoRecord dr = new DemoRecord();
                dr.FullName = game;
                __players[player].Add(dr);
            }
        }

        private void ProcessNewFiles()
        {
            if (__fileInfos != null && __fileInfos.Length > 0)
            {
                this.lblFilesFound.Text = __fileInfos.Length.ToString();
                this.lblFilesFound.Refresh();
                PrintF("[INFO]: " + __fileInfos.Length.ToString() + " files found.", true);

                //directories needed for the current file list
                if (ValidatePath(__destinationPath, true))
                {
                    for (int i = 0; i < __fileInfos.Length; ++i)
                    {
                        PrintF("[INFO]: file " + i.ToString() + ": " + __fileInfos[i].Name, true);
                        string path = CreateDirectoryForFileDate(__fileInfos[i].LastWriteTime);
                        __fileInfos[i].CopyTo(path + @"\" + __fileInfos[i].Name, true);

                        if (this.chkDeleteDemos.Checked)
                        {
                            __fileInfos[i].Delete();
                        }
                    }
                }
                else
                {
                    //notify no write permissions
                }

                if (this.chkMirrorFiles.Checked)
                {
                    PrintF("[Copying Files to mirror site]", true);
                    if (ValidatePath(__mirrorPath, true) && ValidatePath(__destinationPath, false))
                    {
                        MirrorFiles(__destinationPath, __mirrorPath);
                        PrintF(" ", true);
                        PrintF("[Finished]", true);
                    }
                    else
                    {
                        PrintF("[ERROR]: Mirror site currently unavailable (or no write permission).", true);
                    }
                }
                else
                {
                    PrintF("[Finished]", true);
                }

                //reset infos for new conditions
                if (ValidatePath(__sourcePath, false))
                {
                    __sourceDir = new DirectoryInfo(__sourcePath);
                    __fileInfos = __sourceDir.GetFiles();
                    this.lblFilesFound.Text = __fileInfos.Length.ToString();
                }
            }
        }

        private int PrintF(string toPrint)
        {
            this.txtOutput.AppendText(toPrint);
            this.txtOutput.AppendText("\r\n");
            return toPrint.Length;
        }

        private int PrintF(string toPrint, bool newLine)
        {
            if (newLine)
            {
                return PrintF(toPrint);
            }
            else
            {
                this.txtOutput.AppendText(toPrint);
                return toPrint.Length;
            }
        }

        private void SetControlDefaults()
        {
            if (__mirrorPath != null && __mirrorPath.Length > 0)
            {
                if (ValidatePath(__mirrorPath, true))
                {
                    this.chkMirrorFiles.Enabled = true;
                }
                else
                {
                    this.chkMirrorFiles.Checked = false;
                    this.chkMirrorFiles.Enabled = false;
                }
            }
            else
            {
                this.chkMirrorFiles.Checked = false;
                this.chkMirrorFiles.Enabled = false;
            }

            if (__baseq3Path != null && __baseq3Path.Length > 0)
            {
                if (ValidatePath(__baseq3Path, true))
                {
                    this.btnWatchDemo.Enabled = true;
                }
                else
                {
                    this.btnWatchDemo.Enabled = false;
                }
            }

        }

        private bool ValidatePath(string path, bool writeAccess)
        {
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(path);
                if (dInfo.Exists)
                {
                    if (!writeAccess)
                    {
                        return true;
                    }

                    FileInfo fInfo;
                    try
                    {
                        fInfo = new FileInfo(path + @"\" + "q3dcAT.splat");
                        using (StreamWriter sw = new StreamWriter(path + @"\" + "q3dcAT.splat"))
                        {
                            sw.WriteLine("write test.");
                            sw.Flush();
                        }
                    }
                    catch
                    {
                        return false;
                    }

                    fInfo.Delete();
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        #endregion

        #region Events

        private void Main_Load(object sender, EventArgs e)
        {
            #region Settings

            //get settings
            ArrayList settings = new ArrayList();

            FileInfo info = new FileInfo("q3dcinfo.splat");
            if (info.Exists)
            {
                using (StreamReader sr = new StreamReader("q3dcinfo.splat"))
                {
                    string line = sr.ReadLine();
                    while (line != null && line.Length >= 0)
                    {
                        settings.Add(line);
                        line = sr.ReadLine();
                    }
                }

                if (settings.Count > 0)
                {
                    __sourcePath = (string)settings[0];
                }

                if (settings.Count > 1)
                {
                    __destinationPath = (string)settings[1];
                }

                if (settings.Count > 2)
                {
                    __mirrorPath = (string)settings[2];
                }

                if (settings.Count > 3)
                {
                    if (((string)settings[3]).Contains("TRUE"))
                    {
                        this.chkMirrorFiles.Checked = true;
                    }
                    else
                    {
                        this.chkMirrorFiles.Checked = false;
                    }
                }

                if (settings.Count > 4)
                {
                    if (((string)settings[4]).Contains("TRUE"))
                    {
                        this.chkDeleteDemos.Checked = true;
                    }
                    else
                    {
                        this.chkDeleteDemos.Checked = false;
                    }
                }
                if (settings.Count > 5)
                {
                    if (((string)settings[5]).Contains("TRUE"))
                    {
                        this.chkProcessPlayers.Checked = true;
                    }
                    else
                    {
                        this.chkProcessPlayers.Checked = false;
                    }
                }

                if (settings.Count > 6)
                {
                    __baseq3Path = (string)settings[6];
                }


                if (settings.Count > 7)
                {
                    __executable = (string)settings[7];
                }

                if (settings.Count > 8)
                {
                    __customConfig = (string)settings[8];
                }


                if (__sourcePath.Length != 0)
                {
                    this.lblSourceDirectory.Text = __sourcePath;
                }
                else
                {
                    this.lblSourceDirectory.Text = EMPTY_FIELD;
                }

                if (__destinationPath.Length != 0)
                {
                    this.lblPrimaryDestination.Text = __destinationPath;
                }
                else
                {
                    this.lblPrimaryDestination.Text = EMPTY_FIELD;
                }

                if (__mirrorPath.Length != 0)
                {
                    this.lblSecondaryDestination.Text = __mirrorPath;
                }
                else
                {
                    this.lblSecondaryDestination.Text = EMPTY_FIELD;
                }

                if (__baseq3Path.Length != 0)
                {
                    this.lblBaseQ3Directory.Text = __baseq3Path;
                }
                else
                {
                    this.lblBaseQ3Directory.Text = EMPTY_FIELD;
                }

                if (__executable.Length == 0)
                {
                    __executable = "quake3.exe";
                 
                }
                this.lblExecutable.Text = __executable;


                if (ValidatePath(__sourcePath, false))
                {
                    __sourceDir = new DirectoryInfo(__sourcePath);
                    __fileInfos = __sourceDir.GetFiles();
                    this.lblFilesFound.Text = __fileInfos.Length.ToString();
                }
                else
                {
                    //first time, or setup corrupt
                }
            }

            #endregion

            #region Player Load

            this.OpenPlayerList();

            #endregion

            #region Run Demo Cmd

            info = new FileInfo("rundemo.cmd");
            if (!info.Exists)
            {
                if (__baseq3Path != null && __baseq3Path.Length > 0)
                {
                    using (StreamWriter sw = new StreamWriter("rundemo.cmd"))
                    {
                        sw.WriteLine("@echo off");
                        sw.WriteLine("cd " + __baseq3Path.Substring(0, __baseq3Path.Length - "\baseq3".Length));
                        sw.WriteLine("start quake3.exe +set fs_game cpma +exec q3dc_demo.cfg");
                        sw.WriteLine("exit");
                    }
                }
            }

            #endregion

            this.SetControlDefaults();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            this.ProcessNewFiles();

            if (this.chkProcessPlayers.Checked)
            {
                __players = new Dictionary<string, List<DemoRecord>>();

                PrintF("[Processing Players]", true);
                this.BuildPlayerList(__destinationPath);
                PrintF("[Writing player file]");
                using (StreamWriter sw = new StreamWriter("q3dcPlayers.splat"))
                {
                    foreach (string player in __players.Keys)
                    {
                        if (__players.ContainsKey(player))
                        {
                            foreach (DemoRecord dr in __players[player])
                            {
                                sw.WriteLine(player + ";" + dr.FullName);
                            }
                        }
                    }
                }
                PrintF("[Finished]");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            Setup setup = new Setup();
            setup.StartPosition = FormStartPosition.Manual;
            setup.Location = new Point(this.Location.X + 55, this.Location.Y + 54);
            setup.SourcePath = __sourcePath;
            setup.PrimaryPath = __destinationPath;
            setup.SecondaryPath = __mirrorPath;
            setup.Baseq3Path = __baseq3Path;
            setup.Executable = __executable;
            setup.CustomConfig = __customConfig;
            setup.ShowDialog();

            if (setup != null)
            {
                if (setup.SourcePath != string.Empty)
                {
                    //set source path  
                    if (ValidatePath(setup.SourcePath, false))
                    {
                        __sourcePath = setup.SourcePath;
                        __sourceDir = new DirectoryInfo(__sourcePath);
                        __fileInfos = __sourceDir.GetFiles();
                        this.lblSourceDirectory.Text = setup.SourcePath;
                        this.lblFilesFound.Text = __fileInfos.Length.ToString();
                    }
                    else
                    {
                        //first time, or setup corrupt
                    }
                }

                if (setup.PrimaryPath != string.Empty)
                {
                    if (ValidatePath(setup.PrimaryPath, true))
                    {
                        __destinationPath = setup.PrimaryPath;
                        this.lblPrimaryDestination.Text = setup.PrimaryPath;
                    }
                    else
                    {
                        //notify no write permissions
                        this.lblPrimaryDestination.Text = EMPTY_FIELD;
                        __destinationPath = string.Empty;
                    }
                }

                if (setup.SecondaryPath != string.Empty)
                {
                    if (ValidatePath(setup.SecondaryPath, true))
                    {
                        __mirrorPath = setup.SecondaryPath;
                        this.lblSecondaryDestination.Text = setup.SecondaryPath;
                    }
                    else
                    {
                        //notify no write permissions
                        this.lblSecondaryDestination.Text = EMPTY_FIELD;
                        __mirrorPath = string.Empty;

                    }
                }


                if (setup.Baseq3Path != string.Empty)
                {
                    __baseq3Path = setup.Baseq3Path;
                    this.lblBaseQ3Directory.Text = __baseq3Path;

                    if (__baseq3Path != null && __baseq3Path.Length > 0)
                    {
                        using (StreamWriter sw = new StreamWriter("rundemo.cmd"))
                        {
                            sw.WriteLine("@echo off");
                            sw.WriteLine("cd " + __baseq3Path.Substring(0, __baseq3Path.Length - "\baseq3".Length));
                            sw.WriteLine(string.Format("start {0} {1} +exec q3dc_demo.cfg", setup.Executable, setup.CustomConfig));
                            sw.WriteLine("exit");
                        }
                    }
                }
                else
                {
                    __baseq3Path = string.Empty;
                }

                __executable = setup.Executable;
                this.lblExecutable.Text = __executable;

                __customConfig = setup.CustomConfig;
                
            }

            setup.Close();

            this.SetControlDefaults();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("q3dcinfo.splat"))
            {
                sw.WriteLine(__sourcePath);
                sw.WriteLine(__destinationPath);
                sw.WriteLine(__mirrorPath);
                sw.WriteLine(this.chkMirrorFiles.Checked ? "MIRROR=TRUE" : "MIRROR=FALSE");
                sw.WriteLine(this.chkDeleteDemos.Checked ? "DELETE=TRUE" : "DELETE=FALSE");
                sw.WriteLine(this.chkProcessPlayers.Checked ? "PLAYERS=TRUE" : "PLAYERS=FALSE");
                sw.WriteLine(__baseq3Path);
                sw.WriteLine(__executable);
                sw.WriteLine(__customConfig);
            }
        }

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            this.pnlMain.Visible = false;
            this.pnlPlayers.Visible = true;

        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.pnlPlayers.Visible = false;
            this.pnlMain.Visible = true;
        }

        private void pnlPlayers_VisibleChanged(object sender, EventArgs e)
        {
            if (this.pnlPlayers.Visible)
            {
                //reload controls from player list
                if (this.__players != null && this.__players.Count > 0)
                {
                    ArrayList players = new ArrayList();
                    foreach (string key in __players.Keys)
                    {
                        players.Add(key);
                    }

                    players.Sort();
                    this.lbPlayers.DataSource = players;
                }
            }
        }

        private void lbPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = (string)lbPlayers.SelectedValue;
            List<DemoRecord> games = __players[key];

            lbGames.DisplayMember = "FullName";
            lbGames.ValueMember = "FullName";

            lbGames.Items.Clear();
            foreach (DemoRecord rec in games)
            {
                lbGames.Items.Add(rec);
            }
        }

        private void btnWatchDemo_Click(object sender, EventArgs e)
        {
            DemoRecord demo = lbGames.SelectedItem as DemoRecord;
            if (demo != null && demo.FullName.Length > 0)
            {
                //write the needed config file and launch the game
                if (ValidatePath(__baseq3Path, true))
                {
                    using (StreamWriter sw = new StreamWriter(__baseq3Path + @"\q3dc_demo.cfg"))
                    {
                        sw.WriteLine("demo " + demo.FullName);
                    }

                    Process.Start("rundemo.cmd");
                }
            }
        }

        #endregion

        #region DemoRecord

        private class DemoRecord
        {
            public DemoRecord()
            {
            }

            private string __player1;
            private string __player2;
            private DateTime __gameDateTime;
            private string __fullName;
            private string __displayName;

            public string Player1
            {
                get
                {
                    return this.__player1;
                }
                set
                {
                    this.__player1 = value;
                }
            }

            public string Player2
            {
                get
                {
                    return this.__player2;
                }
                set
                {
                    this.__player2 = value;
                }
            }

            public DateTime GameDateTime
            {
                get
                {
                    return this.__gameDateTime;
                }
                set
                {
                    this.__gameDateTime = value;
                }
            }

            public string FullName
            {
                get
                {
                    return this.__fullName;
                }
                set
                {
                    this.__fullName = value;
                }
            }

            public string DisplayName
            {
                get
                {
                    return this.__displayName;
                }
                set
                {
                    this.__displayName = value;
                }
            }
        }

        private class DemoRecordComparer : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                DemoRecord recX = x as DemoRecord;
                DemoRecord recY = y as DemoRecord;
                if (recX != null && recY != null)
                {
                    if (recX.GameDateTime < recY.GameDateTime)
                    {
                        return -1;
                    }
                    else if (recX.GameDateTime > recY.GameDateTime)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

                return 0;
            }
        }

        #endregion


    }
}