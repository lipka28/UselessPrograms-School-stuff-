using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private Drawer dr;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void otevřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myMap map = bitMapReader.Read(openFileDialog1.OpenFile());
                textShower.AppendText(map.usefullInfo());
                Bitmap pixmap = new Bitmap(map.GetWidth(), map.GetHeight());
                int position = 0;
                int skip = (map.PixelAmount()/map.GetHeight())-map.GetWidth();

                for (int i = map.GetHeight()-1; i >= 0; i--) {
                    for (int j = 0; j < map.GetWidth(); j++)
                    {

                            if (map.Pixel(position) == false) pixmap.SetPixel(j, i, Color.Black);
                            else pixmap.SetPixel(j, i, Color.White);
                            position++;
                        
                    }
                    position += skip;
                    
                }
                pictureBox1.Image = pixmap;
                dr = new Drawer(pixmap);

            }
            toolStrip1.Show();
        }

        private void novýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap pixmap = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    pixmap.SetPixel(i, j, Color.White);
                }

            }

            toolStrip1.Show();
            pictureBox1.Image = pixmap;
            dr = new Drawer(pixmap);
        }

        private void btnColorPick_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColorPick.BackColor = colorDialog1.Color;
                dr.setColor(colorDialog1.Color);

            }
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            dr.changeShape(1);
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            dr.changeShape(2);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                dr.setPosition(e.Location);
                dr.Click();
                pictureBox1.Image = dr.getMap();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            dr.Undo();
            pictureBox1.Image = dr.getMap();
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            dr.Redo();
            pictureBox1.Image = dr.getMap();
        }

        private void turnRight_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker2.IsBusy && !backgroundWorker1.IsBusy && toolStrip1.Visible)
            {
                backgroundWorker2.RunWorkerAsync();
            }

        }

        private void turnLeft_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker2.IsBusy && !backgroundWorker1.IsBusy && toolStrip1.Visible)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap Old = new Bitmap(pictureBox1.Image);
            Bitmap New = new Bitmap(Old.Height, Old.Width);
            for (int i = 0; i < Old.Width; i++) {
                for (int j = 0; j < Old.Height; j++)
                {
                    New.SetPixel(j, i, Old.GetPixel(i, j));
                }
            }

            pictureBox1.Image = New;

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap Old = new Bitmap(pictureBox1.Image);
            Bitmap New = new Bitmap(Old.Height, Old.Width);
            for (int i = 0; i < Old.Width; i++)
            {
                for (int j = 0; j < Old.Height; j++)
                {
                    New.SetPixel(New.Width-j-1, New.Height-i - 1, Old.GetPixel(Old.Width-i - 1, Old.Height-j - 1));
                }
            }

            pictureBox1.Image = New;

        }


        private void saveToBinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Stream mystream = File.Open("data.bin",FileMode.Create))
            {
                List<Shape> shapes = dr.getShapes();
                ShapeSerializer.ShapesSerialize(mystream, shapes);
                mystream.Close();
            }
        }

        private void loadFromBinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Stream inStream = File.Open("data.bin", FileMode.Open))
            {
                List<Shape> shapes = ShapeSerializer.ShapesDeserialize(inStream);
                dr.setShapes(shapes);
                pictureBox1.Image = dr.getMap();
                inStream.Close();

            }

        }

        private void binZipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Stream mystream = File.Open("data.binZip", FileMode.Create))
            {
                List<Shape> shapes = dr.getShapes();
                ShapeSerializer.ShapesZipSer(mystream, shapes);
                mystream.Close();
            }
        }

        private void binZipToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Stream inStream = File.Open("data.binZip", FileMode.Open))
            {
                List<Shape> shapes = ShapeSerializer.ShapesZipDes(inStream);
                dr.setShapes(shapes);
                pictureBox1.Image = dr.getMap();
                inStream.Close();

            }

        }

        private void binEncryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Stream mystream = File.Open("data.ebin", FileMode.Create))
            {
                List<Shape> shapes = dr.getShapes();
                ShapeSerializer.ShapesEncryptSer(mystream,shapes, "oskdjfhz");
                mystream.Close();
            }

        }

        private void binEncryptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Stream inStream = File.Open("data.ebin", FileMode.Open))
            {
                List<Shape> shapes = ShapeSerializer.ShapesEncryptDes(inStream, "oskdjfhz");
                dr.setShapes(shapes);
                pictureBox1.Image = dr.getMap();
                inStream.Close();

            }

        }

        private void binZipEncryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Stream mystream = File.Open("data.ebinZip", FileMode.Create))
            {
                List<Shape> shapes = dr.getShapes();
                ShapeSerializer.ShapesEncryptZipSer(mystream, shapes, "oskdjfhz");
                mystream.Close();
            }

        }

        private void binZipEncryptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Stream inStream = File.Open("data.ebinZip", FileMode.Open))
            {
                List<Shape> shapes = ShapeSerializer.ShapesEncryptZipDes(inStream, "oskdjfhz");
                dr.setShapes(shapes);
                pictureBox1.Image = dr.getMap();
                inStream.Close();

            }

        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Stream mystream = File.Open("data.xml", FileMode.Create))
            {
                List<Shape> shapes = dr.getShapes();
                ShapeSerializer.ShapesXMLSer(mystream, shapes);
                mystream.Close();
            }

        }

        private void sOAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Stream mystream = File.Open("dataSoap.xml", FileMode.Create))
            {
                List<Shape> shapes = dr.getShapes();
                ShapeSerializer.ShapesSOAPSer(mystream, shapes);
                mystream.Close();
            }

        }
    }
}
