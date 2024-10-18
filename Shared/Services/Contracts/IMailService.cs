using System;
using Shared.Models;
using Shared.Utils;

namespace Shared.Services.Contracts;

public interface IMailService 
{
    Task<ServiceResponse<Mail>> SendMailAsync(Mail mail);
}
