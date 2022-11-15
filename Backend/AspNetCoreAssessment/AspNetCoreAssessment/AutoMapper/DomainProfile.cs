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
            CreateMap<Documents, DocumentVM>()
                .ForMember(des=>des.DocumentFilesVM,opt=>opt.MapFrom(sor=>sor.DocumentFiles))
                .ForMember(des => des.PriorityName, opt => opt.MapFrom(sor => sor.PriorityNavigation))
                .ForMember(res=>res.DocumentFiles,opt=>opt.Ignore())
                .ReverseMap();
            CreateMap<Priorities, PrioritiesVM>().ReverseMap();
            CreateMap<DocumentFiles, DocumentFilesVM>().ReverseMap();

        }
    }
}
