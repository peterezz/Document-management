using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCoreAssessment.Entities;

namespace AspNetCoreAssessment.Models
{
    public class DocumentVM
    {
        public int DocumentId { get; set; }
        [Required(ErrorMessage ="Document name field is required")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "The characters ':', '.' ';', '*', '/' and '\' are not allowed")]

        [Display(Name="Document Name")]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        [Required(ErrorMessage = "Date field is required")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        [Display(Name = "Priority")]
        public int Priority { get; set; }
        public PrioritiesVM? PriorityName { get; set; }

        [Required(ErrorMessage = "Due date field is required")]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        //Document Files
        [NotMapped]
        [Display(Name ="Document Files")]
        public List<IFormFile>? DocumentFiles{ get; set; }
        public  List<DocumentFilesVM>? DocumentFilesVM { get; set; }
    }
}
