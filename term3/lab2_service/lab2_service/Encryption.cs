using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_service
{
    public class Encryption
    {
        private static byte key = 228;
        static public string encryption(string text)
        {
            if (text == null) return null;
            char[] textChar = text.ToCharArray();
            for (int i = 0; i < textChar.Length; i++)
            {
                textChar[i] = secret(textChar[i]);
            }

            return new String(textChar);
        }
        private static char secret(char c)
        {
            return (char)(key ^ (byte)(c));
        }
    }
}
