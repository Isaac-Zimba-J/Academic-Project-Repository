using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class ProjectGroup
{
    [Key]
    public int Id { get; set; }
    public string GroupName { get; set; }
    public int Year { get; set; }
    public string Department { get; set; }
    public List<ProjectContributor> Members { get; set; }
    public List<ProjectReport> Reports { get; set; }

}