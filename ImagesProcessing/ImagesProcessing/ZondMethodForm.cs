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

        public ZondMethodForm()
        {
            zondProcessor = new ZondProcessor();
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
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
    }
}
