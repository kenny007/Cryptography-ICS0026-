using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VisualCryptoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string sKey = EncryptionHelper.GenerateKey();
            string output = "Decryption successful";
            string hashValue = "Hashed Image";
            Console.WriteLine($"Please enter the filepath: ");

            //EncryptionHelper.EncryptFile("F:\\Spring Semester\\Cryptography\\images\\30.jpg", Guid.NewGuid().ToString(),sKey, out output);


            Console.WriteLine(BitConverter.ToString(EncryptionHelper.EncryptFile("F:\\Spring Semester\\Cryptography\\images\\30.jpg", Guid.NewGuid().ToString(), sKey, out output)));
            Console.ReadKey();
        }
    }
}
