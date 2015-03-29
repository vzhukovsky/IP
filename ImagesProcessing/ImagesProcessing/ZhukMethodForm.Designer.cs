using System.Windows.Forms;

namespace ImagesProcessing
{
    partial class ZhukMethodForm
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
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zhukToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceImagePictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.contourPictureBox = new System.Windows.Forms.PictureBox();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.zhukToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(623, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // zhukToolStripMenuItem
            // 
            this.zhukToolStripMenuItem.Name = "zhukToolStripMenuItem";
            this.zhukToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.zhukToolStripMenuItem.Text = "Zhuk";
            this.zhukToolStripMenuItem.Click += new System.EventHandler(this.zhukToolStripMenuItem_Click);
            // 
            // sourceImagePictureBox
            // 
            this.sourceImagePictureBox.Location = new System.Drawing.Point(12, 38);
            this.sourceImagePictureBox.Name = "sourceImagePictureBox";
            this.sourceImagePictureBox.Size = new System.Drawing.Size(222, 190);
            this.sourceImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sourceImagePictureBox.TabIndex = 1;
            this.sourceImagePictureBox.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // contourPictureBox
            // 
            this.contourPictureBox.Location = new System.Drawing.Point(266, 38);
            this.contourPictureBox.Name = "contourPictureBox";
            this.contourPictureBox.Size = new System.Drawing.Size(257, 190);
            this.contourPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.contourPictureBox.TabIndex = 2;
            this.contourPictureBox.TabStop = false;
            // 
            // ZhukMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 298);
            this.Controls.Add(this.contourPictureBox);
            this.Controls.Add(this.sourceImagePictureBox);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "ZhukMethodForm";
            this.Text = "ZhukMethodForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.PictureBox sourceImagePictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private ToolStripMenuItem zhukToolStripMenuItem;
        private PictureBox contourPictureBox;
    }
}