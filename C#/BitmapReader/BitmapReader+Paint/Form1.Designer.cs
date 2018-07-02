namespace BitmapReader
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otevřítToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToBinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromBinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textShower = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.btnFront = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRect = new System.Windows.Forms.ToolStripButton();
            this.btnCircle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnColorPick = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.turnLeft = new System.Windows.Forms.ToolStripButton();
            this.turnRight = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.otherSaveMethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binZipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binEncryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binZipEncryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherLoadMethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binZipToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.binEncryptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.binZipEncryptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sOAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1350, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novýToolStripMenuItem,
            this.otevřítToolStripMenuItem,
            this.saveToBinToolStripMenuItem,
            this.loadFromBinToolStripMenuItem,
            this.otherSaveMethodsToolStripMenuItem,
            this.otherLoadMethodsToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // novýToolStripMenuItem
            // 
            this.novýToolStripMenuItem.Name = "novýToolStripMenuItem";
            this.novýToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.novýToolStripMenuItem.Text = "Nový";
            this.novýToolStripMenuItem.Click += new System.EventHandler(this.novýToolStripMenuItem_Click);
            // 
            // otevřítToolStripMenuItem
            // 
            this.otevřítToolStripMenuItem.Name = "otevřítToolStripMenuItem";
            this.otevřítToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.otevřítToolStripMenuItem.Text = "Otevřít...";
            this.otevřítToolStripMenuItem.Click += new System.EventHandler(this.otevřítToolStripMenuItem_Click);
            // 
            // saveToBinToolStripMenuItem
            // 
            this.saveToBinToolStripMenuItem.Name = "saveToBinToolStripMenuItem";
            this.saveToBinToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveToBinToolStripMenuItem.Text = "Save to bin";
            this.saveToBinToolStripMenuItem.Click += new System.EventHandler(this.saveToBinToolStripMenuItem_Click);
            // 
            // loadFromBinToolStripMenuItem
            // 
            this.loadFromBinToolStripMenuItem.Name = "loadFromBinToolStripMenuItem";
            this.loadFromBinToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.loadFromBinToolStripMenuItem.Text = "Load from bin";
            this.loadFromBinToolStripMenuItem.Click += new System.EventHandler(this.loadFromBinToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textShower);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1350, 705);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 1;
            // 
            // textShower
            // 
            this.textShower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textShower.Location = new System.Drawing.Point(0, 0);
            this.textShower.Name = "textShower";
            this.textShower.Size = new System.Drawing.Size(215, 705);
            this.textShower.TabIndex = 2;
            this.textShower.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBack,
            this.btnFront,
            this.toolStripSeparator3,
            this.btnRect,
            this.btnCircle,
            this.toolStripSeparator2,
            this.btnColorPick,
            this.toolStripSeparator1,
            this.turnLeft,
            this.turnRight});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1131, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 22);
            this.btnBack.Text = "undo";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnFront
            // 
            this.btnFront.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFront.Image = ((System.Drawing.Image)(resources.GetObject("btnFront.Image")));
            this.btnFront.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(23, 22);
            this.btnFront.Text = "redo";
            this.btnFront.Click += new System.EventHandler(this.btnFront_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRect
            // 
            this.btnRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRect.Image = ((System.Drawing.Image)(resources.GetObject("btnRect.Image")));
            this.btnRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(23, 22);
            this.btnRect.Text = "draw rectangles";
            this.btnRect.Click += new System.EventHandler(this.btnRect_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCircle.Image = ((System.Drawing.Image)(resources.GetObject("btnCircle.Image")));
            this.btnCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(23, 22);
            this.btnCircle.Text = "draw circles";
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnColorPick
            // 
            this.btnColorPick.BackColor = System.Drawing.Color.Black;
            this.btnColorPick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnColorPick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColorPick.Name = "btnColorPick";
            this.btnColorPick.Size = new System.Drawing.Size(23, 22);
            this.btnColorPick.Text = "pick color";
            this.btnColorPick.Click += new System.EventHandler(this.btnColorPick_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // turnLeft
            // 
            this.turnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.turnLeft.Image = ((System.Drawing.Image)(resources.GetObject("turnLeft.Image")));
            this.turnLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.turnLeft.Name = "turnLeft";
            this.turnLeft.Size = new System.Drawing.Size(23, 22);
            this.turnLeft.Text = "turn left";
            this.turnLeft.Click += new System.EventHandler(this.turnLeft_Click);
            // 
            // turnRight
            // 
            this.turnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.turnRight.Image = ((System.Drawing.Image)(resources.GetObject("turnRight.Image")));
            this.turnRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.turnRight.Name = "turnRight";
            this.turnRight.Size = new System.Drawing.Size(23, 22);
            this.turnRight.Text = "turn right";
            this.turnRight.Click += new System.EventHandler(this.turnRight_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1131, 673);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // otherSaveMethodsToolStripMenuItem
            // 
            this.otherSaveMethodsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binZipToolStripMenuItem,
            this.binEncryptToolStripMenuItem,
            this.binZipEncryptToolStripMenuItem,
            this.xMLToolStripMenuItem,
            this.sOAPToolStripMenuItem});
            this.otherSaveMethodsToolStripMenuItem.Name = "otherSaveMethodsToolStripMenuItem";
            this.otherSaveMethodsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.otherSaveMethodsToolStripMenuItem.Text = "Other Save Methods";
            // 
            // binZipToolStripMenuItem
            // 
            this.binZipToolStripMenuItem.Name = "binZipToolStripMenuItem";
            this.binZipToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.binZipToolStripMenuItem.Text = "BinZip";
            this.binZipToolStripMenuItem.Click += new System.EventHandler(this.binZipToolStripMenuItem_Click);
            // 
            // binEncryptToolStripMenuItem
            // 
            this.binEncryptToolStripMenuItem.Name = "binEncryptToolStripMenuItem";
            this.binEncryptToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.binEncryptToolStripMenuItem.Text = "BinEncrypt";
            this.binEncryptToolStripMenuItem.Click += new System.EventHandler(this.binEncryptToolStripMenuItem_Click);
            // 
            // binZipEncryptToolStripMenuItem
            // 
            this.binZipEncryptToolStripMenuItem.Name = "binZipEncryptToolStripMenuItem";
            this.binZipEncryptToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.binZipEncryptToolStripMenuItem.Text = "BinZipEncrypt";
            this.binZipEncryptToolStripMenuItem.Click += new System.EventHandler(this.binZipEncryptToolStripMenuItem_Click);
            // 
            // otherLoadMethodsToolStripMenuItem
            // 
            this.otherLoadMethodsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binZipToolStripMenuItem1,
            this.binEncryptToolStripMenuItem1,
            this.binZipEncryptToolStripMenuItem1});
            this.otherLoadMethodsToolStripMenuItem.Name = "otherLoadMethodsToolStripMenuItem";
            this.otherLoadMethodsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.otherLoadMethodsToolStripMenuItem.Text = "Other Load Methods";
            // 
            // binZipToolStripMenuItem1
            // 
            this.binZipToolStripMenuItem1.Name = "binZipToolStripMenuItem1";
            this.binZipToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.binZipToolStripMenuItem1.Text = "BinZip";
            this.binZipToolStripMenuItem1.Click += new System.EventHandler(this.binZipToolStripMenuItem1_Click);
            // 
            // binEncryptToolStripMenuItem1
            // 
            this.binEncryptToolStripMenuItem1.Name = "binEncryptToolStripMenuItem1";
            this.binEncryptToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.binEncryptToolStripMenuItem1.Text = "BinEncrypt";
            this.binEncryptToolStripMenuItem1.Click += new System.EventHandler(this.binEncryptToolStripMenuItem1_Click);
            // 
            // binZipEncryptToolStripMenuItem1
            // 
            this.binZipEncryptToolStripMenuItem1.Name = "binZipEncryptToolStripMenuItem1";
            this.binZipEncryptToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.binZipEncryptToolStripMenuItem1.Text = "BinZipEncrypt";
            this.binZipEncryptToolStripMenuItem1.Click += new System.EventHandler(this.binZipEncryptToolStripMenuItem1_Click);
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xMLToolStripMenuItem.Text = "XML";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.xMLToolStripMenuItem_Click);
            // 
            // sOAPToolStripMenuItem
            // 
            this.sOAPToolStripMenuItem.Name = "sOAPToolStripMenuItem";
            this.sOAPToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sOAPToolStripMenuItem.Text = "SOAP";
            this.sOAPToolStripMenuItem.Click += new System.EventHandler(this.sOAPToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "BitmapReader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otevřítToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox textShower;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem novýToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRect;
        private System.Windows.Forms.ToolStripButton btnCircle;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.ToolStripButton btnFront;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripButton btnColorPick;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton turnLeft;
        private System.Windows.Forms.ToolStripButton turnRight;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolStripMenuItem saveToBinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadFromBinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherSaveMethodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binZipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binEncryptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binZipEncryptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherLoadMethodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binZipToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem binEncryptToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem binZipEncryptToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sOAPToolStripMenuItem;
    }
}

