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

        private void customizeContextMenu()
        {
            analyzeToolStripMenuItem.DropDownItems.Clear();

            analyzeToolStripMenuItem.DropDownItems.Add("Source image").Click += showSourceImage;

            for (int i = 1; i <= handWritingResolver.LinesCount; i++)
            {
                var menuItem = analyzeToolStripMenuItem.DropDownItems.Add(i.ToString());
                menuItem.Tag = i - 1;
                menuItem.Click += selectLine;
            }            
        }

        private void showSourceImage(object sender, EventArgs e)
        {
            pictureBox.Image = handWritingResolver.SourceImage;
        }

        private void selectLine(object sender, EventArgs e)
        {
            int lineIndex = Convert.ToInt32((sender as ToolStripMenuItem).Tag);
            pictureBox.Image = handWritingResolver.GetLine(lineIndex).Image;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(openFileDialog.FileName);
                handWritingResolver = new HandWritingResolver(image);
                pictureBox.Image = handWritingResolver.SourceImage;

                customizeContextMenu();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var a = handWritingResolver.SampleMeanSquareLineSpacing();
        }
    }
}
