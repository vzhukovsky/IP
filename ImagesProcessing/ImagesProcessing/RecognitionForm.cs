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
            recognitionResolver = new RecognitionResolver(5, Directory.GetCurrentDirectory() + @"\Recognition\");
        }

        private void RecognitionForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = recognitionResolver.GetDataSource();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageForRecognition = new Bitmap(openFileDialog.FileName);
                recognitionResolver.Recognition(imageForRecognition);
                dataGridView1.DataSource = recognitionResolver.GetDataSource();
            }
        }
    }
}
