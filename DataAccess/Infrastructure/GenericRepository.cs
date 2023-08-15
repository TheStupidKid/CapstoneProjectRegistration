using BussinessObject.Models;
using DataAccess.Common;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        protected DbSet<T> _dbSet;
        private ICurrentTime _timeService;
        private IClaimService _claimService;

        public GenericRepository(CapstoneRegistrationContext appDBContext,
            ICurrentTime currentTime,
            IClaimService claimService) // contructor 3 param
        {
            _dbSet = appDBContext.Set<T>();
            _timeService = currentTime;
            _claimService = claimService;
        }

        public async Task AddAsync(T entity)
        {
            entity.CreationDate = DateTime.UtcNow;
            entity.CreatedBy = _claimService.GetCurrentUserId;
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreationDate = DateTime.UtcNow;
                entity.CreatedBy = _claimService.GetCurrentUserId;
            }
            await _dbSet.AddRangeAsync(entities);
        }

        public Task<List<T>> GetAllAsync() => _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(Guid? id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public void SoftRemove(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletionDate = _timeService.CurrentTime();
            entity.DeleteBy = _claimService.GetCurrentUserId;
            _dbSet.Update(entity);
        }

        public void SoftRemoveRange(List<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletionDate = _timeService.CurrentTime();
                entity.DeleteBy = _claimService.GetCurrentUserId;
            }
            _dbSet.UpdateRange(entities);
        }

        public void Update(T entity)
        {
            entity.ModificationDate = _timeService.CurrentTime();
            entity.ModificationBy = _claimService.GetCurrentUserId;
            _dbSet.Update(entity);
        }

        public void UpdateRange(List<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreationDate = DateTime.UtcNow;
                entity.CreatedBy = _claimService.GetCurrentUserId;
            }
            _dbSet.UpdateRange(entities);
        }
        public async Task<List<T>> Find(Expression<Func<T, bool>> expression)
        {
            var data = await _dbSet.Where(expression).ToListAsync();
            return data;
        }
        public IQueryable<T> query()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<Pagination<T>> ToPagination(int pageIndex = 0, int pageSize = 10)
        {
            var itemCount = await _dbSet.CountAsync();
            var items = await _dbSet.OrderByDescending(x => x.CreationDate)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToListAsync();

            var result = new Pagination<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items,
            };

            return result;
        }

        public async Task<List<T>> GetEntitiesByIdsAsync(List<Guid?> Ids) => await _dbSet.Where(x => Ids.Contains(x.Id)).ToListAsync();
    }
}
