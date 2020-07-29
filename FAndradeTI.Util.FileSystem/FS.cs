using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FAndradeTI.Util.FileSystem
{
    public static class FS
    {
        public static string LastErrorMethod { get; set; }

        public static string LastErrorMessage { get; set; }

        public static void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }

        public static bool FolderExists(string path)
        {
            return Directory.Exists(path);
        }

        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }


        public static string[] GetFiles(string path, string extension)
        {
            return Directory.GetFiles(path, extension);
        }

        public static string GetFileName(string fileName)
        {
            return Path.GetFileName(fileName);
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

        public static string PathCombine(string path, string folder)
        {
            return Path.Combine(path, folder);
        }

        public static void MoveFile(string fileName, string path, string movePath)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var filePath = fileName.Replace(path, movePath);

            if (File.Exists(filePath))
                File.Delete(filePath);

            File.Move(fileName, filePath);
        }

        public static void CopyFile(string filePath, string copyPath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var aux = filePath.Replace(Path.GetDirectoryName(filePath), copyPath);

            File.Copy(filePath, aux, true);
        }

        public static void CopyFileIfNewer(string filePath, string copyPath)
        {
            //var aux = filePath.Replace(Path.GetDirectoryName(filePath), copyPath);

            //File.Copy(filePath, aux, true);

            FileInfo file = new FileInfo(filePath);
            FileInfo destFile = new FileInfo(Path.Combine(copyPath, file.Name));
            if (destFile.Exists)
            {
                if (file.LastWriteTime > destFile.LastWriteTime)
                {
                    // now you can safely overwrite it
                    file.CopyTo(destFile.FullName, true);
                }
            }
            else
            {
                file.CopyTo(destFile.FullName, true);
            }
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