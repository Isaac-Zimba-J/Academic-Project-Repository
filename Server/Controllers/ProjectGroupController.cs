using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services.Contracts;
using Shared.Utils;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrator")]
public class ProjectGroupController(IProjectGroupService service) : Controller
{
    // GET ALL GROUPS
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<ProjectGroupDto>>>> GetAll()
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
    
    // GET GROUP BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<ProjectGroupDto>>> GetById(string id)
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
    
    // CREATE GROUP
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<ProjectGroupDto>>> Create(ProjectGroupDto group)
    {
        if (ModelState.IsValid)
        {
            return Ok(await service.Create(group));
        }
        else
        {
            return BadRequest();
        }
    }
    
    // UPDATE GROUP
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<ProjectGroupDto>>> Update(ProjectGroupDto group)
    {
        if (ModelState.IsValid)
        {
            return Ok(await service.Update(group));
        }
        else
        {
            return BadRequest();
        }
    }
    
    // DELETE GROUP
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<ProjectGroupDto>>> Delete(string id)
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