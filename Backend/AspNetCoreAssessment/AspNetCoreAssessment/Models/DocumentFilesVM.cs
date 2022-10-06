using System.ComponentModel.DataAnnotations;
namespace AspNetCoreAssessment.Models
{
    public class DocumentFilesVM
    {
        public int FileId { get; set; }
        public string FilePath { get; set; }
        public int DocumentId { get; set; } 
        
        public IFormFile DocumentFile { get; set; }
        public string DocumentFolderName { get; set; }
    }
}
