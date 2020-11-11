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
            string path = "1.txt";
            Archivator arch = new Archivator(path);
            TestDelegate t = () => arch.compressing();
            Assert.DoesNotThrow(t, "File not Exists check");
        }
        [Test]
        public void Test2()
        {
            string path = "1.txt";
            Archivator arch = new Archivator(path);
            TestDelegate t = () => arch.compressing();
            Assert.DoesNotThrow(t, "File not Exists check");
        }
        [Test]
        public void Test4()
        {
            string path = "1.txt";
            FileStream tStream = File.Create(path);
            tStream.Close();
            Archivator arch = new Archivator(path);
            TestDelegate t = () => arch.compressing();
            Assert.DoesNotThrow(t);
            File.Delete(path);
        }
    }
}