using System;
using System.IO;
using System.Text.Encodings;

namespace CryptoSoft
{
    class Program
    {
        static void Main(string[] args)
        {

            // check if an attribute has been passed or not
            if (args.Length == 0)
            {
                Console.WriteLine("Aucun chemin d'accès au fichier n'a été spécifié. Veuillez réessayer en précisant un chemin de forme semblable à \"C:\\repertoire\\repertoire\\fichier.extention\"");
                return;

            }
            // The key has to bee an integer of 64 bytes
            long key = 0x193A4B7890AB186F;
            // File to encrypt
            string plaintextFile = args[0];
            // File to encrypt
            string ciphertextFile = args[1];

            // Read the File clearly
            string plaintext = File.ReadAllText(plaintextFile);

            // Table to store encrypted bytes
            byte[] ciphertext = new byte[plaintext.Length];

            // Encryption of the file bit by bit using the key
            for (int i = 0; i < plaintext.Length; i++)
            {
                // Get to message
                byte plainByte = (byte)plaintext[i];

                // Getting the Byte at the i position key
                long keyBit = (key >> i) & 1;

                // Encrypt the file by using the one of the key 
                byte cipherByte = (byte)(plainByte ^ keyBit);

                // Store the byte in the table
                ciphertext[i] = cipherByte;
            }

            // Writting the cipher file
            File.WriteAllBytes(ciphertextFile, ciphertext);
            Console.WriteLine("Félicitation !! Votre fichier a été Crypté");
        }
    }
}
