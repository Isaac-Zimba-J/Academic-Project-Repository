using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services.Contracts;
using Shared.Utils;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectContributorController(IProjectContributorService service) : Controller
{
    

    // GET ALL CONTRIBUTORS
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<ProjectContributorDto>>>> GetAll()
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

    // GET CONTRIBUTOR BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<ProjectContributorDto>>> GetById(string id)
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

    // CREATE CONTRIBUTOR
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<ProjectContributorDto>>> Create(ProjectContributorDto contributor)
    {
        if (ModelState.IsValid)
        {
            return Ok(await service.Create(contributor));
        }
        else
        {
            return BadRequest();
        }
    }

    // UPDATE CONTRIBUTOR
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<ProjectContributorDto>>> Update(ProjectContributorDto contributor)
    {
        if (ModelState.IsValid)
        {
            return Ok(await service.Update(contributor));
        }
        else
        {
            return BadRequest();
        }
    }

    // DELETE CONTRIBUTOR
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<ProjectContributorDto>>> Delete(string id)
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