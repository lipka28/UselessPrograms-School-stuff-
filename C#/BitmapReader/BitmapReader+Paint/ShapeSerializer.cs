using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BitmapReader
{
    public class ShapeSerializer
    {
        public static void ShapesSerialize(Stream stream, List<Shape> shapes)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, shapes);
        }

        public static List<Shape> ShapesDeserialize(Stream stream)
        {
            var formatter = new BinaryFormatter();
            List<Shape> shapes = (List<Shape>)formatter.Deserialize(stream);

            return shapes;

        }

        public static void ShapesZipSer(Stream stream, List<Shape> shapes)
        {
            GZipStream zipStream = new GZipStream(stream, CompressionMode.Compress);
            ShapesSerialize(zipStream, shapes);
            zipStream.Close();

        }

        public static List<Shape> ShapesZipDes(Stream stream)
        {
            GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress);
            List<Shape> tvary = ShapesDeserialize(zipStream);
            zipStream.Close();
            return tvary;

        }

        public static void ShapesEncryptSer(Stream stream, List<Shape> shapes, String heslo)
        {
            DESCryptoServiceProvider crypt = new DESCryptoServiceProvider();
            crypt.Key = ASCIIEncoding.ASCII.GetBytes(heslo);
            crypt.IV = ASCIIEncoding.ASCII.GetBytes(heslo);
            CryptoStream cryptStream = new CryptoStream(stream, crypt.CreateEncryptor(), CryptoStreamMode.Write);
            ShapesSerialize(cryptStream, shapes);
            cryptStream.Close();

        }

        public static List<Shape> ShapesEncryptDes(Stream stream, String heslo)
        {
            DESCryptoServiceProvider crypt = new DESCryptoServiceProvider();
            crypt.Key = ASCIIEncoding.ASCII.GetBytes(heslo);
            crypt.IV = ASCIIEncoding.ASCII.GetBytes(heslo);
            CryptoStream cryptStream = new CryptoStream(stream, crypt.CreateDecryptor(), CryptoStreamMode.Read);
            List<Shape> tvary = ShapesDeserialize(cryptStream);
            cryptStream.Close();
            return tvary;
        }

        public static void ShapesEncryptZipSer(Stream stream, List<Shape> shapes, String heslo)
        {
            DESCryptoServiceProvider crypt = new DESCryptoServiceProvider();
            crypt.Key = ASCIIEncoding.ASCII.GetBytes(heslo);
            crypt.IV = ASCIIEncoding.ASCII.GetBytes(heslo);
            CryptoStream cryptStream = new CryptoStream(stream, crypt.CreateEncryptor(), CryptoStreamMode.Write);
            ShapesZipSer(cryptStream, shapes);
            cryptStream.Close();

        }

        public static List<Shape> ShapesEncryptZipDes(Stream stream, String heslo)
        {
            DESCryptoServiceProvider crypt = new DESCryptoServiceProvider();
            crypt.Key = ASCIIEncoding.ASCII.GetBytes(heslo);
            crypt.IV = ASCIIEncoding.ASCII.GetBytes(heslo);
            CryptoStream cryptStream = new CryptoStream(stream, crypt.CreateDecryptor(), CryptoStreamMode.Read);
            List<Shape> tvary = ShapesZipDes(cryptStream);
            cryptStream.Close();
            return tvary;
        }

        public static void ShapesXMLSer(Stream stream, List<Shape> shapes)
        {
            System.Xml.Serialization.XmlSerializer XmlSer = new System.Xml.Serialization.XmlSerializer(shapes.GetType());
            XmlSer.Serialize(stream, shapes);
        }

        public static List<Shape> ShapesXMLDes(Stream stream)
        {
            List<Shape> tvary = new List<Shape>();
            System.Xml.Serialization.XmlSerializer XmlSer = new System.Xml.Serialization.XmlSerializer(tvary.GetType());
            tvary = (List<Shape>)XmlSer.Deserialize(stream);
            return tvary;
        }

        public static void ShapesSOAPSer(Stream stream, List<Shape> shapes)
        {
            XmlTypeMapping myType = new SoapReflectionImporter().ImportTypeMapping(shapes.GetType()); // priliz stare na to aby to bylo pouzitelne
            System.Xml.Serialization.XmlSerializer XmlSer = new System.Xml.Serialization.XmlSerializer(myType);
            XmlSer.Serialize(stream, shapes);
        }

        //only for testing

        public static void ShapeSerialize(Stream stream, Shape shape)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, shape);
        }

        public static Shape ShapeDeserialize(Stream stream)
        {
            var formatter = new BinaryFormatter();
            Shape shape = (Shape)formatter.Deserialize(stream);

            return shape;

        }
    }
}
