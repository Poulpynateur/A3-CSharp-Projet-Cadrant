using System;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Linq;

namespace CryptoSoft
{
    class Program
    {
        /// <summary>
        /// Takes some arguments to either encrypt or decrypt a file to another with a given key (with 8 characters)
        /// </summary>
        /// <param name="args">A list of arguments : [encrypt/decrypt] [key] [sourcePath] [targetPath]</param>
        /// <returns>A integer code meaning either it succeed, either it fails or if there hasn't even been an encrypting/decrypting work</returns>
        static int Main(string[] args)
        {
           //Instanciate the stopwatch
           Stopwatch chrono = new Stopwatch();

            //Remove the white-spaces characters at the start and at the end of all argument
            Array.ForEach(args, x => x.Trim());

            //Set the key for the cryptographic work
            Crypto crypt = new Crypto(args[1]);
            try
            {
                //Start of the stopwatch
                chrono.Start();
                
                //If the first argument is encrypt then it will start the encrypting function and the stopwatch will stop at the end of it
                if (args[0].Equals("encrypt"))
                {
                    crypt.EncryptFile(args[2], args[3]);
                    chrono.Stop();

                    // Displays and returns the time in ms elapsed by the stopwatch
                    int time = Convert.ToInt32(chrono.Elapsed.TotalMilliseconds);
                    Console.WriteLine("Encrypting time :" + time);
                    return time;
                }
                //If the first argument is decrypt then it will start the encrypting function and the stopwatch will stop at the end of it
                else if (args[0].Equals("decrypt"))
                {
                    crypt.DecryptFile(args[2], args[3]);
                    chrono.Stop();

                    // Displays and returns the time in ms elapsed by the stopwatch
                    int time = Convert.ToInt32(chrono.Elapsed.TotalMilliseconds);
                    Console.WriteLine("Decrypting time :" + time);
                    return time;
                }
                //If the first argument isn't any of them it means an error of input and there isn't any encrypting so returns 0
                else
                {
                    Console.WriteLine("Error Input");
                    return 0;
                } 
            }
            //If an exception is caught, then there has been an error and so returns -1
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}
