using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_service
{
    public class Archivator
    {
        private string path;
        public Archivator(string s)
        {
            path = s;
        }

        public string Compressing()
        {
            string compressPath = path.Remove(path.Length - 3, 3) + "gz";
            if (File.Exists(path))
            {
                    using (var sourceStream = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        using (var targetStream = File.Create(compressPath))
                        {
                            using (var compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                            {
                                sourceStream.CopyTo(compressionStream);
                            }
                        }
                    }
            }
            return compressPath;
        }
        public string Decompressing()
        {
            var decompressPath = path.Remove(path.Length - 2, 2) + "txt";

            if (File.Exists(path))
            {
                    using (var sourceStream = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        using (var targetStream = File.Create(decompressPath))
                        {
                            using (var decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                            {
                                decompressionStream.CopyTo(targetStream);
                            }
                        }
                    }
            }
            return decompressPath;

        }
    }
}
