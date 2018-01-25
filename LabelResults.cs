using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeJePecat
{
    public partial class LabelResults : Form
    {
        string _imageFilePaths;
        int imageIndex = 0;
        string[] imageFilePaths;
        string _currentImageFilePath;
        private string _destPath;
        List<Stamp> stamps;

        public string CurrentImageFilePath
        {
            get
            {
                return _currentImageFilePath;
            }

            set
            {
                _currentImageFilePath = value;
            }
        }

        public List<Stamp> Stamps
        {
            get
            {
                return stamps;
            }

            set
            {
                stamps = value;
            }
        }

        public LabelResults()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pbCut.SizeMode = PictureBoxSizeMode.Zoom;

            _imageFilePaths = "C:\\Users\\zmarkoc\\Desktop\\DEST";
            txtSource.Text = _imageFilePaths;

            _destPath = @"C:\Users\zmarkoc\Desktop\CUTDEST";
            txtDestination.Text = @"C:\Users\zmarkoc\Desktop\CUTDEST";

            btnOK.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

            Stamps = new List<DeJePecat.Stamp>();
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            StartLabeling();

        }

        private void btnComparisonResultPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                _imageFilePaths = fbd.SelectedPath;
                txtSource.Text = _imageFilePaths;
            }
             
        }

        private void StartLabeling()
        {
            if(String.IsNullOrEmpty(_imageFilePaths))
            {
                MessageBox.Show("Source folder not set!");
                return;
            }
            if (String.IsNullOrEmpty(_destPath))
            {
                MessageBox.Show("Destination folder not set!");
                return;
            }

            imageFilePaths = Utility.GetImageFilePaths(_imageFilePaths);

            if(imageFilePaths.Length == 0)
            {
                MessageBox.Show("No images in folder: " + _imageFilePaths);
                return;
            }

            pictureBox1.Image = Image.FromFile(imageFilePaths[imageIndex]);
            CurrentImageFilePath = imageFilePaths[imageIndex];

            btnOK.Visible = true;
            gbImage.Text = "Click on center of stamp for extracting stamp in the new image.";
            label1.Visible = true;
            label2.Visible = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Image<Gray, Byte> image = new Image<Gray, Byte>(CurrentImageFilePath);

            int ix, iy;

            Image<Gray, Byte> cut = Utility.GetImageRoiFromCenter(image, me.X, me.Y, image.Width, ((PictureBox)sender).Width, image.Height, ((PictureBox)sender).Height, out ix, out iy,50);

            string saveTo =   Path.Combine(_destPath, Guid.NewGuid().ToString() + "_" + Path.GetFileNameWithoutExtension(CurrentImageFilePath) + "_CUT.jpg");
            cut.Save(saveTo);

            pbCut.Image = cut.Bitmap;

            Stamp stamp = new DeJePecat.Stamp();
            stamp.FileName = Path.GetFileName(CurrentImageFilePath);
            stamp.X = ix;
            stamp.Y = iy;

            Stamps.Add(stamp);

        }


        private void btnDestination_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                _destPath = fbd.SelectedPath;
                txtDestination.Text = _destPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(imageIndex + 1 == imageFilePaths.Length)
            {
                MessageBox.Show("All images are labeled!");
                return;
            }

            imageIndex++;
            CurrentImageFilePath = imageFilePaths[imageIndex];
            pictureBox1.Image = Image.FromFile(CurrentImageFilePath);
            pbCut.Image = null;

            gbImage.Text = "Processed: " + imageIndex.ToString() + " / " + imageFilePaths.Length.ToString();

            

        }

        private void btnCreateJson_Click(object sender, EventArgs e)
        {
            Utility.Serialize(Stamps, _destPath, Guid.NewGuid().ToString(), "LABELED", 0);
            MessageBox.Show("Process is finished. Labeled stamps can be found in file: " + _destPath + ".");
        }
    }

}
