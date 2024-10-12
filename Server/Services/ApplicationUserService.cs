using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Shared.Models;
using Shared.Services.Contracts;
using Shared.Utils;
using Server.Data;

namespace Shared.Services;

public class ApplicationUserService(
    UserManager<ApplicationUser> userManager, 
    SignInManager<ApplicationUser> signInManager, 
    AcademicProjectDbContext context, 
    HttpClient httpClient, 
    IHttpContextAccessor httpContextAccessor
    ) : IApplicationnUserService
{
    
    
    public async Task<ServiceResponse<ApplicationUser>> GetUser()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<ApplicationUser>> GetCurrentUser()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<ApplicationUser>> GetUserById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<ApplicationUser>> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<ApplicationUser>> GetUserByStudentId(string studentId)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<ApplicationUser>> UpdateUser(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<ApplicationUser>> DeleteUser(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<Register>> RegisterUser(Register user)
    {
        // throw new NotImplementedException();
        var response = new ServiceResponse<Register>();
        var newUser = new ApplicationUser
        {
            Id = user.StudentId,
            UserName = user.Email,
            Email = user.Email,
            StudentId = user.StudentId,
            FirstName = user.Firstname,
            LastName = user.Lastname,
            PhoneNumber = user.PhoneNumber,
        };
        
        var result = await userManager.CreateAsync(newUser, user.Password);
        
        if (result.Succeeded)
        {
            response.Success = true;
            response.Message = "User registered successfully";
            
        }
        else
        {
            response.Success = false;
            response.Message = "Failed to register user";
            foreach (var error in result.Errors)
            {
                response.Message += error.Description;
            }
        }

        return  response;
    }

    public async Task<ServiceResponse<Login>> LoginUser(Login user)
    {
        throw new NotImplementedException();
    }
}