using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmapReader
{
    class Drawer
    {
        private Bitmap map;
        private Bitmap backup;
        private Shape shape;
        private int shapeType = 0;
        private Color currentColor = Color.Black;
        private SolidBrush myBrush;
        private List<Shape> drawThis;
        private Stack<Shape> unDo;
        private Graphics gr;
        private Point position;
        private int click = 1;

        private void ClearHistory() {
            unDo.Clear();
        }

        private void ClearMap() {

            gr.DrawImage(backup, 0, 0);
        }

        private void redraw() {
            ClearMap();

            foreach (Shape currShape in drawThis) {
                if (currShape.Kind == 1) {

                    myBrush = new SolidBrush(currShape.Color);
                    gr.FillRectangle(myBrush, currShape.X1, currShape.Y1, currShape.X2, currShape.Y2);

                }
                else if (currShape.Kind == 2) {

                    myBrush = new SolidBrush(currShape.Color);
                    gr.FillEllipse(myBrush, currShape.X1, currShape.Y1, currShape.X2, currShape.Y2);

                }
            }
        }

        public Drawer(Bitmap map) {
            drawThis = new List<Shape>();
            unDo = new Stack<Shape>();
            this.map = new Bitmap(map);
            backup = new Bitmap(this.map);
            gr = Graphics.FromImage(this.map);

        }

        public void setMap(Bitmap map) {
            clearAll();
            this.map = new Bitmap(map);
            backup = new Bitmap(map);
            gr = Graphics.FromImage(this.map);
        }

        public Bitmap getMap() {

            return map;
        }

        public void changeShape(int type) {
            shapeType = type;
        }

        public void Click() {
            if (click == 1 && shapeType != 0) click++;
            else click = 1;
        }

        public void clearAll() {

            drawThis.Clear();
            unDo.Clear();

        }

        public void setPosition(Point pos) {
            if (click == 1) position = pos;
            else if (click == 2) {
                int tmpX2 = Math.Abs(pos.X);
                int tmpY2 = Math.Abs(pos.Y);
                int tmpX1 = Math.Abs(position.X);
                int tmpY1 = Math.Abs(position.Y);

                tmpX2 = Math.Abs(tmpX2 - tmpX1);
                tmpY2 = Math.Abs(tmpY2 - tmpY1);

                if (position.X < pos.X && position.Y < pos.Y)
                {
                    
                    shape = new Shape(position.X, position.Y, tmpX2, tmpY2, shapeType, currentColor);
                    ClearHistory();
                    drawThis.Add(shape);
                    redraw();

                }
                else if (position.X > pos.X && position.Y > pos.Y) {

                    shape = new Shape(position.X-tmpX2, position.Y-tmpY2, tmpX2, tmpY2, shapeType, currentColor);
                    ClearHistory();
                    drawThis.Add(shape);
                    redraw();
                }

                if (position.X < pos.X && position.Y > pos.Y)
                {

                    shape = new Shape(position.X, position.Y-tmpY2, tmpX2, tmpY2, shapeType, currentColor);
                    ClearHistory();
                    drawThis.Add(shape);
                    redraw();

                }
                else if (position.X > pos.X && position.Y < pos.Y)
                {

                    shape = new Shape(position.X - tmpX2, position.Y, tmpX2, tmpY2, shapeType, currentColor);
                    ClearHistory();
                    drawThis.Add(shape);
                    redraw();
                }


            }


        }
        

        public void setColor(Color color) {
            currentColor = color;
        }

        public void Undo() {
            if (drawThis.Count > 0) {

                unDo.Push(drawThis[drawThis.Count()-1]);
                drawThis.RemoveAt(drawThis.Count() - 1);

                ClearMap();
                redraw();
            }
        }

        public void Redo() {
            if (unDo.Count > 0)
            {
                drawThis.Add(unDo.Pop());
                ClearMap();
                redraw();
            }
        }

        public List<Shape> getShapes()
        {
            return drawThis;
        }

        public void setShapes(List<Shape> inShapes)
        {
            drawThis = inShapes;
            unDo.Clear();
            redraw();
        }


    }
}
