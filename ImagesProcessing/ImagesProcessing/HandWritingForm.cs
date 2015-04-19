using System;
using System.Drawing;
using System.Windows.Forms;
using ImageProcessingBLL.BinaryImages.HandWriting;

namespace ImagesProcessing
{
    public partial class HandWritingForm : Form
    {
        private HandWritingResolver handWritingResolver;
        public HandWritingForm()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(openFileDialog.FileName);
                handWritingResolver = new HandWritingResolver(image);
                pictureBox.Image = handWritingResolver.sourceImage;
            }
        }

        private void analyzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.Image = handWritingResolver.GetLine(3).Image;
        }
    }
}
