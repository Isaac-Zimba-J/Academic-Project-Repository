using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Shared.Models;
using Shared.Services.Contracts;
using Shared.Utils;
using Server.Data;

namespace Server.Services;

public class ApplicationUserService(
    UserManager<ApplicationUser> userManager, 
    SignInManager<ApplicationUser> signInManager, 
    AcademicProjectDbContext context, 
    HttpClient httpClient, 
    IHttpContextAccessor httpContextAccessor
    ) : IApplicationUserService
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
        // throw new NotImplementedException();
        var response = new ServiceResponse<Login>();
        var logUser = await userManager.FindByIdAsync(user.StudentId);

        if (logUser == null)
        {
            response.Success = false;
            response.Message = "User not found";
            return response;
        }
        // Checking if the user is locked out
        if (await userManager.IsLockedOutAsync(logUser))
        {
            response.Success = false;
            response.Message = "User is locked out";
            return response;
        }
        
        // Check if the email is confirmed
        if (!await userManager.IsEmailConfirmedAsync(logUser))
        {
            response.Success = false;
            response.Message = "Email is not confirmed";
            return response;
        }
        var result = await signInManager.PasswordSignInAsync(
            userName: logUser.Email, 
            password: user.Password, 
            isPersistent: false, 
            lockoutOnFailure: false
        );
        Console.Write("printing the result "+result);
        if (result.Succeeded)
        {
            response.Success = true;
            response.Message = "Login success";
            return response;
        }

        response.Success = false;
        response.Message = result.ToString();
        return response;
        
        
    }
}