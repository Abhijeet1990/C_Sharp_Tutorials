using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography2
{
    class Program
    {
        public enum Mode
        {
            Encrypt,
            Decrypt
        };


        static void Main(string[] args)
        {
            //string message = "I am the only warrior left to fight against austria";
            string message = "The quick brown fox jumps over the lazy dog";
            
            var random = new Random();
            byte[] IV = new byte[8];
            //initialize a Intitiation Vector
            random.NextBytes(IV);
            //the key is 8 byte long in DES
            byte[] key = new byte[8];
            random.NextBytes(key);
            byte[] encrypted = DESCrypto(Mode.Encrypt, IV, key, Encoding.UTF8.GetBytes(message));
            Console.WriteLine("Encrypted Text: " + BitConverter.ToString(encrypted).Replace("-", ""));
            byte[] decrypted = DESCrypto(Mode.Decrypt, IV, key, encrypted);
            Console.WriteLine("decrypted text: " + Encoding.UTF8.GetString(decrypted));

            //the key is 24 byte long in Triple DES
            byte[] key3 = new byte[24];
            random.NextBytes(key3);
            byte[] encrypted3 = TripleDESCrypto(Mode.Encrypt, IV, key3, Encoding.UTF8.GetBytes(message));
            Console.WriteLine("Encrypted Text: " + BitConverter.ToString(encrypted3).Replace("-", ""));
            byte[] decrypted3 = TripleDESCrypto(Mode.Decrypt, IV, key3, encrypted3);
            Console.WriteLine("decrypted text: " + Encoding.UTF8.GetString(decrypted3));
            

            
            //AES Encryption
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.GenerateKey();
                aes.GenerateIV();

                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                byte[] encryptedA = AESCrypto(Mode.Encrypt, aes, Encoding.UTF8.GetBytes(message));
                Console.WriteLine("Encrypted Text: " + BitConverter.ToString(encryptedA).Replace("-", ""));
                byte[] decryptedA = AESCrypto(Mode.Decrypt, aes, Encoding.UTF8.GetBytes(message));
                Console.WriteLine("Decrypted Text: " + BitConverter.ToString(decryptedA).Replace("-", ""));
                Console.ReadLine();
            }
        }
        
        //DES encryption and decryption
        static byte[] DESCrypto(Mode mode, byte[] IV, byte[] key, byte[] message)
        {
            using (var DES = new DESCryptoServiceProvider())
            {
                DES.IV = IV;
                DES.Key = key;
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;

                using (var memStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = null;

                    if(mode == Mode.Encrypt)
                    {
                        cryptoStream = new CryptoStream(memStream, DES.CreateEncryptor(), CryptoStreamMode.Write);
                    }
                    else if(mode == Mode.Decrypt)
                    {
                        cryptoStream = new CryptoStream(memStream, DES.CreateDecryptor(), CryptoStreamMode.Write);
                    }
                    if (cryptoStream == null)
                        return null;


                    cryptoStream.Write(message, 0, message.Length);
                    cryptoStream.FlushFinalBlock();
                    return memStream.ToArray();

                }

            }
            return null;
        }

        //Triple DES encryption and decryption
        static byte[] TripleDESCrypto(Mode mode, byte[] IV, byte[] key, byte[] message)
        {
            using (var TripleDES = new TripleDESCryptoServiceProvider())
            {
                TripleDES.IV = IV;
                TripleDES.Key = key;
                TripleDES.Mode = CipherMode.CBC;
                TripleDES.Padding = PaddingMode.PKCS7;

                using (var memStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = null;

                    if (mode == Mode.Encrypt)
                    {
                        cryptoStream = new CryptoStream(memStream, TripleDES.CreateEncryptor(), CryptoStreamMode.Write);
                    }
                    else if (mode == Mode.Decrypt)
                    {
                        cryptoStream = new CryptoStream(memStream, TripleDES.CreateDecryptor(), CryptoStreamMode.Write);
                    }
                    if (cryptoStream == null)
                        return null;


                    cryptoStream.Write(message, 0, message.Length);
                    cryptoStream.FlushFinalBlock();
                    return memStream.ToArray();

                }

            }
            return null;
        }

        static byte[] AESCrypto(Mode mode, AesCryptoServiceProvider aes, byte[] message)
        {
            using (var memStream = new MemoryStream())
            {
                CryptoStream cryptoStream = null;

                if (mode == Mode.Encrypt)
                {
                    cryptoStream = new CryptoStream(memStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                }
                else if (mode == Mode.Decrypt)
                {
                    cryptoStream = new CryptoStream(memStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
                }
                if (cryptoStream == null)
                    return null;


                cryptoStream.Write(message, 0, message.Length);
                cryptoStream.FlushFinalBlock();
                return memStream.ToArray();

            }
        }
        static byte[] Decrypt(byte[] IV, byte[] key, byte[] message)
        {
            return null;
        }
    }
}
