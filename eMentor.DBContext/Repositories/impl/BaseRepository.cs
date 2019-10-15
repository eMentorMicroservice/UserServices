using eMentor.Entities.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eMentor.DBContext.Repositories.impl
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContextFactory ContextFactory;
        protected string TableName;

        public BaseRepository(DbContextFactory contextFactory)
        {
            ContextFactory = contextFactory;
        }

        protected virtual  IList<TEntity> GetAll(Expression<Func<TEntity, bool>> whereClause = null)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<TEntity>()
                            select b;

                if (whereClause != null)
                {
                    query = query.Where(whereClause);
                }

                return  query.ToList();
            }
        }

        protected virtual  IList<TEntity> GetAll(Expression<Func<TEntity, bool>> whereClause, bool includeDeactivated = false)
        {
            var query =  GetAll(whereClause);

            if (includeDeactivated) return  query;

            return  query.Where(p => p.IsDeactivate == false).ToList();
        }
        protected virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereClause = null)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<TEntity>()
                            select b;

                if (whereClause != null)
                {
                    query = query.Where(whereClause);
                }

                return query.FirstOrDefault();
            }
        }

        protected virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereClause , bool includeDeactivated = false)
        {
            var query = FirstOrDefault(whereClause);

            if (includeDeactivated) return query;

            if (query!=null && query.IsDeactivate) return null;
            else return query;
        }

        public virtual async Task<TEntity> GetByIdAsync(object id, bool includeDeactive = true)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var obj = context.Set<TEntity>().Where(p => p.Id == (int)id);

                if (!includeDeactive)
                    obj.Where(p => p.IsDeactivate == false);

                return await obj.FirstOrDefaultAsync();
            }
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = context.Set<TEntity>();

                return await query.ToListAsync();
            }
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> whereClause)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<TEntity>()
                            select b;

                if (whereClause != null)
                {
                    query = query.Where(whereClause);
                }

                 return await query.ToListAsync(); 
            }
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                return await context.Set<TEntity>().AnyAsync(p => p.Id == id);
            }
        }

        public virtual async Task<List<TEntity>> GetByIdAsync(IEnumerable<int> id)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from ent in context.Set<TEntity>()
                            where id.Contains(ent.Id)
                            select ent;

                return await query.ToListAsync();
            }
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereClause)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<TEntity>()
                            select b;

                if (whereClause != null)
                {
                    query = query.Where(whereClause);
                }

                return await query.FirstOrDefaultAsync(); ;
            }
        }

        public virtual async Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> whereClause)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<TEntity>()
                            select b;

                if (whereClause != null)
                {
                    query = query.Where(whereClause);
                }

                return await query.FirstOrDefaultAsync();
            }
        }

        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                entity.Created = DateTime.UtcNow;
                await context.Set<TEntity>().AddAsync(entity);
                return await context.SaveChangesAsync();
            }
        }

        public virtual async Task<int> InsertAsync(IEnumerable<TEntity> entities)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                foreach (var entity in entities)
                {
                    entity.Created = DateTime.UtcNow;
                    await context.Set<TEntity>().AddAsync(entity);
                }

                return await context.SaveChangesAsync();
            }
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                try
                {
                    var entity = context.Set<TEntity>().Find(id);

                    if (entity == null)
                        throw new ArgumentNullException("entity");

                    context.Set<TEntity>().Remove(entity);

                    return await context.SaveChangesAsync();

                }
                catch (Exception dbEx)
                {
                    var msg = dbEx.ToString();
                    throw new Exception(msg, dbEx);
                }
            }
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                try
                {
                    if (entity == null)
                        throw new ArgumentNullException("entity");

                    context.Set<TEntity>().Remove(entity);

                    return await context.SaveChangesAsync();

                }
                catch (Exception dbEx)
                {
                    var msg = dbEx.ToString();
                    throw new Exception(msg, dbEx);
                }
            }
        }
        public virtual async Task<int> DeleteAsync(IEnumerable<TEntity> entities)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                foreach (var entity in entities)
                {
                    try
                    {
                        if (entity == null)
                            throw new ArgumentNullException("entity");

                        context.Set<TEntity>().Remove(entity);

                    }
                    catch (Exception dbEx)
                    {
                        var msg = dbEx.ToString();
                        throw new Exception(msg, dbEx);
                    }
                }

                return await context.SaveChangesAsync();
            }
        }

        public virtual async Task<int> DeleteAsync()
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = context.Set<TEntity>();

                foreach (var entity in query)
                {
                    try
                    {
                        if (entity == null)
                            throw new ArgumentNullException("entity");

                        context.Set<TEntity>().Remove(entity);
                    }
                    catch (Exception dbEx)
                    {
                        var msg = dbEx.ToString();
                        throw new Exception(msg, dbEx);
                    }
                }

                return await context.SaveChangesAsync();
            }
        }

        public virtual Task<int> DeleteAll()
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                try
                {
                    var sqlCommand = string.Format("DELETE FROM {0}", typeof(TEntity).Name);
                    return context.Database.ExecuteSqlCommandAsync(sqlCommand);
                }
                catch (Exception dbEx)
                {
                    var msg = dbEx.ToString();
                    throw new Exception(msg, dbEx);
                }
            }
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                entity.Modified = DateTime.UtcNow;
                context.Set<TEntity>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                return await context.SaveChangesAsync();
            }
        }

        public virtual async Task<int> UpdateAsync(IEnumerable<TEntity> entities)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                foreach (var entity in entities)
                {
                    entity.Modified = DateTime.UtcNow;
                    context.Set<TEntity>().Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                }
                return await context.SaveChangesAsync();
            }
        }

        public virtual async Task<int> InsertOrReplaceAllAsync(IEnumerable<TEntity> entities)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var existIds = context.Set<TEntity>().Select(p => p.Id).ToList();

                foreach (var item in entities)
                {
                    if (!existIds.Contains(item.Id))
                    {
                        item.Created = DateTime.UtcNow;
                        context.Set<TEntity>().Add(item);
                    }
                    else
                    {
                        item.Modified = DateTime.UtcNow;
                        context.Set<TEntity>().Attach(item);
                        context.Entry(item).State = EntityState.Modified;
                    }
                }

                return await context.SaveChangesAsync();
            }
        }
    }
}
