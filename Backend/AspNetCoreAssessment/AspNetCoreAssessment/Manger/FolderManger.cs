using System.IO;

namespace AspNetCoreAssessment.Manger
{
    public class FolderManger
    {
        public static string CreateNewFolder(string DocumentName, int DocumentId)
        {
            string FolderName = DocumentName +"_"+ DocumentId;
            var directory = Directory.GetCurrentDirectory() + "/wwwroot/Uploads/"+ FolderName;
            if (!Directory.Exists(directory))

                Directory.CreateDirectory(directory);

            return FolderName;
        }
        public static void DeleteFolder(string FolderPath)
        {
            if (Directory.Exists(FolderPath))
            {
                // Delete all files from the Directory  
                foreach (string filename in Directory.GetFiles(FolderPath))
                {
                    File.Delete(filename);
                }
                // Check all child Directories and delete files  
                foreach (string subfolder in Directory.GetDirectories(FolderPath))
                {
                    DeleteFolder(subfolder);
                }
                Directory.Delete(FolderPath);
            }
        }
    }
}
