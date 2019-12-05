using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace CryptoSoft
{
    class Crypto
    {
        /// <summary>
        /// Member of the class Crypto corresponding to the key used to encrypt and decrypt
        /// </summary>
        private string key;

        /// <summary>
        /// Constructor of the class Crypto. Sets the key
        /// </summary>
        /// <param name="password">Key for encrypting and decrypting</param>
        public Crypto(string password)
        {
            this.key = password;
        }

        /// <summary>
        /// Method of encrypting a file to another file
        /// </summary>
        /// <param name="sourceFile">Path of the source file to be encrypted</param>
        /// <param name="targetFile">Path of the target file where will be encrypted the data of the sourceFile</param>
        public void EncryptFile(string sourceFile, string targetFile)
        {
            try
            {
                //Defines the encoding of the key
                UnicodeEncoding ue = new UnicodeEncoding();
                byte[] keyByte = ue.GetBytes(this.key);

                int data;

                //Create a stream for the target file that will be linked to cryptographic transformations to encrypt the sourceFile
                FileStream fsOut = new FileStream(targetFile, FileMode.Create, FileAccess.Write);
                RijndaelManaged RMcrypt = new RijndaelManaged();
                CryptoStream cs = new CryptoStream(fsOut, RMcrypt.CreateEncryptor(keyByte, keyByte), CryptoStreamMode.Write);
                FileStream fsIn = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);

                //For each byte read, it is written to the targetFile
                while ((data = fsIn.ReadByte()) != -1)
                {
                    cs.WriteByte((byte)data);
                }

                //Close the streams (Source file, target file and the CryptoStream)
                fsIn.Close();
                cs.Close();
                fsOut.Close();
            }
            catch(IOException e)
            {
                throw new IOException("IO Error : " + e.Message);
            }
            catch(CryptographicException e)
            {
                throw new CryptographicException("Cryptographic exception : " + e.Message);
            }
            catch(Exception e)
            {
                throw new Exception("Error : " + e.Message);
            }
        }

        /// <summary>
        /// Method of decrypting a file to another file
        /// </summary>
        /// <param name="sourceFile">Path of the source file to be decrypted</param>
        /// <param name="targetFile">Path of the target file where will be decrypted the data of the sourceFile</param>
        public void DecryptFile(string sourceFile, string targetFile)
        {
            try
            {
                //Defines the encoding of the key
                UnicodeEncoding ue = new UnicodeEncoding();
                byte[] keyByte = ue.GetBytes(this.key);

                int data;

                //Create a stream for the target file that will be linked to cryptographic transformations to decrypting the sourceFile
                FileStream fsIn = new FileStream(sourceFile, FileMode.Open);
                RijndaelManaged RMcrypt = new RijndaelManaged();
                CryptoStream cs = new CryptoStream(fsIn, RMcrypt.CreateDecryptor(keyByte, keyByte), CryptoStreamMode.Read);
                FileStream fsOut = new FileStream(targetFile, FileMode.Create);

                //For each byte read, it is written to the targetFile
                while ((data = cs.ReadByte()) != -1)
                {
                    fsOut.WriteByte((byte)data);
                }

                //Close the streams (Source file, target file and the CryptoStream)
                fsIn.Close();
                cs.Close();
                fsOut.Close();
            }
            catch (IOException e)
            {
                throw new IOException("IO Error : " + e.Message);
            }
            catch (CryptographicException e)
            {
                throw new CryptographicException("Cryptographic exception : " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Error : " + e.Message);
            }
        }
    }
}
