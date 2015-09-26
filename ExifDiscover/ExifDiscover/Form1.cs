using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using CustomControls;
using ObjectModel;

namespace ExifDiscover
{
    public partial class Form1 : Form
    {
        Dictionary<string, JPL_BaseForm> __forms = new Dictionary<string, JPL_BaseForm>();
        List<FileInfo> __imagesAvailable = null;

        public Form1()
        {
            InitializeComponent();
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

        private void btnGet_Click(object sender, EventArgs e)
        {
            //Image img = Image.FromFile(@"testImages\3.jpg");
            string file = @"testImages\3.jpg";
            ExifReader reader = new ExifReader(file);

            DateTime taken = reader.DateTimeTaken;
            DateTime digi = reader.DateTimeDigitized;
            DateTime orig = reader.DateTimeOriginal;
            UInt16 ms = reader.SubSecTimeTaken;
            UInt16 width = reader.ImageWidth;
            UInt16 height = reader.ImageHeight;

            StringBuilder sb = new StringBuilder();
            sb.Append("Taken: ");
            sb.Append(taken.ToString());
            sb.Append(" : ");
            sb.Append(taken.ToLongTimeString());
            sb.AppendLine();

            sb.Append("Digi: ");
            sb.Append(digi.ToLongDateString());
            sb.Append(" : ");
            sb.Append(digi.ToLongTimeString());
            sb.AppendLine();

            sb.Append("Orig: ");
            sb.Append(orig.ToLongDateString());
            sb.Append(" : ");
            sb.Append(orig.ToLongTimeString());
            sb.AppendLine();

            sb.Append("ms: ");
            sb.Append(ms.ToString());
            sb.AppendLine();

            sb.Append("Width: ");
            sb.Append(width);
            sb.AppendLine();

            sb.Append("Height: ");
            sb.Append(height);
            sb.AppendLine();

            PrintF(sb.ToString(), true);

            PrintF("=========================================", true);
            PrintF(reader.GetExifDataString(), true);

            PrintF("=========================================", true);

            string srcPath = @"testImages";
            FileManager fm = new FileManager();
            fm.SourcePath = srcPath;
            __imagesAvailable = fm.GetFileList("*.jpg");


        }


        private void btnInputView_Click(object sender, EventArgs e)
        {
            JPL_BaseForm frm = null;
            if (__forms.ContainsKey(Constants.Views.InputView))
            {
                frm = __forms[Constants.Views.InputView];
            }
            else
            {
                Photo testPhoto = new Photo(@"testImages\3.jpg");
                testPhoto.OpenPhoto();

                frm = new PhotoViews.InputView(testPhoto);
                frm.Size = new Size(800, 400);
                frm.Tag = Constants.Views.InputView;
                frm.WindowState = FormWindowState.Maximized;

                __forms.Add(Constants.Views.InputView, frm);

            }
            frm.Show();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Photo testPhoto = new Photo(@"testImages\3.jpg");
            testPhoto.OpenPhoto();
            PrintF(testPhoto.DisplayName, true);
            PrintF(testPhoto.PhotoId, true);


        }

        private void btnImageTest_Click(object sender, EventArgs e)
        {
            DialogResult result = this.dlgBrowseFolders.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = dlgBrowseFolders.SelectedPath;
                Console.WriteLine(path);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
                   
    }
}