using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

using Shared.Enums;

namespace Shared.Models;

public class ApplicationUser : IdentityUser
{
    [NotMapped]
    public string StudentId { get => Id; set { Id = value; } }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ProfileImageUrl { get; set; }
    public YearOfStudy YearOfStudy { get; set; }
    public List<ProjectReport>? SubmittedReports { get; set; }
    public List<ProjectReport>? ApprovedReports { get; set; }


}