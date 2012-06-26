using System;
using System.Security.Cryptography;
using System.Text;

namespace MetiShared
{
    public class Hash
    {
        public enum HashType : int
        {
            MD5,
            SHA1,
            SHA256,
            SHA512
        }

        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="hashType">Type of the hash.</param>
        /// <returns></returns>
        public static string GetHash(string text, HashType hashType)
        {
            string hashString;
            switch (hashType)
            {
                case HashType.MD5:
                    hashString = GetMD5(text);
                    break;
                case HashType.SHA1:
                    hashString = GetSHA1(text);
                    break;
                case HashType.SHA256:
                    hashString = GetSHA256(text);
                    break;
                case HashType.SHA512:
                    hashString = GetSHA512(text);
                    break;
                default:
                    hashString = "Invalid Hash Type";
                    break;
            }
            return hashString;
        }

        /// <summary>
        /// Checks the hash.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="hashString">The hash string.</param>
        /// <param name="hashType">Type of the hash.</param>
        /// <returns></returns>
        public static bool CheckHash(string original, string hashString, HashType hashType)
        {
            string originalHash = GetHash(original, hashType);
            return (originalHash == hashString);
        }

        /// <summary>
        /// Gets the Md5 hash.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private static string GetMD5(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            MD5 hashString = new MD5CryptoServiceProvider();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        /// <summary>
        /// Gets the SHA1 hash.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private static string GetSHA1(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            SHA1Managed hashString = new SHA1Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        private static string GetSHA256(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        private static string GetSHA512(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            SHA512Managed hashString = new SHA512Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}
