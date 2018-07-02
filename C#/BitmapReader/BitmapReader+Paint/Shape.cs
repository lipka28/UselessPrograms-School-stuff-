using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmapReader
{
    [Serializable]
    public struct Shape
    {
       private int x1;
       private int x2;
       private int y1;
       private int y2;
       private int kind;
       private Color color;

       public Shape(int x1, int y1,int x2,int y2,int shape,Color color) {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
            kind = shape;
            this.color = color;

        }

       public int X1 { get => x1; set => x1 = value; }
       public int X2 { get => x2; set => x2 = value; }
       public int Y1 { get => y1; set => y1 = value; }
       public int Y2 { get => y2; set => y2 = value; }
       public Color Color { get => color; set => color = value; }
       public int Kind { get => kind; set => kind = value; }
    }
}
