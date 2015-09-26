using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ObjectModel;

namespace ExifDiscover.PhotoViews
{
    public partial class InputView : CustomControls.JPL_BaseForm
    {
        private Photo __inPhoto;


        public InputView(Photo inputPhoto)
        {
            InitializeComponent();

            __inPhoto = inputPhoto;
        }

        #region Events

        private void InputView_Load(object sender, EventArgs e)
        {
            this.icMain.Image = __inPhoto.DisplayBitmap;

            bindExifGrid.DataSource = null;
            bindExifGrid.Clear();
            bindExifGrid.DataSource = __inPhoto.ExifFields;

            bindPhotoGrid.DataSource = null;
            bindPhotoGrid.Clear();
            bindPhotoGrid.DataSource = __inPhoto.Properties;

            this.dgvExifData.Columns[0].Width = 150;
            this.dgvExifData.Columns[1].Width = this.dgvExifData.ClientRectangle.Width - this.dgvExifData.Columns[0].Width;

            this.dgvPhotoData.Columns[0].Width = 150;
            this.dgvPhotoData.Columns[1].Width = this.dgvExifData.ClientRectangle.Width - this.dgvPhotoData.Columns[0].Width;
         }

        private void dgvExifData_Resize(object sender, EventArgs e)
        {
            this.dgvExifData.Columns[1].Width = this.dgvExifData.ClientRectangle.Width - this.dgvExifData.Columns[0].Width;
            //this.dgvExifData.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        private void dgvPhotoData_Resize(object sender, EventArgs e)
        {
            this.dgvPhotoData.Columns[1].Width = this.dgvExifData.ClientRectangle.Width - this.dgvPhotoData.Columns[0].Width;
            //this.dgvPhotoData.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        private void tpExifData_Enter(object sender, EventArgs e)
        {
            this.dgvExifData.Columns[1].Width = this.dgvExifData.ClientRectangle.Width - this.dgvExifData.Columns[0].Width;
            //this.dgvExifData.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        private void tpPhotoData_Enter(object sender, EventArgs e)
        {
            this.dgvPhotoData.Columns[1].Width = this.dgvExifData.ClientRectangle.Width - this.dgvPhotoData.Columns[0].Width;
            //this.dgvPhotoData.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        #endregion
    }
}
