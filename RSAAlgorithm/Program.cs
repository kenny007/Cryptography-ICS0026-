using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello RSA Brute Force!");
            Console.WriteLine("Please enter your n value: ");

            int n = Convert.ToInt32(Console.ReadLine());
            int item1 = KeyComponents(n).Item1;
            int item2 = KeyComponents(n).Item2;
            Console.WriteLine($"P is: {item1}");
            Console.WriteLine($"Q is: {item2}");
            int m = (item1 - 1) * (item2 - 1);

            Console.WriteLine($"The value of m is {m}");

            int e = Coprime(m); //This is the co-prime of M
            var dCalc = de_mod_m(m, e);
            Console.WriteLine($"The Coprime of m is {Coprime(e)}");
            int privateKey = CalcPrivateKey(e, m);
            Console.WriteLine($"The private key is {privateKey}");

            var cipher = ModPowUtil(529, e, n);

            Console.WriteLine($"Cipher text: {cipher}");

            var message = ModPowUtil(cipher, dCalc, n);
            Console.WriteLine($"The original message sent: {message}");

            //int encryptedMessage = encryptRSA(6, privateKey, e);

            //Console.WriteLine($"The encrypted message is : { encryptedMessage }");

            //Console.WriteLine($"The decrypted message is : {decryptRSA(encryptedMessage,privateKey,e)}");

            Console.ReadKey();
          
        }

        /// <summary>
        /// encrypt wrapper to ModPowUtil
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        static int Encrypt(int message, int e, int publicKey)
        {
            return ModPowUtil(message, e, publicKey);
        }
        /// <summary>
        /// decrypt wrapper for ModPowUtil
        /// </summary>
        /// <param name="cipher"></param>
        /// <param name="dVal"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        static int Decrypt(int cipher, int dVal, int publicKey)
        {
            return ModPowUtil(cipher, dVal, publicKey);
        }

        //calculates private key
        static int CalcPrivateKey(int e, int m)
        {
            int k = 0;
            while (true)
            {
                int d = (1 + k * (m)) % (e);
                if (d == 0)
                {
                    return (1 + k * (m)) / (e);
                }
                k++;
            }
        }

        //this returns the value of e
        static int Coprime(int m)
        {
            int e = 2;
            while (GCD(m, e) != 1)
            {
                e++;
            }

            return e;
        }

        static int GCD(int a, int b)
        {
            while (true)
            {
                if (a < b)
                {
                    int tempa = a;
                    a = b;
                    b = tempa;
                }

                int remainder = a % b;

                if (remainder == 0) return b;
                a = b;
                b = remainder;
            }
        }

        static Tuple<int, int> KeyComponents(int n)
        {
            int prime1=0, prime2=0;
            int indexTracker = 0;
            int divider = primeNoList().Length / 2;
            int halfWay = primeNoList()[divider];
            indexTracker = n < halfWay ? divider : primeNoList().Length - 1;
                 
            for (int i=0;i <= indexTracker; i++)
            {
                for (int j=0; j <= indexTracker; j++)
                {
                    if (n == primeNoList()[i] * primeNoList()[j])
                    {
                        prime1 = primeNoList()[i];
                        prime2 = primeNoList()[j];
                        goto End;
                    }
                }
            }
            End:
            return Tuple.Create(prime1, prime2);
        }

        static int[] primeNoList()
        {
            int[] primeList = {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97,101,103,107,109,113,127,131,137,139,149,151,157,163,167,173,179,
                181,191,193,197,199,211,223,227,229,233,239,241,251,257,263,269,271,277,281,283,293,307,311,313,317,331,337,347,349,353,359,367,373,379,383,389,
                397,401,409,419,421,431,433,439,443,449,457,461,463,467,479,487,491,499,503,509,521,523,541,547,557,563,569,571,577,587,593,599,601,607,613,617,
                619,631,641,643,647,653,659,661,673,677,683,691,701,709,719,727,733,739,743,751,757,761,769,773,787,797,809,811,821,823,827,829,839,853,857,859,
                863,877,881,883,887,907,911,919,929,937,941,947,953,967,971,977,983,991,997,1009,1013,1019,1021,1031,1033,1039,1049,1051,1061,1063,1069,1087,1091,
                1093,1097,1103,1109,1117,1123,1129,1151,1153,1163,1171,1181,1187,1193,1201,3127};
            return primeList;
        }
        
        static int ModPowUtil(int pKeyBase, int pow, int p)
        {
            int remainder = 0;
            int multiplier = 1;
         
            for (int i = pow-1; i >= 0;i--)
            {
                if (i == pow - 1)
                {
                    multiplier = multiplier * pKeyBase;
                }
            
                if (multiplier > p)
                {
                    remainder = multiplier % p;
                    multiplier = 1;
                    continue;
                }

                if (multiplier < p && i != pow - 1)
                {
                    multiplier = multiplier * pKeyBase;
                    if (multiplier > p)
                    {
                        remainder = multiplier % p;
                        multiplier = 1;
                    }
                }
                
                if(remainder != 0)
                {
                    multiplier = remainder * multiplier;
                    remainder = 1;
                }
            }

            return multiplier;
        }
        //Find d, such that (de mod f(n)=1), divisor without remainder
        static int de_mod_m(int m, int e)
        {
            int k = 0;
            while (true)
            {
                var t = (1 + k * m);
                if (t % e == 0)
                {
                    return t / e;
                }

                k++;
            }
        }
     
    }

}
