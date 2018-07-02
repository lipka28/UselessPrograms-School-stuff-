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

namespace BruteForce
{
    public partial class Form1 : Form
    {
        private String output = null;
        private String input = null;
        private readonly object syncLock = new object();
        bool found = false;
        private String result = "Wait!!";
        private List<String> wordList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void b_sEncrypt_Click(object sender, EventArgs e)
        {
            DialogResult dialog = saveFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                output = saveFileDialog1.FileName;
                using (Stream mystream = File.Open(output, FileMode.Create))

                {
                    Cypherer cp = new Cypherer(t_passPhase.Text);
                    cp.letsEncrypt(mystream, richTextBox1.Text);

                    mystream.Close();

                }
            }


        }

        private void b_lDecode_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();

        }

        private void b_chooseFile_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                input = openFileDialog1.FileName;
            }

        }

        private void b_selectDict_Click(object sender, EventArgs e)
        {
            String dictionaryPath;
            DialogResult dialog = openFileDialog2.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                dictionaryPath = openFileDialog2.FileName;
                FileStream file = new FileStream(dictionaryPath, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    wordList.Add(line);
                }
                MessageBox.Show("Loading done");
            }


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            found = false;

            if (wordList.Count() == 0) MessageBox.Show("No dictionary chosen");
            else if (input == null) MessageBox.Show("No target file found");
            else
            {
                Parallel.ForEach(wordList, (word, state) =>
                {

                    if (found != true)
                    {
                        lock (syncLock) { Stream instream = File.Open(input, FileMode.Open);
                            Cypherer cp = new Cypherer(word);
                            String text;
                            text = cp.letsDecrypt(instream);
                            if (text != "-1")
                            {
                                result = text;
                                found = true;
                            }
                            instream.Close();
                            }
                    }
                    else state.Break();
                });

                if (found != true) result = "Nothing Found";

            }

        }





        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void b_check_Click(object sender, EventArgs e)
        {

            richTextBox2.Text = result;
        }
    }
    
}
