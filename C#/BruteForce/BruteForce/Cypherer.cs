using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BruteForce
{
    class Cypherer
    {
        private byte[] key = new byte[8];
        public Cypherer(String password)
        {
            MD5CryptoServiceProvider hashMD5provider = new MD5CryptoServiceProvider();
            var fullHash = hashMD5provider.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));
            Array.Copy(fullHash, key, 8);

        }

        public void letsEncrypt(Stream stream, String text)
        {
            DESCryptoServiceProvider crypt = new DESCryptoServiceProvider();
            crypt.Key = key;
            crypt.IV = key;
            CryptoStream cryptStream = new CryptoStream(stream, crypt.CreateEncryptor(), CryptoStreamMode.Write);
            serialize(cryptStream, text);
            cryptStream.Close();

        }

        public String letsDecrypt(Stream stream)
        {
            DESCryptoServiceProvider Decrypt = new DESCryptoServiceProvider();
            Decrypt.Padding = PaddingMode.None;
            Decrypt.Key = key;
            Decrypt.IV = key;
            CryptoStream DecryptStream = new CryptoStream(stream, Decrypt.CreateDecryptor(), CryptoStreamMode.Read);
            String output = deserialize(DecryptStream);
            DecryptStream.Close();
            return output;

        }

        public void serialize(Stream stream, String text)
        {
            var formater = new BinaryFormatter();
            formater.Serialize(stream, text);

        }

        public String deserialize(Stream stream)
        {
            var formater = new BinaryFormatter();
            String output = "-1";
            try
            {
                output = (String)formater.Deserialize(stream);
            }
            catch
            {
                return output;
            }
            
                return output;
            
        }
    }
}
