using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FAndradeTI.Util.FileSystem
{
    public static class FS
    {
        public static string LastErrorMessage { get; set; }
        public static string LastErrorMethod { get; set; }
        public static void CopyFile(string filePath, string copyPath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var aux = filePath.Replace(Path.GetDirectoryName(filePath), copyPath);

            File.Copy(filePath, aux, true);
        }

        public static bool CopyFileIfNewer(string filePath, string copyPath)
        {
            var ret = false;

            FileInfo file = new FileInfo(filePath);
            FileInfo destFile = new FileInfo(Path.Combine(copyPath, file.Name));
            if (destFile.Exists)
            {
                if (file.LastWriteTime > destFile.LastWriteTime)
                {
                    // now you can safely overwrite it
                    file.CopyTo(destFile.FullName, true);
                    ret = true;
                }
            }
            else
            {
                file.CopyTo(destFile.FullName, true);
                ret = true;
            }

            return ret;
        }

        public static void CreateEmptyFile(string filename, bool json = true)
        {
            using (var output = new StreamWriter(filename, false, Encoding.GetEncoding(28591)))
            {
                if (json)
                {
                    output.WriteLine("{");
                    output.WriteLine("}");
                }
            }
        }

        public static void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }

        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public static bool FolderExists(string path)
        {
            return Directory.Exists(path);
        }
        public static string GetCreationTime(string fileName)
        {
            return File.GetCreationTime(fileName).ToShortDateString();
        }

        public static string GetFile(string fileName, string title, string filter, string initialDir)
        {
            var ret = fileName;

            using (OpenFileDialog ofd = new OpenFileDialog
            {
                FileName = fileName,
                Title = title,
                Filter = filter,
                InitialDirectory = initialDir
            })
            {
                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK)
                    ret = ofd.FileName;
            }
            return ret;
        }

        public static string GetFileName(string fileName)
        {
            return Path.GetFileName(fileName);
        }

        public static string[] GetFiles(string path, string extension)
        {
            return Directory.GetFiles(path, extension);
        }
        public static string GetFolder(string path, string description)
        {
            var ret = path;

            using (FolderBrowserDialog diag = new FolderBrowserDialog
            {
                Description = description,
                SelectedPath = path
            })
            {
                DialogResult result = diag.ShowDialog();

                if (result == DialogResult.OK)
                    ret = diag.SelectedPath;
            }
            return ret;
        }

        public static string GetFolderName(string fileName)
        {
            return Path.GetDirectoryName(fileName);
        }
        public static bool IsOpened(string FileName)
        {
            try
            {
                Stream s = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.None);

                s.Close();

                return false;
            }
            catch (FileNotFoundException ex)
            {
                LastErrorMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                LastErrorMessage = ex.Message;
                Console.WriteLine(ex.Message);
                return true;
            }
        }

        public static List<T> LoadJson<T>(string fileName)
        {
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string linhasDoArquivo = sr.ReadToEnd();
                sr.Close();

                JavaScriptSerializer serializador = new JavaScriptSerializer();
                return serializador.Deserialize<List<T>>(linhasDoArquivo);
            }
            catch (Exception ex)
            {
                LastErrorMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                LastErrorMessage = ex.Message;
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static List<string> LoadText(string fileName)
        {
            try
            {
                return File.ReadAllLines(fileName).ToList();
            }
            catch (Exception ex)
            {
                LastErrorMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                LastErrorMessage = ex.Message;
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public static void MoveFile(string sourceFile, string targetFile)
        {
            if (sourceFile == null)
            {
                throw new ArgumentNullException(nameof(sourceFile));
            }

            if (targetFile == null)
            {
                throw new ArgumentNullException(nameof(targetFile));
            }

            File.Move(sourceFile, targetFile);
        }

        public static void MoveFile(string fileName, string sourcePath, string targetPath)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var filePath = fileName.Replace(sourcePath, targetPath);

            if (File.Exists(filePath))
                File.Delete(filePath);

            File.Move(fileName, filePath);
        }

        public static string ParseFileName(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var aux = fileName.Split('\\');

            var aux2 = aux[aux.Length - 1].Split('-');

            var ret = aux[aux.Length - 1].Replace("-" + aux2[aux2.Length - 1], "");

            return ret.Replace(".json", "");
        }

        public static string PathCombine(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }
        public static void SaveJson<T>(List<T> list, string fileName)
        {
            try
            {
                //list.Sort((x, y) => x.caminho.CompareTo(y.caminho));

                JavaScriptSerializer serializador = new JavaScriptSerializer();
                string stringObjSerializado = serializador.Serialize(list);

                StreamWriter sw = new StreamWriter(fileName);
                sw.Write(stringObjSerializado);
                sw.Close();
            }
            catch (Exception ex)
            {
                LastErrorMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                LastErrorMessage = ex.Message;
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}