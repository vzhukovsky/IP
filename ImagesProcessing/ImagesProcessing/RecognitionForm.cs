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
using ImageProcessingBLL.Recognition;

namespace ImagesProcessing
{
    public partial class RecognitionForm : Form
    {
        private RecognitionResolver recognitionResolver;
        public RecognitionForm()
        {
            InitializeComponent();
            recognitionResolver = new RecognitionResolver(5, Directory.GetCurrentDirectory() + @"\Recognition\");
        }

        private void RecognitionForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = recognitionResolver.GetDataSource();
        }
    }
}
