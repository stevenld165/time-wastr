using System;
using server.Models;

namespace server.Interfaces;

public interface IBaseService<TEntity, TUpdateDto>
    where TEntity : class, IUserOwned
{
    Task<TEntity?> CreateAsync(TEntity model);
    Task<TEntity?> DeleteAsync(int id, string userId);
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> GetAllFromUserIdAsync(string userId);
    Task<TEntity?> GetByIdAsync(int id, string userId);
    Task<TEntity?> UpdateAsync(int id, string userId, TUpdateDto model);
}
