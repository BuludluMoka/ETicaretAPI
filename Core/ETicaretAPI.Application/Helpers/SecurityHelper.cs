using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Helpers
{
    public class SecurityHelper
    {

        public static string CreateMD5(string input)
        {
            string result = "";
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                result = sb.ToString();
            }
            return result;
        }



        public static string Sha256Hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }



        public static string GetFromBase64(string value)
        {
            var base64Data = "";
            try
            {
                if (string.IsNullOrEmpty(value))
                    return base64Data;




                if (Regex.IsMatch(value, @"^[a-zA-Z0-9\+/]*={0,2}$"))
                {
                    base64Data = Encoding.UTF8.GetString(Convert.FromBase64String(value ?? string.Empty));
                }

                return base64Data;
            }
            catch (Exception)
            {

                return "";
            }
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }





    }
}
