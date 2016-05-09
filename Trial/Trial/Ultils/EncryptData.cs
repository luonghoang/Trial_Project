using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Trial.Ultils
{
    public class EncryptData
    {
        public static string Encryption(string pass)
        {
            MD5 md5hash = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            byte[] hashBytes;
            hashBytes = md5hash.ComputeHash(encoder.GetBytes(pass));
            return BitConverter.ToString(hashBytes);
        }
    }
}