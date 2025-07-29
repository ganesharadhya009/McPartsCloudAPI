using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.DataAccess.Interfaces
{
    public interface IGenericRepository<T, TDto>
         where T : class
         where TDto : class
    {
        Task AddAsync(T entity);
        Task<T> GetByIdAsync(object id);
        Task<T> GetByExpressionAsync(Expression<Func<T, bool>> predicate);
        Task<List<TDto?>> GetListByExpressionAsync(Expression<Func<T, bool>> predicate = null);
        Task<T?> GetSingleEntityExpressionAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T?>> GetByExpressionODataQueryAsync(Expression<Func<T, bool>> predicate, ODataQueryOptions<T> options);
        Task<List<TDto>> GetAllAsync(bool tracked = true);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(object id);
        Task DeleteSoftByExpressionAsync(Expression<Func<T, bool>> predicate);
        Task DeleteHardByExpressionAsync(Expression<Func<T, bool>> predicate);
        Task DeleteHardByExpressionAsyncRange(Expression<Func<T, bool>> predicate);
        Task SaveAsync();
        Task<int> GetAllCount(bool tracked = true);
        Task<int> GetAllCountByExpresson(Expression<Func<T, bool>> predicate, bool tracked = true);
    }
}
