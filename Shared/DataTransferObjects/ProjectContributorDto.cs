namespace Shared.Models
{
    public class ProjectContributorDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int ProjectReportId { get; set; }
        public int? ProjectGroupId { get; set; }
        public string ContributionDescription { get; set; }
    }
}