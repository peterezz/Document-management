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
        public static void DeleteFolder(string FolderName)
        {
            var directory = Directory.GetCurrentDirectory() + "/wwwroot/Uploads/" + FolderName;
            if (Directory.Exists(directory))
            {
                // Delete all files from the Directory  
                foreach (string filename in Directory.GetFiles(directory))
                {
                    File.Delete(filename);
                }
                // Check all child Directories and delete files  
                foreach (string subfolder in Directory.GetDirectories(directory))
                {
                    DeleteFolder(subfolder);
                }
                Directory.Delete(directory);
            }
        }
    }
}
