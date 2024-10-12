using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Utils;
using Server.Services;
using Shared.Services.Contracts;

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
}