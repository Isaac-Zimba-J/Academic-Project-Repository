using Shared.Enums;

namespace Shared.Models
{
    public class ProjectReportDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string CoverImageUrl { get; set; }
        public string PdfUrl { get; set; }
        public DateOnly SubmissionDate { get; set; }
        public PublicationStatus? PublicationStatus { get; set; }
        public string SubmitterId { get; set; }
        public string ApproverId { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }
        public Department? Department { get; set; }
        public int Year { get; set; }
        public string Supervisor { get; set; }
        public YearOfStudy? ProjectType { get; set; }
    }
}