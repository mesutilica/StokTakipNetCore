using Microsoft.AspNetCore.Http;
using System.IO;

namespace StokTakipNetCore.Utils
{
    public class FileHelper
    {
        public static string FileLoader(IFormFile formFile, string filePath = "/Img/")
        {
            var fileName = "";
            if (formFile != null && formFile.Length > 0)
            {
                fileName = formFile.FileName.Trim().ToLower().Replace(' ','-');
                string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;
                FileStream stream = new FileStream(directory, FileMode.Create);
                formFile.CopyTo(stream);
            }
            return fileName;
        }
        public static bool FileTerminator(string filePath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(filePath)) filePath = "/Img/";
            string deletedFile = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;
            if (File.Exists(deletedFile))
            {
                File.Delete(deletedFile);
                return true;
            }
            return false;
        }
    }
}
