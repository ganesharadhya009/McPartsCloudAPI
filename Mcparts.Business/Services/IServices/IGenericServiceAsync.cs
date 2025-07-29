using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Business.Services.IServices
{
    public interface IGenericServiceAsync<TEntity, TDto> : IReadServiceAsync<TEntity, TDto>
       where TEntity : class
       where TDto : class

    {
        Task AddAsync(TDto dto);
        Task DeleteAsync(object id);
        Task DeleteSoftByExpressionAsync(Expression<Func<TEntity, bool>> predicate);
        Task DeleteHardByExpressionAsync(Expression<Func<TEntity, bool>> predicate);
        Task DeleteHardByExpressionAsyncRange(Expression<Func<TEntity, bool>> predicate);
        Task UpdateAsync(TDto dto);
    }
}
