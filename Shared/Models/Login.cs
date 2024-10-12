using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Login
{
    [Required]
    public string StudentId { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}