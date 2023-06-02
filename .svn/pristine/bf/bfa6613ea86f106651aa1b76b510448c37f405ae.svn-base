using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Connection
    {
        private static string _DBKMConnectionString;
        public static string DBKMConnectionString
        {
            get { return _DBKMConnectionString; }
            set { _DBKMConnectionString = value; }
        }
        private static string _Provider;
        public static string Provider
        {
            get { return _Provider; }
            set { _Provider = value; }
        }

        private static string SecurityKey
        {
            get { return "DERP"; }
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            if (cipherString == "")
            {
                return "";
            }
            byte[] keyArray = null;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = SecurityKey;


            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //keyArray = hashmd5.ComputeHash(UTF32Encoding.UTF32.GetBytes(key))
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
                //keyArray = UTF32Encoding.UTF32.GetBytes(key)
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return (UTF8Encoding.UTF8.GetString(resultArray));
            //Return (UTF32Encoding.UTF32.GetString(resultArray))
        }
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            if (toEncrypt == "")
            {
                return "";
            }
            byte[] keyArray = null;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            // Dim toEncryptArray As Byte() = UTF32Encoding.UTF32.GetBytes(toEncrypt)

            string key = SecurityKey;
            //key = "AdeF5ty6Fr456Mw###"
            //System.Windows.Forms.MessageBox.Show(key)
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //keyArray = hashmd5.ComputeHash(UTF32Encoding.UTF32.GetBytes(key))
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
                //keyArray = UTF32Encoding.UTF32.GetBytes(key)
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return (Convert.ToBase64String(resultArray, 0, resultArray.Length));
        }
        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
