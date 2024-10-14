using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class ProjectContributor
{
    public string Id { get; set; }
    
    [Required]
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }
    
    public string ProjectReportId { get; set; }
    [ForeignKey("ProjectReportId")]
    public virtual ProjectReport ProjectReport { get; set; }
    
    public string? ProjectGroupId { get; set; }
    [ForeignKey("ProjectGroupId")]
    public virtual ProjectGroup? ProjectGroup { get; set; }
    
    [Required]
    public string ContributionDescription { get; set; }
}
