using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Please enter a word to encrypt");
            // Converting text to bytes, assuming unicode.
            string enteredText = Console.ReadLine();
            Console.WriteLine($"The message sent is {enteredText}");
            byte[] originalBytes = Encoding.Unicode.GetBytes("HELLO");

            // generate a pad in memory.
            byte[] pad = GeneratePad(size: originalBytes.Length, seed: 1);

            // I'm going to display these bytes in Base64, but one would
            // probably save them to a file; this is the Pad (or "key").
            string textPad = Convert.ToBase64String(inArray: pad);
            Console.WriteLine($"The pad used for encryption {textPad}");

            // We encrypt the bytes by adding our noise.
            byte[] encrypted = Encrypt(originalBytes, pad);

            // again, displaying in base64, but I would typically save
            // these to a file too; this is your encrypted "file" or message.
            string textEncrypted = Convert.ToBase64String(inArray: encrypted);
            
            //Console.WriteLine($"{textEncrypted}");

            byte[] encryptedFromBase64 = Convert.FromBase64String(textEncrypted);

            // decrypting the encoded message using the key made up of noise.
            byte[] decrypted = Decrypt(encryptedFromBase64, pad);

            // displaying the original unencrypted message.
          
            string decryptedText = Encoding.Unicode.GetString(decrypted);
            Console.WriteLine($"The decrypted message is {decryptedText}");
            Console.ReadKey();

        }

        //This is the code being used as the pad
        public static byte[] GeneratePad(int size, int seed)
        {
            var random = new Random(Seed: seed);
            var bytesBuffel = new byte[size];

            random.NextBytes(bytesBuffel);

            return bytesBuffel;
        }

        public static byte[] Encrypt(byte[] data, byte[] pad)
        {
            var result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                var sum = (int)data[i] + (int)pad[i];
                if (sum > 255)
                    sum -= 255;
                result[i] = (byte)sum;
            }
            return result;
        }

        public static byte[] Decrypt(byte[] encrypted, byte[] pad)
        {
            var result = new byte[encrypted.Length];
            for (int i = 0; i < encrypted.Length; i++)
            {
                var dif = (int)encrypted[i] - (int)pad[i];
                if (dif < 0)
                    dif += 255;
                result[i] = (byte)dif;
            }
            return result;
        }
    }
}
