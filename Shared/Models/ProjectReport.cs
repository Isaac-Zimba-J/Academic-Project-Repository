using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace Shared.Models;
public class ProjectReport
{
    public string Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    
    [Required]
    public string Abstract { get; set; }
    
    [MaxLength(255)]
    public string CoverImageUrl { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string PdfUrl { get; set; }
    
    public DateOnly SubmissionDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    
    public PublicationStatus? PublicationStatus { get; set; }
    
    public string? GroupId { get; set; }
    [ForeignKey("GroupId")]
    public virtual ProjectGroup? Group { get; set; }
    
    [Required]
    public string SubmitterId { get; set; }
    [ForeignKey("SubmitterId")]
    public virtual ApplicationUser Submitter { get; set; }
    
    public string? ApproverId { get; set; }
    [ForeignKey("ApproverId")]
    public virtual ApplicationUser? Approver { get; set; }
    
    public DateTimeOffset? ApprovalDate { get; set; }
    
    public Department? Department { get; set; }
    
    public int Year { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Supervisor { get; set; }
    
    public YearOfStudy? ProjectType { get; set; }
    
    public virtual ICollection<ProjectContributor> Contributors { get; set; }
}