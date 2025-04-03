namespace CryptoSecurity.Encryption
{
    static class EncryptionUtils
    {
        public static int FastPowerModulo(int baseValue, int exponent, int modulus)
        {
            int result = 1;
            baseValue %= modulus;

            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                    result = (result * baseValue) % modulus;

                exponent >>= 1;
                baseValue = (baseValue * baseValue) % modulus;
            }
            return result;
        }

        public static int ComputeModularInverse(int value, int modulus)
        {
            int originalModulus = modulus;
            int y = 0, x = 1;

            if (modulus == 1)
                return 0;

            while (value > 1)
            {
                int quotient = value / modulus;
                int temp = modulus;
                modulus = value % modulus;
                value = temp;
                temp = y;
                y = x - quotient * y;
                x = temp;
            }
            return x < 0 ? x + originalModulus : x;
        }
    }
}
