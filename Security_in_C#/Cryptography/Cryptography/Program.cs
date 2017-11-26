using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            string hashme = "I am a novice aiming to be an expert";
            string hashme2 = "a new statement that need inspection";
            SHA1 sha1 = SHA1.Create();
            byte[] hashmeHashed = sha1.ComputeHash(Encoding.UTF8.GetBytes(hashme));
            string result = BitConverter.ToString(hashmeHashed).Replace("-", " ");
            Console.WriteLine("SHA1: " + result);

            SHA256 sha256 = SHA256.Create();
            hashmeHashed = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashme));
            result = BitConverter.ToString(hashmeHashed).Replace("-", " ");
            Console.WriteLine("SHA256: " + result);

            using (SHA512 sha512 = SHA512.Create())
            {

                hashmeHashed = sha512.ComputeHash(Encoding.UTF8.GetBytes(hashme));
                result = BitConverter.ToString(hashmeHashed).Replace("-", " ");
                Console.WriteLine("SHA512: " + result);
            }
            using (var md5 = MD5.Create())
            {
                byte[] hashmeHashed1 = md5.ComputeHash(Encoding.UTF8.GetBytes(hashme));
                string result1 = BitConverter.ToString(hashmeHashed1).Replace("-", " ");
                Console.WriteLine("Original" + hashme);
                Console.WriteLine("Hash" + result1);
            }
            using (var md5 = MD5.Create()) // by the use of "using" the md5 resource got free
            {
                byte[] hashmeHashed2 = md5.ComputeHash(Encoding.UTF8.GetBytes(hashme2));
                string result2 = BitConverter.ToString(hashmeHashed2).Replace("-", " ");
                Console.WriteLine("Original" + hashme2);
                Console.WriteLine("Hash" + result2);
            }

            Console.ReadLine();
        }
    }
}
