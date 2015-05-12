using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ImageProcessingBLL.Recognition;

namespace ImagesProcessing
{
    public partial class RecognitionForm : Form
    {
        private RecognitionResolver recognitionResolver;
        private Bitmap imageForRecognition;

        public RecognitionForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageForRecognition = new Bitmap(openFileDialog.FileName);
                MessageBox.Show(recognitionResolver.Recognition(imageForRecognition).ToString());
                dataGridView1.DataSource = recognitionResolver.GetDataSource();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            recognitionResolver = new RecognitionResolver(5, Directory.GetCurrentDirectory() + @"\Recognition\", new RecognitionByIntensity());
            dataGridView1.DataSource = recognitionResolver.GetDataSource();
            customizeContextMenu();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            recognitionResolver = new RecognitionResolver(5, Directory.GetCurrentDirectory() + @"\Recognition\black\", new RecognitionByA8());
            dataGridView1.DataSource = recognitionResolver.GetDataSource();
            customizeContextMenu();
        }

        private void customizeContextMenu()
        {
            imagesToolStripMenuItem.DropDownItems.Clear();

            for (int i = 1; i <= 5; i++)
            {
                var menuItem = imagesToolStripMenuItem.DropDownItems.Add(i.ToString());
                menuItem.Tag = i;
                menuItem.Click += showImagesByClass;
            }
        }

        private void showImagesByClass(object sender, EventArgs e)
        {
            int imageClass = Convert.ToInt32((sender as ToolStripMenuItem).Tag);
            var images = recognitionResolver.GetImagesByClass(imageClass);
            pictureBox1.Image = images[0];
            pictureBox2.Image = images[1];
            pictureBox3.Image = images[2];
            pictureBox4.Image = images[3];
            pictureBox5.Image = images[4];
        }
    }
}
