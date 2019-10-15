using eMentor.Entities.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eMentor.DBContext.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> whereClause);

        Task<TEntity> GetByIdAsync(object id, bool includeDeactive = true);
        Task<List<TEntity>> GetByIdAsync(IEnumerable<int> id);
        Task<bool> ExistsAsync(int id);
        Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> whereClause);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereClause);

        Task<int> InsertAsync(TEntity entity);
        Task<int> InsertAsync(IEnumerable<TEntity> entities);

        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(TEntity entity);
        Task<int> DeleteAsync(IEnumerable<TEntity> entities);
        Task<int> DeleteAsync();
        Task<int> DeleteAll();

        Task<int> UpdateAsync(TEntity entity);
        Task<int> UpdateAsync(IEnumerable<TEntity> entities);

        Task<int> InsertOrReplaceAllAsync(IEnumerable<TEntity> entities);
    }
}
