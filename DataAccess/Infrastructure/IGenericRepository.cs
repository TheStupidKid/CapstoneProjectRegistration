using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetEntitiesByIdsAsync(List<Guid?> Ids);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid? id);
        Task AddAsync(T entity);
        void Update(T entity);
        void UpdateRange(List<T> entities);
        void SoftRemove(T entity);
        Task AddRangeAsync(List<T> entities);
        void SoftRemoveRange(List<T> entities);
        Task<List<T>> Find(Expression<Func<T, bool>> expression);
        IQueryable<T> query();
        Task<Pagination<T>> ToPagination(int pageNumber = 0, int pageSize = 10);
    }
}
