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
        public static string compressing(string path)
        {

            string compressPath = path.Remove(path.Length - 3, 3) + "gz";
            if (File.Exists(path))
            {
                try
                {
                    using (FileStream sourceStream = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        using (FileStream targetStream = File.Create(compressPath))
                        {
                            using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                            {
                                sourceStream.CopyTo(compressionStream);
                            }
                        }
                    }
                }
                catch (Exception ee)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            return compressPath;
        }
        public static string decompressing(string path)
        {
            string decompressPath = path.Remove(path.Length - 2, 2) + "txt";

            if (File.Exists(path))
            {
                try
                {
                    using (FileStream sourceStream = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        using (FileStream targetStream = File.Create(decompressPath))
                        {
                            using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                            {
                                decompressionStream.CopyTo(targetStream);
                            }
                        }
                    }
                }
                catch (Exception ee)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            return decompressPath;

        }
    }
}
