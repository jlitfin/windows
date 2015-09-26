using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmsFilter
{
    public partial class SmsFilter : Form
    {

        private string __browsePath;
        private List<string> __sourceDocuments;
        private List<Sms> __messages;
        private string __settingsFile = "settings.txt";
        private Settings __settings;

        public SmsFilter()
        {
            InitializeComponent();


            UpdateSettings();
        }

        public List<Sms> BuildContent(string file, List<Sms> messages)
        {
            for (int i = 0; i < messages.Count; ++i)
            {
                if (i + 1 < messages.Count)
                {
                    int s = file.IndexOf(Environment.NewLine, messages[i].StartIndex) + 1;
                    int e = messages[i + 1].StartIndex - 1;
                    messages[i].Content = file.Substring(s, e - s);
                }
                else
                {
                    int s = file.IndexOf(Environment.NewLine, messages[i].StartIndex) + 1;
                    messages[i].Content = file.Substring(s, file.Length - s);
                }
            }

            return messages;
        }

        public List<Sms> BuildMessageDates(string file, List<Sms> messages)
        {
            foreach (var m in messages)
            {
                int eol = file.IndexOf(Environment.NewLine, m.StartIndex);
                if (eol > 0)
                {
                    int subPosition = m.StartIndex + m.Sender.Length;
                    int dateLength = eol - subPosition;
                    if (subPosition + dateLength < file.Length && dateLength > 0)
                    {
                        string date = file.Substring(subPosition, dateLength).Trim();
                        m.DateString = date;
                    }  
                }
            }

            return messages;
        }

        public List<Sms> BuildMessageIndexesRaw(string file, string s1, string s2)
        {
            List<Sms> ret = new List<Sms>();
            int current = 0;
            while (true)
            {
                Sms sms = new Sms();
                int n = file.IndexOf(s1, current);
                if (n < 0) break;

                sms.Sender = s1;
                sms.StartIndex = n;
                current = n + s1.Length;
                ret.Add(sms);
            }

            current = 0;
            while (true)
            {
                Sms sms = new Sms();
                int n = file.IndexOf(s2, current);
                if (n < 0) break;

                sms.Sender = s2;
                sms.StartIndex = n;
                current = n + s2.Length;
                ret.Add(sms);
            }

            return ret;
        }

        public List<Sms> BuildMessageIndexesForFile(string file, string s1, string s2)
        {
            List<Sms> ret = new List<Sms>();

            var smsList = BuildMessageIndexesRaw(file, s1, s2);
            ret = smsList.OrderBy(s => s.StartIndex).ToList();

            return ret;
        }

        public string BuildOutput(List<Sms> messages, string s1, string s2)
        {
            if (messages == null || messages.Count == 0) return string.Empty;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < messages.Count; ++i)
            {
                if (i + 1 < messages.Count)
                {
                    sb.AppendLine(string.Format("<div class=\"{0}\">", messages[i].Sender.Equals(s1) ? "s1" : "s2"));
                    sb.AppendLine("<div class=\"s-header\">");
                    sb.Append(messages[i].Alias);
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"s-date\">");
                    sb.Append(messages[i].DateString);
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"s-content\">");
                    if (messages[i].Sender.Equals(messages[i + 1].Sender) && messages[i].DateString.Equals(messages[i + 1].DateString))
                    {
                        //
                        // same sender, same time, concat message content, and skip next
                        //
                        sb.Append(messages[i].Content);
                        sb.Append(" ");
                        sb.Append(messages[i + 1].Content);
                        ++i;
                    }
                    else
                    {
                        sb.Append(messages[i].Content);
                    }
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                }
                else
                {
                    sb.AppendLine(string.Format("<div class=\"{0}\">", messages[i].Sender.Equals(s1) ? "s1" : "s2"));
                    sb.AppendLine("<div class=\"s-header\">");
                    sb.Append(messages[i].Alias);
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"s-date\">");
                    sb.Append(messages[i].DateString);
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class=\"s-content\">");
                    sb.AppendLine(messages[i].Content);
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                }
            }

            return sb.ToString();
        }

        public string RemoveTheTos(string file)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byteArray = Encoding.UTF8.GetBytes(file);
            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            MemoryStream stream = new MemoryStream(byteArray);
            using (StreamReader reader = new StreamReader(stream))
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.StartsWith("To:"))
                    {
                        sb.AppendLine(line);
                    }
                }
            }

            return sb.ToString();
        }

        public List<Sms> SetAliases(List<Sms> messages, string s1, string s2, string a1, string a2)
        {
            foreach (var m in messages)
            {
                if (m.Sender.Equals(s1))
                {
                    m.Alias = a1;
                }
                else if (m.Sender.Equals(s2))
                {
                    m.Alias = a2;
                }
            }

            return messages;
        }

        public List<Sms> BuildSmsCollection(string file, List<Sms> messages)
        {
            string s1 = this.txtSpeakerOneString.Text;
            string s2 = this.txtSpeakerTwoString.Text;

            file = RemoveTheTos(file);
            this.txtResult.Text = file;
            List<Sms> smsColl = BuildMessageIndexesForFile(file, s1, s2);
            smsColl = SetAliases(smsColl, s1, s2, this.txtSpeakerOneAlias.Text, this.txtSpeakerTwoAlias.Text);
            smsColl = BuildMessageDates(file, smsColl);
            smsColl = BuildContent(file, smsColl);

            return smsColl;
        }

        public List<FileInfo> GetFileList(string filter)
        {
            List<FileInfo> list = new List<FileInfo>();
            GetAllFilesForFilter(list, new DirectoryInfo(__browsePath), filter);

            return list;
        }

        private List<string> GetWorkingFileList(string path, string filter)
        {
            List<FileInfo> infos = GetFileList(filter);
            List<string> retColl = new List<string>();

            if (infos != null && infos.Count > 0)
            {
                foreach (FileInfo info in infos)
                {
                    retColl.Add(info.FullName);
                }
            }

            return retColl;
        }

        private void GetAllFilesForFilter(List<FileInfo> appendTo, DirectoryInfo srcDir, string filter)
        {
            if (appendTo != null)
            {
                DirectoryInfo[] subDirs = srcDir.GetDirectories();
                if (subDirs != null && subDirs.Length > 0)
                {
                    for (int i = 0; i < subDirs.Length; ++i)
                    {
                        GetAllFilesForFilter(appendTo, subDirs[i], filter);
                    }
                }

                //to leaf nodes
                FileInfo[] leafNodes = srcDir.GetFiles(filter);
                if (leafNodes != null && leafNodes.Length > 0)
                {
                    for (int i = 0; i < leafNodes.Length; ++i)
                    {
                        appendTo.Add(leafNodes[i]);
                    }
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

        private string ReadFileContents(string filePath)
        {
            string file = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    file = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                PrintF("The file could not be read:", true);
                PrintF(e.Message, true);
            }


            return file;
        }

        private Settings GetSettings()
        {
            __settings = new Settings();
            using (var sFile = new StreamReader(__settingsFile))
            {
                __settings.BrowsePath = sFile.ReadLine();
                __settings.SpeakerOne = sFile.ReadLine();
                __settings.SpeakerOneAlias = sFile.ReadLine();
                __settings.SpeakerTwo = sFile.ReadLine();
                __settings.SpeakerTwoAlias = sFile.ReadLine();
            }

            return __settings;
        }

        private void SaveSettings(Settings s)
        {
            using (var sFile = new StreamWriter(__settingsFile))
            {
                sFile.WriteLine(s.BrowsePath);
                sFile.WriteLine(s.SpeakerOne);
                sFile.WriteLine(s.SpeakerOneAlias);
                sFile.WriteLine(s.SpeakerTwo);
                sFile.WriteLine(s.SpeakerTwoAlias);
            }
        }

        private void UpdateSettings()
        {
            FileInfo settingsFile = new FileInfo(__settingsFile);
            if (settingsFile.Exists)
            {
                var s = GetSettings();
                this.__browsePath = s.BrowsePath;
                this.lblSourceFolder.Text = this.__browsePath;
                this.txtSpeakerOneString.Text = s.SpeakerOne;
                this.txtSpeakerOneAlias.Text = s.SpeakerOneAlias;
                this.txtSpeakerTwoString.Text = s.SpeakerTwo;
                this.txtSpeakerTwoAlias.Text = s.SpeakerTwoAlias;
            }
        }

        private void Translate()
        {
            Settings s = new Settings();
            s.BrowsePath = __browsePath;
            s.SpeakerOne = this.txtSpeakerOneString.Text;
            s.SpeakerTwo = this.txtSpeakerTwoString.Text;
            s.SpeakerOneAlias = this.txtSpeakerOneAlias.Text;
            s.SpeakerTwoAlias = this.txtSpeakerTwoAlias.Text;
            SaveSettings(s);

            List<string> fileList = GetWorkingFileList(__browsePath, "*.txt");
            if (fileList != null && fileList.Count > 0)
            {
                PrintF("Inspecting files...");
                PrintF(fileList.Count.ToString() + " files found.");
                __sourceDocuments = fileList;
            }

            if (__sourceDocuments != null && __sourceDocuments.Count > 0)
            {
                __messages = new List<Sms>();
                foreach (var d in __sourceDocuments)
                {
                    string file = ReadFileContents(d);
                    __messages.AddRange(BuildSmsCollection(file, __messages));
                }
            }
            else
            {
                PrintF("No documents to translate.", true);
            }

            this.txtResult.Text = BuildOutput(__messages, s.SpeakerOne, s.SpeakerTwo);
            PrintF("Output complete.", true);
        }


        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            dlgBrowseForFolder.ShowNewFolderButton = false;
            DialogResult result = dlgBrowseForFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                __browsePath = dlgBrowseForFolder.SelectedPath;
                this.lblSourceFolder.Text = __browsePath;
            }
        }

        private void txtSpeakerOneString_TextChanged(object sender, EventArgs e)
        {
            if (txtSpeakerOneString.Text.Length > 0 && txtSpeakerTwoString.Text.Length > 0)
            {
                this.btnTranslate.Enabled = true;
            }
        }

        private void txtSpeakerTwoString_TextChanged(object sender, EventArgs e)
        {
            if (txtSpeakerOneString.Text.Length > 0 && txtSpeakerTwoString.Text.Length > 0)
            {
                this.btnTranslate.Enabled = true;
            }
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            Translate();
        }
    }
}
