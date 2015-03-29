using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessingBLL;

namespace ImagesProcessing
{
    public partial class ZhukMethodForm : Form
    {
        private Bitmap sourceImage;
        public ZhukMethodForm()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceImage = new Bitmap(openFileDialog.FileName);
                sourceImagePictureBox.Image = sourceImage;
            }
        }

        private void zhukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sourceImage != null)
            {
                var contour = ImageHelper.СircuitZhukMethod(sourceImage);
                var contourImage = new Bitmap(sourceImage.Width, sourceImage.Height);
                ImageHelper.DrawPoints(sourceImage, contour, Color.White);
                ImageHelper.DrawPoints(contourImage, contour, Color.Black);
                sourceImagePictureBox.Image = sourceImage;
                contourPictureBox.Image = contourImage;
            }
        }
    }
}