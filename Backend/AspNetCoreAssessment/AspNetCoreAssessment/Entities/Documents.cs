﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AspNetCoreAssessment.Entities
{
    public partial class Documents
    {
        public Documents()
        {
            DocumentFiles = new HashSet<DocumentFiles>();
        }

        public int DocumentId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Date { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }

        public virtual Priorities PriorityNavigation { get; set; }
        public virtual ICollection<DocumentFiles> DocumentFiles { get; set; }
    }
}