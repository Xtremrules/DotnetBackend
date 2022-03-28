using DotnetBackend.Core.Entities.Abstracts;
using System.Linq.Expressions;

namespace DotnetBackend.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        string TableName { get; }
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> expression);
        Task<T> GetById(long id);
        Task<T> GetSingleWhere(Expression<Func<T, bool>> expression);
        Task Insert(T entity, bool save = true);
        Task InsertRange(IEnumerable<T> entityList, bool save = true);
        Task InsertBulk(IEnumerable<T> entityList);
        Task InsertOrUpdateBulk(IEnumerable<T> entityList);
        Task Update(T entity, bool save = true);
        Task UpdateRange(IEnumerable<T> entityList, bool save = true);
        Task UpdateBulk(IEnumerable<T> entityList);
        Task Delete(long id, bool save = true);
        Task DeleteRange(IEnumerable<long> ids, bool save = true);
        Task DeleteWhere(Expression<Func<T, bool>> expression, bool save = true);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        Task<int> Count();
        Task<int> CountWhere(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> AllAsync { get; }
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetSingleAsync(object Key);
        Task SaveAsync();
    }
}
