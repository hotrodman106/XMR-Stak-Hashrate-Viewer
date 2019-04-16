using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace XMR_Stak_Hashrate_Viewer
{
    class CryptographyEngine
    {
        private const string initVector = "pemgail9uzpgzl88";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;
        private const string passPhrase = "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";
        //Encrypt
        public static string EncryptString(string plainText)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
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
        //Decrypt
        public static string DecryptString(string cipherText)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}
