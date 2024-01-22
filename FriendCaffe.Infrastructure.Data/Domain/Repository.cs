using System.ComponentModel.DataAnnotations;
using FriendCaffe.Domain.SeedWork;
using FriendCaffe.Infrastructure.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace FriendCaffe.Infrastructure.Data.Domain;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly DbSet<TEntity> DbSet;
    protected readonly ApplicationDbContext ApplicationDbContext;

    protected Repository(ApplicationDbContext applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
        DbSet = ApplicationDbContext.Set<TEntity>();
    }

    public virtual async Task AddAsync(TEntity obj)
    {
        await DbSet.AddAsync(obj);
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id)
    {
        var domain = await DbSet.FindAsync(id);

        if (domain is null)
            throw new InvalidOperationException($"Entity {nameof(domain)} not found");

        return domain;
    }

    public virtual IQueryable<TEntity> GetAll()
    {
        return DbSet.AsNoTracking();
    }

    public virtual void Update(TEntity obj)
    {
        DbSet.Update(obj);
    }

    public virtual void Remove(TEntity obj)
    {
        DbSet.Remove(obj);
    }

    public virtual void RemoveAll(IQueryable<TEntity> objQuery)
    {
        DbSet.RemoveRange(objQuery);
    }

    public void Dispose()
    {
        ApplicationDbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}