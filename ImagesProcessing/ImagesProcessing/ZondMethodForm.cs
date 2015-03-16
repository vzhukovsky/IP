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
using ImageProcessingBLL.Zond;

namespace ImagesProcessing
{
    public partial class ZondMethodForm : Form
    {
        private ZondProcessor zondProcessor;
        private Bitmap image;
        private Bitmap zondImage;
        private List<Zond> zonds;

        public void InitialSetting()
        {
            zonds = new List<Zond>();
            image = null;
            zondImage = null;

            imagePictureBox.Image = null;
            zondPictureBox.Image = null;
        }
        
        public ZondMethodForm()
        {
            zondProcessor = new ZondProcessor();
           
            InitializeComponent();
            InitialSetting();
        }
   
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                InitialSetting();
                image = new Bitmap(openFileDialog.FileName);
                imagePictureBox.Image = image;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                image = ImageHelper.CutImage(image);
                imagePictureBox.Image = image;
            }
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                zondImage = new Bitmap(openFileDialog.FileName);
                zondPictureBox.Image = zondImage;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zondImage != null)
            {
                zonds.Add(zondProcessor.ConvertImageToZond(zondImage));
                zondImage = null;
                zondPictureBox.Image = null;
            }
        }

        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null && zonds.Count != 0)
            {
                zondProcessor.DrawZondsOnImage(image, zonds);
                imagePictureBox.Image = image;
            }
        }
    }
}
