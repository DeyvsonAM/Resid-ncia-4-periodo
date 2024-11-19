using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APISenac.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(Guid id, T updatedEntity);
        Task<bool> DeleteAsync(Guid id);
    }
}
