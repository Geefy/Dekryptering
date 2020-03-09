using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekryptering
{
    class Encryption101
    {
        static char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        Queue<char> swapAlphabet = new Queue<char>(alphabet);
        char[,] vigSquare = new char[26, 26];
        public Encryption101()
        {
            MakeVigSquare();
        }

        void MakeVigSquare()
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

        public string Encrypt(string text, string pass)
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

        public string Decrypt(string encryptedText, string pass)
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

                    decryptedText += alphabet[(textIndex + 26) - passIndex];
                }
                else
                {

                    decryptedText += alphabet[textIndex - passIndex];
                }

                passIndexer++;

            }

            return decryptedText;
        }
    }
}
