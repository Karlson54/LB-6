using System.Text;
using CryptoSecurity.Models;

namespace CryptoSecurity.Encryption
{
    class AsymmetricEncryption
    {
        private readonly int _firstPrime = 13;
        private readonly int _secondPrime = 61;
        private readonly int _publicExponent = 11;

        private int _modulus;
        private int _privateKey;

        public AsymmetricEncryption()
        {
            InitializeKeys();
        }

        private void InitializeKeys()
        {
            _modulus = _firstPrime * _secondPrime;
            int totient = (_firstPrime - 1) * (_secondPrime - 1);
            _privateKey = EncryptionUtils.ComputeModularInverse(_publicExponent, totient);
        }

        public List<int> ConvertTextToASCII(string message)
        {
            List<int> asciiValues = new List<int>();
            foreach (char c in message)
                asciiValues.Add((int)c);
            return asciiValues;
        }

        public List<int> EncryptValues(List<int> values)
        {
            List<int> encrypted = new List<int>();
            foreach (int value in values)
                encrypted.Add(EncryptionUtils.FastPowerModulo(value, _publicExponent, _modulus));
            return encrypted;
        }

        public string DecryptValues(List<int> encrypted)
        {
            StringBuilder plain = new StringBuilder();
            foreach (int cipher in encrypted)
                plain.Append((char)EncryptionUtils.FastPowerModulo(cipher, _privateKey, _modulus));
            return plain.ToString();
        }

        public Keys GetKeys() => new Keys(_publicExponent, _modulus, _privateKey);
    }
}
