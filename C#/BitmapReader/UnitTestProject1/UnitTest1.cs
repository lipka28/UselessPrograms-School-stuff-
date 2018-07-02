using BitmapReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Shape tvar1 = new Shape(1,3,2,5,1,Color.Blue);


            var binSerializer = new BinaryFormatter();
            Stream stream = File.OpenWrite("test.bin");
            ShapeSerializer.ShapeSerialize(stream, tvar1);
            stream.Close();

            stream = File.OpenRead("test.bin");
            Assert.AreEqual(tvar1, ShapeSerializer.ShapeDeserialize(stream));
            stream.Close();

            
           
        }
    }
}
