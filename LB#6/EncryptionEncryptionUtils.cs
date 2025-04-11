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

        public static int CalculatePublicExponent(int totient)
        {
            for (int e = 2; e < totient; e++)
            {
                if (GCD(e, totient) == 1)
                    return e;
            }
            throw new Exception("Could not find a suitable e.");
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

    }
}
