using BusinessAccessLayer.UnitOfBusinessLogicNameSpace;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.BussinessLayer
{
    public class CryptoGraphy
    {
        private const string initVector = "pakistanstanpaki";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 128;
        private UnitOfBusinessLogic unitOfBusinessLogic;
        private UnitOfWork unitOfWork;


        public CryptoGraphy(UnitOfBusinessLogic unitOfBusinessLogic)
        {
            this.unitOfBusinessLogic = unitOfBusinessLogic;
            unitOfWork = unitOfBusinessLogic.unitOfWork;
        }
        public string Encrypt(string plainText, string key)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(key, null);
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
            return key + Convert.ToBase64String(cipherTextBytes);
        }





        public string Decrypt(string cipherText, int keyLength = 3)
        {
            try
            {
                string passPhrase = cipherText.Substring(0, keyLength);
                cipherText = cipherText.Remove(0, keyLength);

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
            catch (Exception)
            {

                return null;
            }
        }
    }
}