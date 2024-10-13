using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.Models;

public class ProjectGroup
{
    [Key]
    public int Id { get; set; }
    public string GroupName { get; set; }
    public int Year { get; set; }
    public Department Department { get; set; }
    public List<ProjectContributor> Members { get; set; }
    public List<ProjectReport> Reports { get; set; }

}