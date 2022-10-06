using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Models;
using AutoMapper;
using Microsoft.CodeAnalysis;

namespace AspNetCoreAssessment.AutoMapper
{
    public class DomainProfile :Profile
    {
        public DomainProfile()
        {
            CreateMap<Documents, DocumentVM>().ReverseMap();
            CreateMap<Priorities, PrioritiesVM>().ReverseMap();
            CreateMap<DocumentFiles, DocumentFilesVM>().ReverseMap();

        }
    }
}
