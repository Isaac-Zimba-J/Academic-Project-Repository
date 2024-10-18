using Microsoft.AspNetCore.Identity;
using Shared.Models;
using Shared.Utils;

namespace Shared.Services.Contracts;

public interface IApplicationUserService
{
    Task<ServiceResponse<ApplicationUser>> GetUser();
    Task<ServiceResponse<ApplicationUser>> GetCurrentUser();
    Task<ServiceResponse<ApplicationUser>> GetUserById(string id);
    Task<ServiceResponse<ApplicationUser>>GetUserByEmail(string email);
    Task<ServiceResponse<ApplicationUser>> GetUserByStudentId(string studentId);
    Task<ServiceResponse<ApplicationUser>> UpdateUser(ApplicationUser user);
    Task<ServiceResponse<ApplicationUser>> DeleteUser(string id);
    Task<ServiceResponse<Register>> RegisterUser(Register user);
    Task<ServiceResponse<Login>> LoginUser(Login user);
    Task<ServiceResponse<ApplicationUser>> AssignRole(string studentId, string role);
    Task<ServiceResponse<IdentityRole>> RemoveRole(string studentId, string role);
    Task<ServiceResponse<IdentityRole>> AddRole( string role);
    
    
}