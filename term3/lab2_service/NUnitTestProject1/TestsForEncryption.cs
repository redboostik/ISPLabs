using NUnit.Framework;
using lab2_service;
using System.Text;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string s = "test string";
            string s1 = Encryption.encryption(s);
            Assert.True(Encryption.encryption(s1) == s, "method encription: wrong answer");
        }
        [Test]
        public void Test2()
        {
            string s = null;
            string s1 = Encryption.encryption(s);
            Assert.True(Encryption.encryption(s1) == s, "method encription: wrong answer");
        }
        [Test]
        public void Test3()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < 1e6; i++)
            {
                sb.Append("qwe");
            }
            string s = sb.ToString();
            string s1 = Encryption.encryption(s);
            Assert.True(Encryption.encryption(s1) == s, "method encription: wrong answer");
        }
        [Test]
        public void Test4()
        {
            string s = "";
            string s1 = Encryption.encryption(s);
            Assert.True(Encryption.encryption(s1) == s, "method encription: wrong answer");
        }
    }
}