using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services.Contracts;
using Shared.Utils;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectReportController(IProjectReportService service) : Controller
{
    
    // GETALL REPORTS
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<ProjectReportDto>>>> GetAll()
    {
        if (ModelState.IsValid)
        {
            return Ok(await service.GetAll());
        }
        else
        {
            return BadRequest();
        }

    }
    
    // GET REPORT BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<ProjectReportDto>>> GetById(string id)
    {
        if (ModelState.IsValid)
        {
            return Ok(await service.GetById(id));
        }
        else
        {
            return BadRequest();
        }
    }
    
    // CREATE REPORT
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<ProjectReportDto>>> Create(ProjectReportDto report)
    {
        if (ModelState.IsValid)
        {
            return Ok(await service.Create(report));
        }
        else
        {
            return BadRequest();
        }
    }
    
    // UPDATE REPORT
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<ProjectReportDto>>> Update(ProjectReportDto report)
    {
        if (ModelState.IsValid)
        {
            return Ok(await service.Update(report));
        }
        else
        {
            return BadRequest();
        }
    }
    
    // DELETE REPORT
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<ProjectReportDto>>> Delete(string id)
    {
        if (ModelState.IsValid)
        {
            return Ok(await service.Delete(id));
        }
        else
        {
            return BadRequest();
        }
    }
    
    


}