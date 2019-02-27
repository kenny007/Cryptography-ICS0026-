using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            VCipher v = new VCipher();

            string s0 = "Happiness is not a destination, it is a journey!",
                pw = "ABSYSTEMCIPHER";

            Console.WriteLine(s0 + "\n" + pw + "\n");
            string s1 = v.encrypt(s0, pw, 1);
            Console.WriteLine("Encrypted: " + s1);
            s1 = v.encrypt(s1, "ABSYSTEMCIPHER", -1);
            Console.WriteLine("Decrypted: " + s1);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
