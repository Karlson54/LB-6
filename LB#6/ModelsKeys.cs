namespace CryptoSecurity.Models
{
    class Keys
    {
        public int PublicExponent { get; }
        public int Modulus { get; }
        public int PrivateKey { get; }

        public Keys(int publicExponent, int modulus, int privateKey)
        {
            PublicExponent = publicExponent;
            Modulus = modulus;
            PrivateKey = privateKey;
        }
    }
}
