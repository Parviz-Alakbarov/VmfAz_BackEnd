using Core.Entities;
using Core.Utilities.PaginationHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task Add(TEntity entity)
        {
            using (TContext context = new())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (TContext context = new())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            using (TContext context = new())
            {
                return expression == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(expression).ToListAsync();
            }
        }

        public async Task<List<TEntity>> GetAllWithPaginated(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> expression)
        {
            using (TContext context = new())
            {
                return expression == null
                    ? await PaginationList<TEntity>.CreateAsync(context.Set<TEntity>(), pageNumber, pageSize)
                    : await PaginationList<TEntity>.CreateAsync(context.Set<TEntity>().Where(expression), pageNumber, pageSize);
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            using (TContext context = new())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(expression);
            }
        }

        public async Task Update(TEntity entity)
        {
            using (TContext context = new())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
