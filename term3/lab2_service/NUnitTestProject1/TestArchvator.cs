using NUnit.Framework;
using lab2_service;
using System.Text;
using System.IO;

namespace NUnitTestProject1
{
    public class TestsArchivator
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var path = "1.txt";
            var arch = new Archivator(path);
            TestDelegate t = () => arch.Compressing();
            Assert.DoesNotThrow(t, "File not Exists check");
        }
        [Test]
        public void Test2()
        {
            var path = "1.txt";
            var arch = new Archivator(path);
            TestDelegate t = () => arch.Compressing();
            Assert.DoesNotThrow(t, "File not Exists check");
        }
        [Test]
        public void Test4()
        {
            var path = "1.txt";
            var tStream = File.Create(path);
            tStream.Close();
            var arch = new Archivator(path);
            TestDelegate t = () => arch.Compressing();
            Assert.DoesNotThrow(t);
            File.Delete(path);
        }
    }
}