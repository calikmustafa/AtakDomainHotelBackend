using AtakDomainHotelBackend.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AtakDomainHotelBackend.Service.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);


        IQueryable<TEntity> GetAll(List<Expression<Func<TEntity, bool>>> expressions, PagingParams pagingParams);

        int GetAllTableCount(List<Expression<Func<TEntity, bool>>> expressions);


        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task<TEntity> AddAsyncWithReturn(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);

        void Update(TEntity newEntity, TEntity updatedEntity);


        void UpdateSingleProperty(TEntity entity, string propertyName, dynamic value);

        //void Update(TEntity newEntity, int id);

        void RemoveRange(IEnumerable<TEntity> entities);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
    }
}
