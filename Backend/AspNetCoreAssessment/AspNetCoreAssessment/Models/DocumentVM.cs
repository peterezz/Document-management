using System;
using System.ComponentModel.DataAnnotations;
using AspNetCoreAssessment.Entities;

namespace AspNetCoreAssessment.Models
{
    public class DocumentVM
    {
        public int DocumentId { get; set; }
        [Required(ErrorMessage ="Document name field is required")]
        [Display(Name="Document Name")]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        [Required(ErrorMessage = "Date field is required")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        [Display(Name = "Priority")]
        public int Priority { get; set; }
        [Required(ErrorMessage = "Due date field is required")]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        //Document Files
        [Required(ErrorMessage ="At Least Upload one file")]
        [Display(Name ="Document Files")]
        public List<IFormFile> DocumentFiles{ get; set; }

    }
}
