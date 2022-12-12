using System;
using System.IO;

namespace CryptoSoft
{
    class Program
    {
        static void Main(string[] args)
        {

            // Vérifier si un argument a été passé
            if (args.Length == 0)
            {
                Console.WriteLine("Aucun chemin d'accès au fichier n'a été spécifié. Veuillez réessayer en précisant un chemin de forme semblable à \"C:\\repertoire\\repertoire\\fichier.extention\"");
                return;

            }
            // La clé doit être un nombre entier de 64 bits
            long key = 0x193A4B7890AB186F;
            // Le fichier à chiffrer
            string plaintextFile = args[0];
            // Le fichier chiffré
            string ciphertextFile = args[1];

            // Lecture du fichier en clair
            string plaintext = File.ReadAllText(plaintextFile);

            // Tableau pour stocker les octets chiffrés
            byte[] ciphertext = new byte[plaintext.Length];

            // Chiffrement du fichier bit par bit en utilisant la clé
            for (int i = 0; i < plaintext.Length; i++)
            {
                // Récupération de l'octet en clair
                byte plainByte = (byte)plaintext[i];

                // Récupération du bit à la position i de la clé
                long keyBit = (key >> i) & 1;

                // Chiffrement de l'octet en utilisant le bit de la clé
                byte cipherByte = (byte)(plainByte ^ keyBit);

                // Stockage de l'octet chiffré dans le tableau
                ciphertext[i] = cipherByte;
            }

            // Écriture du fichier chiffré
            File.WriteAllBytes(ciphertextFile, ciphertext);
        }
    }
}
