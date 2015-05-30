using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ImageProcessingBLL.BinaryImages.HandWriting;
using ImageProcessingBLL.CutPlace;
using SecantMethod.TablePriznakov;

namespace ImagesProcessing
{
    public partial class HandWritingForm : Form
    {
        private List<HandWritingResolver> handWritingResolvers = new List<HandWritingResolver>();
        private HandWritingResolver selectedHandWritingResolver;
        public HandWritingForm()
        {
            InitializeComponent();
        }

        private void customizeImagesMenu()
        {
            imagesToolStripMenuItem.DropDownItems.Clear();

            for (int i = 1; i <= handWritingResolvers.Count; i++)
            {
                var menuItem = imagesToolStripMenuItem.DropDownItems.Add(i.ToString());
                menuItem.Tag = i - 1;
                menuItem.Click += selectImage;
            }
            customizeContextMenu();
        }

        private void selectLine(object sender, EventArgs e)
        {
            int lineIndex = Convert.ToInt32((sender as ToolStripMenuItem).Tag);
            pictureBox.Image = selectedHandWritingResolver.GetLine(lineIndex).Image;
        }

        private void customizeContextMenu()
        {
            analyzeToolStripMenuItem.DropDownItems.Clear();

            analyzeToolStripMenuItem.DropDownItems.Add("Source image").Click += showSourceImage;

            for (int i = 1; i <= selectedHandWritingResolver.LinesCount; i++)
            {
                var menuItem = analyzeToolStripMenuItem.DropDownItems.Add(i.ToString());
                menuItem.Tag = i - 1;
                menuItem.Click += selectLine;
            }            
        }

        private void selectImage(object sender, EventArgs e)
        {
            int imageIndex = Convert.ToInt32((sender as ToolStripMenuItem).Tag);
            selectedHandWritingResolver = handWritingResolvers[imageIndex];
            pictureBox.Image = selectedHandWritingResolver.SourceImage;
            customizeContextMenu();
        }

        private void showSourceImage(object sender, EventArgs e)
        {
            pictureBox.Image = selectedHandWritingResolver.SourceImage;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(openFileDialog.FileName);
                selectedHandWritingResolver = new HandWritingResolver(image);
                pictureBox.Image = selectedHandWritingResolver.SourceImage;
                dataGridView1.Rows.Add(selectedHandWritingResolver.GetRow().ToArray());
                handWritingResolvers.Add(selectedHandWritingResolver);
                customizeImagesMenu();
            }
        }

        private void ClearTables()
        {
            lambdaDataGridView.Rows.Clear();
            lambdaDataGridView.Refresh();

            signTableDataGridView.Rows.Clear();
            signTableDataGridView.Refresh();

            reduceDataGridView.Rows.Clear();
            reduceDataGridView.Refresh();

            rankDataGridView.Rows.Clear();
            rankDataGridView.Refresh();

            additionTableGridView.Rows.Clear();
            additionTableGridView.Refresh();

            metricsDataGridView.Rows.Clear();
            metricsDataGridView.Refresh();
        }

        private void loadImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(openFileDialog.FileName);
                var handWritingResolver = new HandWritingResolver(image);
                var cutPlaceresolver = new CutPlaceResolver(12);

                MessageBox.Show(cutPlaceresolver.Recognition(handWritingResolver.GetMetrics(), reduceDataGridView));
            }
        }

        private void buildTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cutPlaceresolver = new CutPlaceResolver(12);
            List<PriznakTable> metrics = handWritingResolvers.Select(obj => obj.GetMetrics()).ToList();
            PriznakTable.OrderMetrics(metrics);
            ClearTables();
            cutPlaceresolver.MethodSek(
                metrics,
                lambdaDataGridView,
                signTableDataGridView,
                reduceDataGridView,
                rankDataGridView,
                additionTableGridView,
                metricsDataGridView);

            tabControl1.SelectTab(tabPage3);
        }
    }
}
