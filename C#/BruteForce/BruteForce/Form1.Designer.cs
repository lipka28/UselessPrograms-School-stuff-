namespace BruteForce
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.t_passPhase = new System.Windows.Forms.TextBox();
            this.b_sEncrypt = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.b_chooseFile = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.b_lDecode = new System.Windows.Forms.Button();
            this.b_selectDict = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.b_check = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.t_passPhase);
            this.splitContainer1.Panel1.Controls.Add(this.b_sEncrypt);
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.b_check);
            this.splitContainer1.Panel2.Controls.Add(this.b_chooseFile);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox2);
            this.splitContainer1.Panel2.Controls.Add(this.b_lDecode);
            this.splitContainer1.Panel2.Controls.Add(this.b_selectDict);
            this.splitContainer1.Size = new System.Drawing.Size(646, 408);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password:";
            // 
            // t_passPhase
            // 
            this.t_passPhase.Location = new System.Drawing.Point(74, 347);
            this.t_passPhase.Name = "t_passPhase";
            this.t_passPhase.Size = new System.Drawing.Size(217, 20);
            this.t_passPhase.TabIndex = 2;
            // 
            // b_sEncrypt
            // 
            this.b_sEncrypt.Location = new System.Drawing.Point(12, 373);
            this.b_sEncrypt.Name = "b_sEncrypt";
            this.b_sEncrypt.Size = new System.Drawing.Size(279, 23);
            this.b_sEncrypt.TabIndex = 1;
            this.b_sEncrypt.Text = "Save and Encrypt";
            this.b_sEncrypt.UseVisualStyleBackColor = true;
            this.b_sEncrypt.Click += new System.EventHandler(this.b_sEncrypt_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(279, 329);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // b_chooseFile
            // 
            this.b_chooseFile.Location = new System.Drawing.Point(17, 12);
            this.b_chooseFile.Name = "b_chooseFile";
            this.b_chooseFile.Size = new System.Drawing.Size(307, 23);
            this.b_chooseFile.TabIndex = 3;
            this.b_chooseFile.Text = "Choose file";
            this.b_chooseFile.UseVisualStyleBackColor = true;
            this.b_chooseFile.Click += new System.EventHandler(this.b_chooseFile_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(17, 128);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(307, 268);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // b_lDecode
            // 
            this.b_lDecode.Location = new System.Drawing.Point(17, 70);
            this.b_lDecode.Name = "b_lDecode";
            this.b_lDecode.Size = new System.Drawing.Size(307, 23);
            this.b_lDecode.TabIndex = 1;
            this.b_lDecode.Text = "Decode and find words from dictionary";
            this.b_lDecode.UseVisualStyleBackColor = true;
            this.b_lDecode.Click += new System.EventHandler(this.b_lDecode_Click);
            // 
            // b_selectDict
            // 
            this.b_selectDict.Location = new System.Drawing.Point(17, 41);
            this.b_selectDict.Name = "b_selectDict";
            this.b_selectDict.Size = new System.Drawing.Size(307, 23);
            this.b_selectDict.TabIndex = 0;
            this.b_selectDict.Text = "Choose dictionary (txt)";
            this.b_selectDict.UseVisualStyleBackColor = true;
            this.b_selectDict.Click += new System.EventHandler(this.b_selectDict_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "ebin";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "encrypted file|*.ebin";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "dictionary|*.txt";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // b_check
            // 
            this.b_check.Location = new System.Drawing.Point(17, 99);
            this.b_check.Name = "b_check";
            this.b_check.Size = new System.Drawing.Size(307, 23);
            this.b_check.TabIndex = 4;
            this.b_check.Text = "check Result";
            this.b_check.UseVisualStyleBackColor = true;
            this.b_check.Click += new System.EventHandler(this.b_check_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 408);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "BruteForceApp";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_passPhase;
        private System.Windows.Forms.Button b_sEncrypt;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button b_lDecode;
        private System.Windows.Forms.Button b_selectDict;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button b_chooseFile;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button b_check;
    }
}

