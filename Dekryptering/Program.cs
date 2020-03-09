using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekryptering
{
    class Program
    {
        static char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        static Queue<char> swapAlphabet = new Queue<char>(alphabet);
        static char[,] vigSquare = new char[26, 26];
        static string key = "Secretkey";
        static string encryptionText = "HelloMikkel";

        static void Main(string[] args)
        {
            MakeVigSquare();
            Console.WriteLine("Text to encrypt: " + encryptionText +" with key: " + key);
            Console.WriteLine("Text encrypted: " + Encrypt(encryptionText, key));
            Console.WriteLine("Text decrypted: " + Decrypt(Encrypt(encryptionText, key), key));
            Console.Read();


        }
        static void MakeVigSquare()
        {
            for (int i = 0; i < vigSquare.GetLength(0); i++)
            {
                for (int j = 0; j < vigSquare.GetLength(1); j++)
                {
                    char temp = swapAlphabet.ElementAt(j);
                    vigSquare[i, j] = temp;
                }
                swapAlphabet.Enqueue(alphabet[i]);
                swapAlphabet.Dequeue();
            }
        }

        static string Encrypt(string text, string pass)
        {
            char[] textArr = text.ToCharArray();
            char[] passArr = pass.ToCharArray();
            int passIndexer = 0;
            string encryptedText = "";
            for (int i = 0; i < textArr.Length; i++)
            {

                if (passIndexer >= passArr.Length)
                {
                    passIndexer = 0;
                }
                char textChar = textArr[i];
                char passChar = passArr[passIndexer];
                int passIndex = (int)passChar % 32;
                int textIndex = (int)textChar % 32;
                encryptedText += vigSquare[passIndex - 1, textIndex - 1];
                passIndexer++;

            }

            return encryptedText;
        }

        static string Decrypt(string encryptedText, string pass)
        {
            char[] textArr = encryptedText.ToCharArray();
            char[] passArr = pass.ToCharArray();
            int passIndexer = 0;
            string decryptedText = "";
            for (int i = 0; i < textArr.Length; i++)
            {

                if (passIndexer >= passArr.Length)
                {
                    passIndexer = 0;
                }
                char textChar = textArr[i];
                char passChar = passArr[passIndexer];
                int passIndex = (int)passChar % 32;
                int textIndex = (int)textChar % 32;
                if (textIndex - passIndex < 0)
                {

                    decryptedText += vigSquare[0, (textIndex + 26) - passIndex];
                }
                else
                {

                    decryptedText += vigSquare[0, textIndex - passIndex];
                }

                passIndexer++;

            }

            return decryptedText;
        }
    }
}
