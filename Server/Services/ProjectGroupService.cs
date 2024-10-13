using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;
using Shared.Services.Contracts;
using Shared.Utils;

namespace Server.Services;

public class ProjectGroupService(AcademicProjectDbContext context, IMapper mapper) : IProjectGroupService
{
    public async Task<ServiceResponse<List<ProjectGroupDto>>> GetAll()
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<List<ProjectGroupDto>>();
        var groups = await context.ProjectGroups.ToListAsync();
        response.Data = mapper.Map<List<ProjectGroupDto>>(groups);
        return response;
    }

    public async Task<ServiceResponse<ProjectGroupDto>> GetById(string id)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectGroupDto>();
        var group = await context.ProjectGroups.FindAsync(id);
        response.Data = mapper.Map<ProjectGroupDto>(group);
        return response;
    }

    public async Task<ServiceResponse<ProjectGroupDto>> Create(ProjectGroupDto entity)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectGroupDto>();
        var newGroup = mapper.Map<ProjectGroup>(entity);
        await context.AddAsync(newGroup);
        await context.SaveChangesAsync();
        response.Data = mapper.Map<ProjectGroupDto>(newGroup);
        return response;
    }

    public async Task<ServiceResponse<ProjectGroupDto>> Update(ProjectGroupDto entity)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectGroupDto>();
        var group = await context.ProjectGroups.FindAsync(entity.Id);
        if (group == null)
        {
            response.Success = false;
            response.Message = "Group not found.";
            return response;
        }
        else
        {
            mapper.Map(entity, group);
            await context.SaveChangesAsync();
            response.Data = mapper.Map<ProjectGroupDto>(group);
            return response;
        }
    }

    public async Task<ServiceResponse<ProjectGroupDto>> Delete(string id)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectGroupDto>();
        var group = await context.ProjectGroups.FindAsync(id);
        if (group == null)
        {
            response.Success = false;
            response.Message = "Group not found.";
            return response;
        }
        else
        {
            context.ProjectGroups.Remove(group);
            await context.SaveChangesAsync();
            response.Data = mapper.Map<ProjectGroupDto>(group);
            return response;
        }
    }
}