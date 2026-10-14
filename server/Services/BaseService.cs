using System;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Models;

namespace server.Services;

public abstract class BaseService<TEntity, TUpdateDto>(TimeWastrDbContext context)
    : IBaseService<TEntity, TUpdateDto>
    where TEntity : class, IUserOwned
{
    protected readonly TimeWastrDbContext Context = context;
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    protected abstract void ApplyUpdate(TEntity existing, TUpdateDto dto);

    public virtual async Task<TEntity?> CreateAsync(TEntity model)
    {
        await DbSet.AddAsync(model);
        await Context.SaveChangesAsync();
        return model;
    }

    public virtual async Task<TEntity?> DeleteAsync(int id, string userId)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity is null || !entity.UserId.Equals(userId))
            return null;

        DbSet.Remove(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual Task<List<TEntity>> GetAllAsync() => DbSet.ToListAsync();

    public virtual Task<List<TEntity>> GetAllFromUserIdAsync(string userId) =>
        DbSet.Where(e => e.UserId == userId).ToListAsync();

    public virtual async Task<TEntity?> GetByIdAsync(int id, string userId)
    {
        var entity = await DbSet.FindAsync(id);

        if (entity == null || !entity.UserId.Equals(userId))
            return null;

        return entity;
    }

    public virtual async Task<TEntity?> UpdateAsync(int id, string userId, TUpdateDto model)
    {
        var existing = await DbSet.FindAsync(id);
        if (existing is null || !existing.UserId.Equals(userId))
            return null;

        ApplyUpdate(existing, model);
        await Context.SaveChangesAsync();
        return existing;
    }
}
