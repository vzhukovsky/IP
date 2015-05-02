using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
            image = null;
            zondImage = null;
            imagePictureBox.Image = null;
            zondPictureBox.Image = null;
        }
        
        public ZondMethodForm()
        {
            zondProcessor = new ZondProcessor();
            zonds = new List<Zond>();
            InitializeComponent();
            InitialSetting();
        }

        private void ClearZondImage()
        {
            zondImage = null;
            zondPictureBox.Image = null;
        }

        private void AddColumnToStatusGrid()
        {
            dataGridView.Columns.Add(zonds.Count.ToString(), zonds.Count.ToString());
        }

        private void AddStatusToGrid(List<bool> zondsStatus)
        {
            var index = dataGridView.Rows.Count - 1;
            for (int i = 0; i < zondsStatus.Count; i++)
            {
                dataGridView.Rows[index].Cells[i].Value = zondsStatus[i].ToString();
            }
        }

        private void ShowResult(List<bool> zondsStatus)
        {
            if (zondsStatus.Count >= 3)
            {
                var result = "Cannot identity!";
                if (!zondsStatus[0] && zondsStatus[1] && !zondsStatus[2])
                {
                    result = "1";
                }
                else
                {
                    if (zondsStatus[0] && !zondsStatus[1] && zondsStatus[2])
                    {
                        result = "2";
                    }
                    else
                    {
                        if (zondsStatus[0] && zondsStatus[1] && !zondsStatus[2])
                        {
                            result = "3";
                        }
                    }
                }

                MessageBox.Show(result);
            }
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
                ClearZondImage();
                AddColumnToStatusGrid();
            }
        }

        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null && zonds.Count != 0)
            {
                var copyImage = image.Clone(new Rectangle(0, 0, image.Width, image.Height), image.PixelFormat);
                var zondsStatus = zondProcessor.DrawZondsOnImage(copyImage, zonds);
                AddStatusToGrid(zondsStatus);
                imagePictureBox.Image = copyImage;
                ShowResult(zondsStatus);
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zonds.Count != 0)
            {
                zondPictureBox.Image = zondProcessor.GetZondsImage(zonds);
            }
        }
    }
}
