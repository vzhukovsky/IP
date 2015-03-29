using System;
using System.Windows.Forms;

namespace ImagesProcessing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var zondForm = new ZondMethodForm();
            zondForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var zhukForm = new ZhukMethodForm();
            zhukForm.Show();
        }
    }
}
