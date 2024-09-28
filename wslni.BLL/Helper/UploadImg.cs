using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wslni.BLL.Helper
{
    public class UploadImg
    {

        public static string UploadFile(string FolderName, IFormFile File)
        {
            try
            {
                // Set the base directory to wwwroot
                string wwwRootPath = Directory.GetCurrentDirectory() + "/wwwroot";

                // Get the target folder path
                string FolderPath = Path.Combine(wwwRootPath, "Imgs", FolderName);

                // Create the directory if it doesn't exist
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                // Get unique file name using GUID
                string FileName = Guid.NewGuid() + Path.GetExtension(File.FileName);

                // Combine path and file name
                string FinalPath = Path.Combine(FolderPath, FileName);

                // Save file
                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    File.CopyTo(Stream);
                }

                return FileName; // Return the file name (which will be stored in the database)
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
