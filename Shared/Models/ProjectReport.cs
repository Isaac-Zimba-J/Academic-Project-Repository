using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace Shared.Models;

public class ProjectReport
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Abstract { get; set; }
    public string CoverImageUrl { get; set; }
    public string PdfUrl { get; set; }
    public DateOnly SubmissionDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public PublicationStatus? PublicationStatus { get; set; }
    [ForeignKey("GroupId")]
    public ProjectGroup? Group { get; set; }
    public string SubmitterId { get; set; } // Changed to string
    [ForeignKey("SubmitterId")]
    public ApplicationUser? Submitter { get; set; }
    public string ApproverId { get; set; } // Changed to string
    [ForeignKey("ApproverId")]
    public ApplicationUser? Approver { get; set; }
    public DateTimeOffset? ApprovalDate { get; set; }
    public Department? Department { get; set; }
    public int Year { get; set; }
    public string Supervisor { get; set; }
    public YearOfStudy? ProjectType { get; set; }
    public List<ProjectContributor>? Contributors { get; set; }

}