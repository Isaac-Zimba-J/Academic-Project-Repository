using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;
using Shared.Services.Contracts;
using Shared.Utils;

namespace Server.Services;

public class ProjectReportService(AcademicProjectDbContext context, IMapper mapper) : IProjectReportService
{
    public async Task<ServiceResponse<List<ProjectReportDto>>> GetAll()
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<List<ProjectReportDto>>();
        var reports = await context.ProjectReports.ToListAsync();
        response.Data = mapper.Map<List<ProjectReportDto>>(reports);
        return response;
    }

    public async Task<ServiceResponse<ProjectReportDto>> GetById(string id)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectReportDto>();
        var report = await context.ProjectReports.FindAsync(id);
        response.Data = mapper.Map<ProjectReportDto>(report);
        return response;
    }

    public async Task<ServiceResponse<ProjectReportDto>> Create(ProjectReportDto entity)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectReportDto>();
        var newReport = mapper.Map<ProjectReport>(entity);
        await context.AddAsync(newReport);
        await context.SaveChangesAsync();
        response.Data = mapper.Map<ProjectReportDto>(newReport);
        return response;
        
    }

    public async Task<ServiceResponse<ProjectReportDto>> Update(ProjectReportDto entity)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectReportDto>();
        var report = await context.ProjectReports.FirstOrDefaultAsync(report => report.Id == entity.Id);
        if (report == null)
        {
            response.Success = false;
            response.Message = "Report not found.";
            return response;
        }
        else
        {
            mapper.Map(entity, report);
            await context.SaveChangesAsync();
            response.Data = mapper.Map<ProjectReportDto>(report);
            return response;
        }
    }

    public async Task<ServiceResponse<ProjectReportDto>> Delete(string id)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<ProjectReportDto>();
        var report = await context.ProjectReports.FindAsync(id);
        if (report == null)
        {
            response.Success = false;
            response.Message = "Report not found.";
            return response;
        }
        else
        {
            context.ProjectReports.Remove(report);
            await context.SaveChangesAsync();
            response.Data = mapper.Map<ProjectReportDto>(report);
            return response;
        }
    }






}