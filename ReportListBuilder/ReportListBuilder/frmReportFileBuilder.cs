using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ReportFileBuilder
{
    public partial class frmReportFileBuilder : Form
    {
        private const string _settingsFileName = "settings.txt";
        private string _initPath = string.Empty;

        private DateTime _processDateTime = DateTime.Now;
        private string _destinationFileName = string.Empty;
        private int _fileIncrement = 0;

        public frmReportFileBuilder()
        {
            InitializeComponent();
        }

        private void frmReportFileBuilder_Load(object sender, EventArgs e)
        {
            if (File.Exists(_settingsFileName))
            { 
                using (var sr = new StreamReader(_settingsFileName))
                {
                    _initPath = sr.ReadLine();
                    if (!Directory.Exists(_initPath))
                    {
                        _initPath = string.Empty;
                    }
                }
            }
            Greet();
        }

        private void btnSourceFileSelect_Click(object sender, EventArgs e)
        {
            dlgBrowseFolders.SelectedPath = string.IsNullOrEmpty(_initPath) ? null : _initPath;
            dlgBrowseFolders.ShowDialog();
            txtReportFileSourcePath.Text = dlgBrowseFolders.SelectedPath;

            OnPathChanges();

            using (var sw = new StreamWriter(_settingsFileName))
            {
                try
                {
                    sw.WriteLine(txtReportFileSourcePath.Text);
                }
                catch
                {
                    // oh well, couldn't write the settings file where they ran it
                }
            }
        }

        private void btnSelectSaveLocation_Click(object sender, EventArgs e)
        {
            dlgBrowseFolders.ShowDialog();
            txtSavePath.Text = dlgBrowseFolders.SelectedPath;

            OnPathChanges();
        }

        private void OnPathChanges()
        {
            if (ValidatePaths())
            {
                btnProcess.Enabled = true;
                btnPreview.Enabled = true;
            }
            else
            {
                btnProcess.Enabled = false;
                btnPreview.Enabled = false;
            }

            Greet();
        }

        private bool ValidatePaths()
        {
            return ValidateSaveLocation() && ValidateSourceLocation();
        }

        private bool ValidateSaveLocation()
        {
            return Directory.Exists(txtSavePath.Text);
        }

        private bool ValidateSourceLocation()
        {
            return Directory.Exists(txtReportFileSourcePath.Text);
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            OnPathChanges();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            var di = new DirectoryInfo(txtReportFileSourcePath.Text);
            var files = di.GetFiles("*.pdf");
            var destinationPath = GetDestinationPath();

            txtOutput.Clear();

            txtOutput.AppendText($@"Preview Result:

    {files.Length} pdf files found at {txtReportFileSourcePath.Text}.

    Each report file found will be added to {destinationPath}

    If this is satisfactory, click Process.  Otherwise select a different source / destination directory.");

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var di = new DirectoryInfo(txtReportFileSourcePath.Text);
            var files = di.GetFiles("*.pdf");
            var destinationPath = GetDestinationPath();

            txtOutput.Clear();
            txtOutput.AppendText("Processing Files.");

            using (var sw = new StreamWriter(destinationPath))
            {
                sw.WriteLine("FileName, PreviousSystemKey");
                foreach (var f in files)
                {
                    sw.WriteLine(f.Name);
                }
            }

            txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("Starting excel.");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "Excel",
                    Arguments = _destinationFileName,
                    WorkingDirectory = txtSavePath.Text
                });

                txtOutput.AppendText(Environment.NewLine);
                txtOutput.AppendText("Please add additional mapping information and save file in xlxs format.");
                txtOutput.AppendText(Environment.NewLine);
                txtOutput.AppendText("Process complete.");
            }
            catch 
            {
                txtOutput.AppendText(Environment.NewLine);
                txtOutput.AppendText($"Unable to start excel but file can be found at {GetDestinationPath()}.");
            }
            
        }

        private void Greet()
        {
            txtOutput.Clear();
            var greeting = @"This tool will allow you create a .csv file containing a listing of all the .pdf files in the directory you select. 

    Step 1:  Select the folder containing the reports
    Step 2:  Select the folder in which you would like the list file placed
    Step 3:  Click the Process button to create the file. (The button will be enabled when the paths are valid)";

            txtOutput.AppendText(greeting);
        }

        private string GetDestinationPath()
        {
            _fileIncrement = 0;
            var destinationPath = string.Empty;
            do
            {
                _destinationFileName = GetDestinationFileName(++_fileIncrement);
                destinationPath = Path.Combine(txtSavePath.Text, _destinationFileName);

            } while (File.Exists(destinationPath));

            return destinationPath;
        }

        private string GetDestinationFileName(int fileIncrement)
        {
            return $"{_processDateTime.ToString("yyyyMMdd")}_Report_List_{fileIncrement}.csv";
        }
    }


}
