using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmapReader
{
    class myMap
    {
        private List<Int32> bigWords = new List<Int32>();
        private List<Int16> smallWords = new List<Int16>();
        private string prefix;
        private MyPixelData pixelData;

        public myMap(string pre, List<Int32> big, List<Int16> small) {
            bigWords = big;
            smallWords = small;
            prefix = pre;
        }

        public bool Pixel(int pos)
        {
            return pixelData.Pixel(pos);
        }

        public int PixelAmount()
        {
            return pixelData.PixelAmount();
        }

        public void setPixelData(List<byte> pixels) {
            pixelData = new MyPixelData(pixels,GetWidth(),GetHeight());
        }

        public string GetSignature() => prefix;

        public Int32 GetSizeInBytes() => bigWords[0];
        public Int32 GetSizeInKb() {
            Int32 num = bigWords[0] / 1024;
            return num;
        }
        public Int32 OffsetToImage() => bigWords[1];
        public Int32 SizeOfBitmapinfoheaderStruct() => bigWords[2];
        public Int32 GetWidth() => bigWords[3];
        public Int32 GetHeight() => bigWords[4];
        public string GetCompression() {
            if (bigWords[5] == 0) return "none";
            else if (bigWords[5] == 1) return "RLE-8";
            else if (bigWords[5] == 2) return "RLE-4";
            else return "unknown";
        }
        public Int32 SizeOfImageDataInBytes() => bigWords[6];
        public Int32 HorizontalResInPPM() => bigWords[7];
        public Int32 VerticalResInPPM() => bigWords[8];
        public Int32 GetNumberOfColors() => bigWords[9];
        public Int32 GetNumberOfImpColors() => bigWords[10];

        public Int16 IsNotZero1() => smallWords[0];
        public Int16 IsNotZero2() => smallWords[1];
        public Int16 IsNotOne() => smallWords[2];
        public Int16 GetDepth() => smallWords[3];

        public string usefullInfo() {
            string output;

            output = "Signature: " + prefix + "\n";
            output += "Size: " + GetSizeInKb().ToString()+" kb \n";
            output += "bfSize: " + GetSizeInBytes() + "b \n";
            output += "Width: " + GetWidth().ToString() + "\n";
            output += "Height: " + GetHeight().ToString() + "\n";
            output += "Depth: " + GetDepth().ToString() + " bits\n";
            output += "Compression: " + GetCompression() + "\n";
            output += "horizontal Res in PPM: " + HorizontalResInPPM().ToString() + "\n";
            output += "vertical res in PPM: " + VerticalResInPPM().ToString() + "\n";
            output += "Offset: " + OffsetToImage() + "\n";
            
            

            return output;
        }

    }
}
