using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Dekryptering
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {

            Stopwatch watch = new Stopwatch();
            watch.Start();
            string key = "Secretkey";
            string encryptionText = "HelloMikkel";

            Encryption101 vigEncrypter = new Encryption101();


            string temp = vigEncrypter.Encrypt(encryptionText, key);
            Console.WriteLine(temp);


            string reTemp = vigEncrypter.Decrypt(temp, key);
            Console.WriteLine(reTemp);

                watch.Stop();
                Console.WriteLine(watch.Elapsed.TotalMilliseconds);
            Console.ReadKey();
            }


        }


    }
}
