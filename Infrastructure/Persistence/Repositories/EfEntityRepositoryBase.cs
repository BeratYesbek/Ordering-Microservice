using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>, IAsyncEntityRepository<TEntity> where TEntity : Entity, new() where TContext : DbContext
    {
        public TContext Context { get; set; }
        public EfEntityRepositoryBase(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
            return Context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = default, params Expression<Func<TEntity, object>>[] including)
        {
            return filter != null
                ? Context.Set<TEntity>().Where(filter).ToList()
                : Context.Set<TEntity>().ToList();

        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = default, params Expression<Func<TEntity, object>>[]? including)
        {
            if (including is not null)
            {
                var include = filter != null
                    ? Context.Set<TEntity>().Where(filter).AsQueryable()
                    : Context.Set<TEntity>().AsQueryable();
                include = including.Aggregate(include, (current, item) => current.Include(item));

                return await include.ToListAsync();
            }
            return  filter != null
                ? await Context.Set<TEntity>().Where(filter).ToListAsync()
                : await Context.Set<TEntity>().ToListAsync();
        }
    }
}
