using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class ProjectContributor
{
    [Key]
    public string Id { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }
    public int ProjectReportId { get; set; }
    [ForeignKey("ProjectReportId")]
    public ProjectReport ProjectReport { get; set; }
    public int? ProjectGroupId { get; set; }
    [ForeignKey("ProjectGroupId")]
    public ProjectGroup ProjectGroup { get; set; }
    public string ContributionDescription { get; set; }

}