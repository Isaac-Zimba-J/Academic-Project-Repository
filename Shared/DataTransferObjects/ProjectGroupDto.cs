using Shared.Enums;

namespace Shared.Models
{
    public class ProjectGroupDto
    {
        public string Id { get; set; }
        public string GroupName { get; set; }
        public int Year { get; set; }
        public Department Department { get; set; }
    }
}