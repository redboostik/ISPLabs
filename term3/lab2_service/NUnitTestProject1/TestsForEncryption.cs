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
            var s = "test string";
            var enc = new Encryption();
            var s1 = enc.Encrypt(s);
            Assert.True(enc.Encrypt(s1) == s, "method encription: wrong answer");
        }
        [Test]
        public void Test2()
        {
            var s = "";
            var enc = new Encryption();
            var s1 = enc.Encrypt(s);
            Assert.True(enc.Encrypt(s1) == s, "method encription: wrong answer");
        }
        [Test]
        public void Test3()
        {
            var sb = new StringBuilder();
            for(var i = 0; i < 1e6; i++)
            {
                sb.Append("qwe");
            }
            var s = sb.ToString();
            var enc = new Encryption();
            var s1 = enc.Encrypt(s);
            Assert.True(enc.Encrypt(s1) == s, "method encription: wrong answer");
        }
        [Test]
        public void Test4()
        {
            var s = "";
            var enc = new Encryption();
            var s1 = enc.Encrypt(s);
            Assert.True(enc.Encrypt(s1) == s, "method encription: wrong answer");
        }
    }
}