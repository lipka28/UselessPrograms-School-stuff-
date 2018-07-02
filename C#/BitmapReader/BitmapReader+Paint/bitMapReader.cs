using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmapReader
{
    class bitMapReader
    {
        public static myMap Read(Stream stream) {

            BinaryReader reader = new BinaryReader(stream);
            
            char first = reader.ReadChar();
            char second = reader.ReadChar();
            string prefix = first.ToString() + second;
            
            myMap map;
            List<Int32> bigwords = new List<Int32>();
            List<Int16> smallwords = new List<Int16>();
            List<byte> pixels = new List<byte>();

            int faser = 0;

            bigwords.Add(reader.ReadInt32());
            for (int i = 0; i < 2; i++) { smallwords.Add(reader.ReadInt16()); faser += 1*2; }
            for(int i = 0; i < 4; i++) {bigwords.Add(reader.ReadInt32()); faser += 1*4; }
            for (int i = 0; i < 2; i++) {smallwords.Add(reader.ReadInt16()); faser += 1*4; }
            for (int i = 0; i < 6; i++) {bigwords.Add(reader.ReadInt32()); faser += 1*4; }

            map = new myMap(prefix, bigwords, smallwords);

            for (int i = faser; i < map.OffsetToImage()-2; i++) {

                byte a = reader.ReadByte();
                faser++;

            }

            for (int i = faser; i < map.GetSizeInBytes()-2; i++) {

                pixels.Add(reader.ReadByte());
                faser++;
            }

            map.setPixelData(pixels);

            return map;

        }
        
    }
}
