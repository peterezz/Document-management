using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AssessmentFrontEnd.Models
{
    public class DocumentVM
    {
        public int DocumentId { get; set; }
        [Required(ErrorMessage = "Document name field is required")]
        [Display(Name = "Document Name")]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        [Required(ErrorMessage = "Date field is required")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        [Display(Name = "Priority")]
        public int Priority { get; set; }
        [NotMapped]
        public string? PriorityName { get; set; }

        [Required(ErrorMessage = "Due date field is required")]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        //Document Files
        [NotMapped]
        [Display(Name = "Document Files")]
        public List<IFormFile>? DocumentFiles { get; set; }
    }
}
