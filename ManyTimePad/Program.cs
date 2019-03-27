using System;
using System.Linq;

namespace ManyTimePad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] msg = new string[11];
            char msgChar, keyLetter;
            //We can safely truncate all ciphertexts to the length of the target message.
            for (int pos = 0; pos < (int)(StreamCipher.cipherText[10].Length / 2); pos++) //Then decrypt letter by letter.
            {
                keyLetter = StreamCipher.GetKeyLetter(pos); //Get a letter of the key
                for (int ctNumber = 0; ctNumber < 11; ctNumber++)
                {
                    if (keyLetter == '|') //If the key was not found
                    {
                        msg[ctNumber] = "_"; //Replace that character with a '_'
                        continue;
                    } //If we found a key
                    msgChar = (char)(StreamCipher.GetCtChar(ctNumber, pos) ^ keyLetter); //decrypt
                    msg[ctNumber] = msgChar.ToString(); //and reconstruct the original message.
                }
            }
            for (int i = 0; i < 11; i++)
            {
              Console.WriteLine($"Your message is {msg[i]}"); //Although some characters will be replaced with '_', we can easily get original messages from semantics.
            }

            Console.ReadKey();
        }
    }
}
