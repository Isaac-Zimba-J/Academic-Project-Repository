using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

using Shared.Enums;

namespace Shared.Models;

public class ApplicationUser : IdentityUser
{
    [NotMapped]
    public string StudentId { get => Id; set { Id = value; } }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [MaxLength(255)]
    public string? ProfileImageUrl { get; set; }
    
    public YearOfStudy YearOfStudy { get; set; }
    
    public virtual ICollection<ProjectReport> SubmittedReports { get; set; }
    public virtual ICollection<ProjectReport> ApprovedReports { get; set; }
    public virtual ICollection<ProjectContributor> Contributions { get; set; }
}