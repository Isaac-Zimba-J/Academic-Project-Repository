using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Utils;
using Server.Services;
using Shared.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Server.Controllers;

[ApiController]
[Route("user")]
public class UserController(IApplicationUserService service) : Controller
{
    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<Register>>> Register(Register user)
    {
        if (ModelState.IsValid)
        {
            return await service.RegisterUser(user);
        }
        return BadRequest();

    }

    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<Login>>> Login(Login user)
    {
        if (ModelState.IsValid)
        {
            return await service.LoginUser(user);
        }

        return BadRequest();
    }

    [HttpPost("AssignRole")]
    public async Task<ActionResult<ServiceResponse<ApplicationUser>>> AssignRole(string studentId, string role)
    {
        if (ModelState.IsValid)
        {
           return await service.AssignRole(studentId,role);
        }
        return BadRequest();
    }

    [HttpPost("AddRole")]
    public async Task<ActionResult<ServiceResponse<IdentityRole>>> AddRole(string role)
    {
        if (ModelState.IsValid)
        {
            return await service.AddRole(role);
        }
        return BadRequest();
    }
}