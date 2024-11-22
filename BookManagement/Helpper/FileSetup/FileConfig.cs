using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;



namespace BookManagement.Helpper.FileSetup
{
    public static class FileConfig
    {
        public static string SaveFile(string targetPath)
        {
            string pathImage = System.IO.Path.GetFileName(targetPath);
            try
            {
                FileInfo fileInfo = new FileInfo(targetPath);
                string workingDirectory = Environment.CurrentDirectory;

                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName + @"\Resources\Image\" + System.IO.Path.GetFileName(targetPath);
                if (ExitFile(projectDirectory))
                {
                    return pathImage;
                }
                fileInfo.CopyTo(projectDirectory);
            }
            catch (Exception ex) {

                pathImage = ex.Message;
            }
            return pathImage;
        }
        public static string GetFile(string targetPath)
        {
            string pathImage =string.Empty;
            try
            {
                // Get current working directory (..\bin\Debug)
                string workingDirectory = Environment.CurrentDirectory;

                // Get the current PROJECT directory
                pathImage = Directory.GetParent(workingDirectory).Parent.FullName + @"\Resources\Image\" + targetPath;
            }
            catch (Exception ex)
            {

                pathImage = ex.Message;
            }
            return pathImage;
        }
        public static void DeleFile(string targetPath)
        {
            string pathImage = string.Empty;
            try
            {
                // Get current working directory (..\bin\Debug)
                string workingDirectory = Environment.CurrentDirectory;

                // Get the current PROJECT directory
                pathImage = Directory.GetParent(workingDirectory).Parent.FullName + @"\Resources\Image\" + targetPath;
                if (ExitFile(pathImage))
                {
                    File.Delete(pathImage);
                }
                else 
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {

                pathImage = ex.Message;
            }
        }
        public static void DeleFileUpdate(string targetPath)
        {

            try
            {
                if (ExitFile(targetPath))
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(targetPath);
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                
            }
        }
        public static string GetFileName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }
        private static bool ExitFile(string path)
        {
            return File.Exists(path);
        }
        public static string GetFileNameWithExtension(string path)
        {
            return Path.GetFileName(path);
        }
        public static string GetFileName(FileInfo fileInfo)
        {
            return Path.GetFileNameWithoutExtension(fileInfo.Name);
        }
        public static FileInfo Rename(this FileInfo file, String newName)
        {
            var filePath = Path.Combine(Path.GetDirectoryName(file.FullName), newName);
            file.MoveTo(filePath);
            return file;
        }
        public static FileInfo RenameFileWithoutExtension(this FileInfo file, String newName)
        {
            var fileName = String.Concat(newName, file.Extension);
            file.Rename(fileName);
            return file;
        }
        public static FileInfo ChangeExtension(this FileInfo file, String newExtension)
        {
            //newExtension = newExtension.EnsureStartsWith(".", true);
            var fileName = String.Concat(Path.GetFileNameWithoutExtension(file.FullName), newExtension);
            file.Rename(fileName);
            return file;
        }
        public static FileInfo[] ChangeExtensions(this FileInfo[] files, String newExtension)
        {
            //files.ForEach(f => f.ChangeExtension(newExtension));
            return files;
        }
        public static void Delete(this FileInfo[] files)
        {
            files.Delete(true);
        }
        public static void Delete(this FileInfo[] files, Boolean consolidateExceptions)
        {
            if (consolidateExceptions)
            {
                var exceptions = new List<Exception>();

                foreach (var file in files)
                {
                    try { file.Delete(); }
                    catch (Exception e) { exceptions.Add(e); }
                }
            }
            else foreach (var file in files) file.Delete();
        }
        public static FileInfo[] CopyTo(this FileInfo[] files, String targetPath) => files.CopyTo(targetPath, true);

        public static FileInfo[] CopyTo(this FileInfo[] files, String targetPath, Boolean consolidateExceptions)
        {
            var copiedfiles = new List<FileInfo>();
            List<Exception> exceptions = null;

            foreach (var file in files)
            {
                try
                {
                    var fileName = Path.Combine(targetPath, file.Name);
                    copiedfiles.Add(file.CopyTo(fileName));
                }
                catch (Exception e)
                {
                    if (consolidateExceptions)
                    {
                        if (exceptions == null) exceptions = new List<Exception>();
                        exceptions.Add(e);
                    }
                    else throw;
                }
            }
            return copiedfiles.ToArray();
        }
    }
}
