using System;

namespace lab2_service
{
    public class Encryption
    {
        private byte key = 228;

        public Encryption()
        {

        }
        public Encryption(byte b)
        {
            key = b;
        }
        public string encryption<T>(T text)
        {
            if (text == null) return "";
            char[] textChar = text.ToString().ToCharArray();
            for (int i = 0; i < textChar.Length; i++)
            {
                textChar[i] = secret(textChar[i]);
            }

            return new String(textChar);
        }
        private char secret(char c)
        {
            return (char)(key ^ (byte)(c));
        }
    }
}
