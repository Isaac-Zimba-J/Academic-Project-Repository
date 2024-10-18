using System;

namespace Shared.Models;

public class Mail
{
    public List<string> To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    
}
