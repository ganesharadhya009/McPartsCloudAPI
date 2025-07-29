using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Business.Services.IServices
{
    public interface IReadServiceAsync<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(object id);

        Task<List<TDto?>> GetListByExpressionAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IQueryable<TDto?>> GetByExpressionODataQueryAsync(Expression<Func<TEntity, bool>> predicate,
            ODataQueryOptions<TEntity> options);

        Task<TDto?> GetSingleEntityByExpressionAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> GetAllCount();
        Task<int> GetAllCountByExpresson(Expression<Func<TEntity, bool>> predicate);
    }
}
