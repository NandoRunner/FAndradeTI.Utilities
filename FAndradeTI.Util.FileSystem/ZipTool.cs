using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace FAndradeTI.Util.FileSystem
{
    // Compression Utilities
    public static class ZipTool
    {
        //private static string directoryPath = @"c:\temp";

        public static void Comprimir(string origem, string arquivo)
        {
            if (File.Exists(@arquivo))
            {
                File.Delete(@arquivo);
            }
            ZipFile.CreateFromDirectory(@origem, @arquivo);
        }

        public static void Extrair(string arquivo, string caminho)
        {
             ZipFile.ExtractToDirectory(@arquivo, @caminho);
        }

        public static void ExtrairGZip(string inputPath, string outputPath)
        {
            using (var input = File.OpenRead(inputPath))
            using (var output = File.OpenWrite(outputPath))
            using (var gz = new GZipStream(input, CompressionMode.Decompress))
            {
                Task t = gz.CopyToAsync(output);
                t.Wait();
            }
        }

        public static void CompressFile(FileInfo fileToCompress)
        {
            if (fileToCompress == null) return;

            FileStream originalFileStream = null;
            try
            {
                originalFileStream = fileToCompress.OpenRead();

                if ((File.GetAttributes(fileToCompress.FullName) &
                   FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                {
                    using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                    {
                        using (var compressionStream = new GZipStream(compressedFileStream,
                           CompressionMode.Compress))
                        {

                            originalFileStream.CopyTo(compressionStream);
                        }
                    }
                    FileInfo info = new FileInfo(fileToCompress.Directory.FullName + "\\" + fileToCompress.Name + ".gz");
                    Console.WriteLine($"Compressed {fileToCompress.Name} from {fileToCompress.Length.ToString(CultureInfo.CurrentCulture)} to {info.Length.ToString(CultureInfo.CurrentCulture)} bytes.");
                }
            }
            finally
            {
                originalFileStream?.Dispose();
            }

        }

        public static void Compress(DirectoryInfo directorySelected)
        {
            if (directorySelected == null) return;

            try
            {
                foreach (FileInfo fileToCompress in directorySelected.GetFiles())
                {
                    CompressFile(fileToCompress);
                }
            }
            catch
            {
                throw;
            }

        }

        public static void Decompress(FileInfo fileToDecompress)
        {
            if (fileToDecompress == null) return;
            try
            {
                using (FileStream originalFileStream = fileToDecompress.OpenRead())
                {
                    string currentFileName = fileToDecompress.FullName;
                    string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                    using (FileStream decompressedFileStream = File.Create(newFileName))
                    {
                        using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(decompressedFileStream);
                            Console.WriteLine($"Decompressed: {fileToDecompress.Name}");
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
