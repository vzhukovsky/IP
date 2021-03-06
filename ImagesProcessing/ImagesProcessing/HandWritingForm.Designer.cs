﻿using System.Windows.Forms;

namespace ImagesProcessing
{
    partial class HandWritingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recognitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buildTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lambdaDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.signTableDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.reduceDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rankDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.additionTableGridView = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.metricsDataGridView = new System.Windows.Forms.DataGridView();
            this.infoListBox = new System.Windows.Forms.ListBox();
            this.blockPictureBox = new System.Windows.Forms.PictureBox();
            this.blockNumberTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lambdaDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signTableDataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reduceDataGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rankDataGridView)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.additionTableGridView)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metricsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.imagesToolStripMenuItem,
            this.analyzeToolStripMenuItem,
            this.recognitionToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1109, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.loadImageToolStripMenuItem.Text = "Actions";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.imagesToolStripMenuItem.Text = "Images";
            // 
            // analyzeToolStripMenuItem
            // 
            this.analyzeToolStripMenuItem.Name = "analyzeToolStripMenuItem";
            this.analyzeToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.analyzeToolStripMenuItem.Text = "Analyze";
            // 
            // recognitionToolStripMenuItem
            // 
            this.recognitionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem1,
            this.buildTablesToolStripMenuItem});
            this.recognitionToolStripMenuItem.Name = "recognitionToolStripMenuItem";
            this.recognitionToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.recognitionToolStripMenuItem.Text = "Recognition";
            // 
            // loadImageToolStripMenuItem1
            // 
            this.loadImageToolStripMenuItem1.Name = "loadImageToolStripMenuItem1";
            this.loadImageToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.loadImageToolStripMenuItem1.Text = "Load image";
            this.loadImageToolStripMenuItem1.Click += new System.EventHandler(this.loadImageToolStripMenuItem1_Click);
            // 
            // buildTablesToolStripMenuItem
            // 
            this.buildTablesToolStripMenuItem.Name = "buildTablesToolStripMenuItem";
            this.buildTablesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.buildTablesToolStripMenuItem.Text = "Build tables";
            this.buildTablesToolStripMenuItem.Click += new System.EventHandler(this.buildTablesToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 27);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(754, 211);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16});
            this.dataGridView1.Location = new System.Drawing.Point(12, 256);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1081, 209);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ВС коэффицента заполнения";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ВСКО коэффицента заполнения";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ВС высоты строк";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ВСКО высоты строк";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ВС межстрочного интервала";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ВСКО межстрочного интервала";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ВС шириры блока";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ВСКО шириры блока";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "ВС количества блоков в строке";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "ВСКО количества блоков в строке";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "ВС размера блоков, обр строчными элементами";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "ВСКО размера блоков, обр строчными элементами";
            this.Column12.Name = "Column12";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 471);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1085, 330);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lambdaDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1077, 304);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lambda table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lambdaDataGridView
            // 
            this.lambdaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lambdaDataGridView.Location = new System.Drawing.Point(6, 15);
            this.lambdaDataGridView.Name = "lambdaDataGridView";
            this.lambdaDataGridView.Size = new System.Drawing.Size(1065, 189);
            this.lambdaDataGridView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.signTableDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1077, 304);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sign table";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // signTableDataGridView
            // 
            this.signTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.signTableDataGridView.Location = new System.Drawing.Point(16, 6);
            this.signTableDataGridView.Name = "signTableDataGridView";
            this.signTableDataGridView.Size = new System.Drawing.Size(966, 232);
            this.signTableDataGridView.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.reduceDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1077, 304);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reduce table";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // reduceDataGridView
            // 
            this.reduceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reduceDataGridView.Location = new System.Drawing.Point(6, 6);
            this.reduceDataGridView.Name = "reduceDataGridView";
            this.reduceDataGridView.Size = new System.Drawing.Size(1065, 246);
            this.reduceDataGridView.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rankDataGridView);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1077, 304);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Rank table";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // rankDataGridView
            // 
            this.rankDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rankDataGridView.Location = new System.Drawing.Point(6, 6);
            this.rankDataGridView.Name = "rankDataGridView";
            this.rankDataGridView.Size = new System.Drawing.Size(1065, 252);
            this.rankDataGridView.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.additionTableGridView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1077, 304);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Addition table";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // additionTableGridView
            // 
            this.additionTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.additionTableGridView.Location = new System.Drawing.Point(6, 6);
            this.additionTableGridView.Name = "additionTableGridView";
            this.additionTableGridView.Size = new System.Drawing.Size(1065, 242);
            this.additionTableGridView.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.metricsDataGridView);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1077, 304);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Metrics table";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // metricsDataGridView
            // 
            this.metricsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metricsDataGridView.Location = new System.Drawing.Point(6, 15);
            this.metricsDataGridView.Name = "metricsDataGridView";
            this.metricsDataGridView.Size = new System.Drawing.Size(1065, 223);
            this.metricsDataGridView.TabIndex = 0;
            // 
            // infoListBox
            // 
            this.infoListBox.FormattingEnabled = true;
            this.infoListBox.Location = new System.Drawing.Point(772, 27);
            this.infoListBox.Name = "infoListBox";
            this.infoListBox.Size = new System.Drawing.Size(185, 69);
            this.infoListBox.TabIndex = 4;
            // 
            // blockPictureBox
            // 
            this.blockPictureBox.Location = new System.Drawing.Point(772, 102);
            this.blockPictureBox.Name = "blockPictureBox";
            this.blockPictureBox.Size = new System.Drawing.Size(183, 107);
            this.blockPictureBox.TabIndex = 5;
            this.blockPictureBox.TabStop = false;
            // 
            // blockNumberTextBox
            // 
            this.blockNumberTextBox.Location = new System.Drawing.Point(773, 216);
            this.blockNumberTextBox.Name = "blockNumberTextBox";
            this.blockNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.blockNumberTextBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(880, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Get block";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Column13
            // 
            this.Column13.HeaderText = "ВС отступа слева";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "ВСКО отступа слева";
            this.Column14.Name = "Column14";
            // 
            // Column15
            // 
            this.Column15.HeaderText = "ВС отступа справа";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.HeaderText = "ВСКО отступа справа";
            this.Column16.Name = "Column16";
            // 
            // HandWritingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 741);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.blockNumberTextBox);
            this.Controls.Add(this.blockPictureBox);
            this.Controls.Add(this.infoListBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "HandWritingForm";
            this.Text = "HandWritingForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lambdaDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.signTableDataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reduceDataGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rankDataGridView)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.additionTableGridView)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metricsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private ToolStripMenuItem analyzeToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private ToolStripMenuItem imagesToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView lambdaDataGridView;
        private TabPage tabPage2;
        private DataGridView signTableDataGridView;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private DataGridView reduceDataGridView;
        private DataGridView rankDataGridView;
        private DataGridView additionTableGridView;
        private DataGridView metricsDataGridView;
        private ToolStripMenuItem recognitionToolStripMenuItem;
        private ToolStripMenuItem loadImageToolStripMenuItem1;
        private ToolStripMenuItem buildTablesToolStripMenuItem;
        private ListBox infoListBox;
        private PictureBox blockPictureBox;
        private TextBox blockNumberTextBox;
        private Button button1;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column16;
    }
}