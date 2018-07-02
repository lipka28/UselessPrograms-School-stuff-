using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmapReader
{
    class MyPixelData
    {
        private int width;
        private int height;
        private byte[] pixels;
        private BitArray pixdata;
        private bool tmp;

        public MyPixelData(List<byte> pixels, int width, int height)
        {
            this.width = width;
            this.height = height;
            this.pixels = pixels.ToArray();

            pixdata = new BitArray(this.pixels);

            for (int i = 0; i < pixdata.Length; i += 8)
            {
                tmp = pixdata.Get(i);
                pixdata.Set(i, pixdata.Get(i+7));
                pixdata.Set(i + 7, tmp);
                
                tmp = pixdata.Get(i+1);
                pixdata.Set(i+1, pixdata.Get(i + 6));
                pixdata.Set(i + 6, tmp);
                
                tmp = pixdata.Get(i+2);
                pixdata.Set(i+2, pixdata.Get(i + 5));
                pixdata.Set(i + 5, tmp);

                tmp = pixdata.Get(i + 4);
                pixdata.Set(i + 4, pixdata.Get(i + 3));
                pixdata.Set(i + 3, tmp);
                


            }


        }

        public int PixelAmount()
        {
            return pixdata.Length;
        }

        public bool Pixel(int position)
        {
            return pixdata.Get(position);
        }

    }
}
