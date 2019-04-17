using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = new[] {"Fox", "Quick Brown Fox Jumped the fence","The red fox jumped over the blue fox","The red fox jumped ouer the blue fox"};

            Console.WriteLine($"MD5 of different words { Hasher.Md5(text[0])}");
            Console.WriteLine($"MD5 of different words { Hasher.Md5(text[1])}");
            Console.WriteLine($"MD5 of different words { Hasher.Md5(text[2])}");
            Console.WriteLine($"MD5 of different words { Hasher.Md5(text[3])}");

            Console.WriteLine($" --------------------------------------------------- ");

            Console.WriteLine($"SHA1 of different words { Hasher.SHA1(text[0])}");
            Console.WriteLine($"SHA1 of different words { Hasher.SHA1(text[1])}");
            Console.WriteLine($"SHA1 of different words { Hasher.SHA1(text[2])}");
            Console.WriteLine($"SHA1 of different words { Hasher.SHA1(text[3])}");

            Console.WriteLine($" --------------------------------------------------- ");

            Console.WriteLine($"SHA256 of different words { Hasher.SHA256(text[0])}");
            Console.WriteLine($"SHA256 of different words { Hasher.SHA256(text[1])}");
            Console.WriteLine($"SHA256 of different words { Hasher.SHA256(text[2])}");
            Console.WriteLine($"SHA256 of different words { Hasher.SHA256(text[3])}");

            Console.WriteLine($" --------------------------------------------------- ");

            Console.WriteLine($"SHA512 of different words { Hasher.SHA512(text[0])}");
            Console.WriteLine($"SHA512 of different words { Hasher.SHA512(text[1])}");
            Console.WriteLine($"SHA512 of different words { Hasher.SHA512(text[2])}");
            Console.WriteLine($"SHA512 of different words { Hasher.SHA512(text[3])}");


            Console.ReadKey();
            //var algorithms = new Dictionary<string, Func<string, string>>
            //{
            //    {nameof(Hasher.Md5).ToLower(), Hasher.Md5},

            //    {nameof(Hasher.SHA1).ToLower(), Hasher.SHA1},
            //    {nameof(Hasher.SHA256).ToLower(), Hasher.SHA256},
            //    {nameof(Hasher.SHA384).ToLower(), Hasher.SHA384},
            //    {nameof(Hasher.SHA512).ToLower(), Hasher.SHA512},
            //};

            //if (args.Length < 2)
            //{
            //    Console.WriteLine("You need 2 arguments.");
            //    return;
            //}

            //if (args.Length > 2)
            //{
            //    Console.WriteLine("Too many arguments.");
            //    return;
            //}

            //var algo = args[0].ToLower();
            //var text = args[1];

            //if (!algorithms.ContainsKey(algo))
            //{
            //    Console.WriteLine($"Algorithm {algo} is unknown.");
            //    return;
            //}

            //var result = algorithms[algo].Invoke(text);

            //Console.WriteLine(result);
        }
    }
}
