using CryptoSecurity.Encryption;
using CryptoSecurity.Models;

namespace CryptoSecurity
{
    class Program
    {
        static void PrintList<T>(List<T> list, string description)
        {
            Console.Write($"{description}: ");
            Console.WriteLine(string.Join(" ", list));
        }

        static void Main(string[] args)
        {
            string message = "ruba'and";
            Console.WriteLine($"Original message: {message}");

            var crypto = new AsymmetricEncryption();

            List<int> asciiValues = crypto.ConvertTextToASCII(message);
            PrintList(asciiValues, "ASCII character codes");

            List<int> encryptedValues = crypto.EncryptValues(asciiValues);
            PrintList(encryptedValues, "Encrypted message");

            Keys keys = crypto.GetKeys();
            Console.WriteLine($"Public key (e, n): ({keys.PublicExponent}, {keys.Modulus})");
            Console.WriteLine($"Private key (d): {keys.PrivateKey}");

            string decrypted = crypto.DecryptValues(encryptedValues);
            Console.WriteLine($"Decrypted message: {decrypted}");

        }
    }
}
