using Shared.Utils;

namespace Shared.Services.Contracts;

public interface IGenericBaseService<T,TKey>
{
    // Generic Base Service to be inherited by all services
    // Containing crud operations for any type of entity
    Task<ServiceResponse<T>> GetAll();
    Task<ServiceResponse<T>> GetById(TKey id);
    Task<ServiceResponse<T>> Create(T entity);
    Task<ServiceResponse<T>> Update(T entity);
    Task<ServiceResponse<T>> Delete(TKey id);
    
    
}