using Microsoft.AspNetCore.Mvc;
using Shared.Utils;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController(UploadService service) : Controller
{
    // POST /file/upload
    [HttpPost]
    public async Task<ServiceResponse<IFormFile>> UploadFile(IFormFile file)
    {
        var response = new ServiceResponse<IFormFile>();
        var result = await service.UploadFile(file);

        if (result.Success)
        {
            response.Data = result.Data;
            response.Message = result.Message;
            return response;
        }
        else
        {
            response.Success = false;
            response.Message = result.Message;
            return response;
        }
    }
    
    // GET /file/download
    [HttpGet("download/{fileName}")]
    public async Task<IActionResult> Download(string fileName)
    {
        var response = await service.DownloadFile(fileName);
        if (!ModelState.IsValid)
        {
            return NotFound();
        }
        return File(response.OpenReadStream(), "application/octet-stream", fileName);


    }

}