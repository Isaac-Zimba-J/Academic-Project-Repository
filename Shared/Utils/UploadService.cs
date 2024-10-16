using Microsoft.AspNetCore.Http;
using Shared.Models;

namespace Shared.Utils;

public class UploadService
{
    public async Task<ServiceResponse<IFormFile>> UploadFile(IFormFile file)
    {
        var response = new ServiceResponse<IFormFile>();
        // check extensions and file size
        List<string> validExttensioin = new List<string>() { ".pdf", ".png", ".gif", ".jpg", ".jpeg" };
        string extensions = Path.GetExtension(file.FileName);

        if (!validExttensioin.Contains(extensions))
        {
            response.Success = false;
            response.Message = "Invalid file extension";
            return response;
        }
        
        long size = file.Length;

        if (size > (200 * 1024 * 1024))
        {
            response.Success = false;
            response.Message = "File size is too large";
            return response;
        }

        string fileName = Guid.NewGuid().ToString();
        string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        string filePath = Path.Combine(folder, fileName + extensions);
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        
        response.Data = file;
        response.Message = "File uploaded successfully";
        return response;
    }
    
    public async Task<IFormFile> DownloadFile(string fileName)
    {
        var response = new ServiceResponse<IFormFile>();
        string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        string filePath = Path.Combine(folder, fileName);
        if (!File.Exists(filePath))
        {
            response.Success = false;
            response.Message = "File not found";
        }
        
        response.Data = new FormFile(new FileStream(filePath, FileMode.Open), 0, new FileInfo(filePath).Length, fileName, fileName);
        response.Message = "File downloaded successfully";
        return response.Data;
    }
}





























