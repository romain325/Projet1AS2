using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

namespace prjtS2.FunctLibrary.Tools.Crypto
{
    /// <summary>
    /// Classic Cipher Encryption /!\ Not Trustable /!\ Used for presentation, not intended to be used in a deployement
    /// Don't Ever trust this code, it has been made only to "look like" real encryption
    /// Not Unbreakable at all
    /// </summary>
    public static class Encrypt
    {
        /// <summary>
        /// transforamtion vector
        /// </summary>
        private const string initVector = "pemgail9uzpgzl88";

        /// <summary>
        /// Size of Key Used
        /// </summary>
        private const int keysize = 256;
        
        /// <summary>
        /// Encryption of a string
        /// </summary>
        /// <param name="plainText">The Password</param>
        /// <param name="passPhrase"> Pass Phrase Used </param>
        /// <returns>Cypherised Password</returns>
        public static string EncryptString(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            };

            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] cipherTextBytes = memoryStream.ToArray();
            
            memoryStream.Close();
            cryptoStream.Close();
            
            
            return Convert.ToBase64String(cipherTextBytes);
        }
        

        /// <summary>
        /// Decryption of a String
        /// </summary>
        /// <param name="cipherText"> Encrypted Password </param>
        /// <param name="passPhrase"> PassPhraseUsed </param>
        /// <returns>DeCypherised Password</returns>
        public static string DecryptString(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            };

            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        /// <summary>
        /// Check if the Phrase is Base64 in way to fit Encoding
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>Is String Base64 or not</returns>
        public static bool IsBase64String(string s)
        {
            return  Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }
    }
}
