using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;
using Shared.Services.Contracts;
using Shared.Utils;

namespace Server.Services;

public class ProjectContributorService(AcademicProjectDbContext context, IMapper mapper) : IProjectContributorService
{
    public async Task<ServiceResponse<List<ProjectContributorDto>>> GetAll()
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<List<ProjectContributorDto>>();
        var contributors = await context.ProjectContributors.ToListAsync();
        
        response.Data = mapper.Map<List<ProjectContributorDto>>(contributors);
        
        return response;
    }

    public async Task<ServiceResponse<ProjectContributorDto>> GetById(string id)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectContributorDto>();
        var contributor = await context.ProjectContributors.FindAsync(id);
        
        response.Data = mapper.Map<ProjectContributorDto>(contributor);
        
        return response;
        
    }

    public async Task<ServiceResponse<ProjectContributorDto>> Create(ProjectContributorDto entity)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectContributorDto>();
        var newContributor = mapper.Map<ProjectContributor>(entity);
        
        await context.AddAsync(newContributor);
        
        await context.SaveChangesAsync();
        
        response.Data = mapper.Map<ProjectContributorDto>(newContributor);
            
        return response;
    }

    public async Task<ServiceResponse<ProjectContributorDto>> Update(ProjectContributorDto entity)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectContributorDto>();
        var contributor = await context.ProjectContributors.FirstOrDefaultAsync(contributor => contributor.Id == entity.Id);
        
        if (contributor == null)
        {
            response.Success = false;
            response.Message = "Contributor not found.";
            return response;
        }
        else
        {
            mapper.Map(entity, contributor);
            
            await context.SaveChangesAsync();
            
            response.Data = mapper.Map<ProjectContributorDto>(contributor);
            
            return response;
        }
    }

    public async Task<ServiceResponse<ProjectContributorDto>> Delete(string id)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectContributorDto>();
        var contributor = await context.ProjectContributors.FindAsync(id);
        
        if (contributor == null)
        {
            response.Success = false;
            response.Message = "Contributor not found.";
            return response;
        }
        else
        {
            context.ProjectContributors.Remove(contributor);

            await context.SaveChangesAsync();

            response.Data = mapper.Map<ProjectContributorDto>(contributor);

            return response;
        }
    }
}