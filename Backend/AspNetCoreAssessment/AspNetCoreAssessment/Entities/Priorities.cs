﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AspNetCoreAssessment.Entities
{
    public partial class Priorities
    {
        public Priorities()
        {
            Documents = new HashSet<Documents>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Documents> Documents { get; set; }
    }
}