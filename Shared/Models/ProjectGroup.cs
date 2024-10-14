using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.Models;

public class ProjectGroup
{

    public string Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string GroupName { get; set; }
    
    public int Year { get; set; }
    
    public Department Department { get; set; }
    
    public virtual ICollection<ProjectContributor> Members { get; set; }
    public virtual ICollection<ProjectReport> Reports { get; set; }
}