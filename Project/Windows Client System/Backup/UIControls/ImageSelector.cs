using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace BinarySoftCo.UIControls
{
    public partial class ImageSelector : UserControl
    {
        int maximumImageSize = 100000;

        public Size ImageBorderSize
        {
            get { return pbPicture.Size; }
        }

        public byte[] SelectedImageBytes
        {
            get
            {
                if (pbPicture.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    //
                    pbPicture.Image.Save(ms, ImageFormat.Jpeg);
                    //
                    return ms.ToArray();
                }
                //
                return new byte[0];
            }
        }

        public Image SelectedImage
        {
            get { return pbPicture.Image; }
            set 
            {
                pbPicture.Image = value;
                //
                llDeletePicture.Enabled = (SelectedImage != null);
            }
        }

        public int MaximumImageSize
        {
            get { return maximumImageSize; }
            set { maximumImageSize = value; }
        }

        public PictureBoxSizeMode SizeMode
        {
            get { return pbPicture.SizeMode; }
            set
            {
                pbPicture.SizeMode = value; 
                //
                if (pbPicture.Image == null)
                    llDeletePicture_LinkClicked(null, null);
            }
        }

        public ImageSelector()
        {
            InitializeComponent();
        }

        private void ImageSelector_Load(object sender, EventArgs e)
        {

        }

        private void llSelectPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "همه موارد|*.jpg;*.bmp;*.png|جی پگ(JPEG)|*.jpg|بیت مپ(BMP)|*.bmp|پی ان جی(PNG)|*.png";
            openImage.Title = "انتخاب عکس";
            openImage.AutoUpgradeEnabled = true;
            //
            if (openImage.ShowDialog() != DialogResult.Cancel)
            {
                if (new FileInfo(openImage.FileName).Length > maximumImageSize)
                {
                    PersianMessageBox.Show(".لطفا حجم عکس مورد نظر را کاهش دهید و مجددا سعی کنید", "انتخاب عکس", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //
                    llSelectPicture_LinkClicked(null, null);
                    //
                    return;
                }
                //
                pbPicture.ImageLocation = openImage.FileName;
                //
                llDeletePicture.Enabled = (SelectedImage != null);
            }
        }

        private void llDeletePicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPicture.Image = null;
            llDeletePicture.Enabled = false;
        }
    }
}
