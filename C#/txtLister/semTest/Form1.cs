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

namespace semTest
{
    public partial class Form1 : Form
    {

        private String chosenDir;
        private String[] words;
        int numWords;
        private List<String> txtFiles = new List<String>();
        private List<String> foundFiles = new List<String>();


        public Form1()
        {
            InitializeComponent();
        }

        private void choseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath)) {
                chosenDir = folderBrowserDialog1.SelectedPath;
                textBox1.Text = chosenDir;
            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            char[] spliting = { ' ' };
            String wordText = richTextBox1.Text;

            words = wordText.Split(spliting);
            numWords = words.Count();
            backgroundWorker1.RunWorkerAsync();
            

            
        }

        private void searchforTxts(DirectoryInfo folder) {

            FileInfo[] infiles = folder.GetFiles();

            foreach (FileInfo file in infiles) {
                if (!Directory.Exists(chosenDir + "\\"+ file.ToString()))
                {
                    if (file.Extension == ".txt")
                    {
                        txtFiles.Add(chosenDir + "\\" + file.ToString());
                    }
                }
                else searchforTxts(new DirectoryInfo(file.ToString()));
            }


        }

        private void inTxts()
        {
            if(numWords != 0) {

                foreach (String file in txtFiles)
                {
                    bool found = false;
                    foreach (var line in File.ReadAllLines(file))
                    {
                        
                        foreach (String word in words)
                        {
                            if (line.Contains(word))
                            {
                                found = true;
                            }
                        }
                    }
                    if (found == true) foundFiles.Add(file);
                }

            }
            
        }

        private void printToFile()
        {
            StreamWriter stream = new StreamWriter(chosenDir +"\\"+ "result.txt");
            stream.WriteLine("Hledaná slova jsou v následujících souborech:");
            foreach (String file in foundFiles )
            {
                stream.WriteLine(file);
            }
            stream.Close();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            searchforTxts(new DirectoryInfo(chosenDir));
            inTxts();
            printToFile();

        }
    }
}
