namespace Shared.Utils;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Success;
    public string Message;
}