using AutoMapper;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Shared.Models;

namespace Shared;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProjectReport, ProjectReportDto>().ReverseMap();
        CreateMap<ProjectGroup, ProjectGroupDto>().ReverseMap();
        CreateMap<ProjectContributor, ProjectContributorDto>().ReverseMap();
    }
    
}