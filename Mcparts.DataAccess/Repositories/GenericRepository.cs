using Mcparts.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mcparts.DataAccess.Models;
using AutoMapper;
using Microsoft.AspNetCore.OData.Query;
using System.Linq.Expressions;
using AutoMapper.AspNet.OData;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using AutoMapper.QueryableExtensions;

namespace Mcparts.DataAccess.Repositories
{
    public class GenericRepository<T, TDto> : IGenericRepository<T, TDto>
        where T : class
        where TDto : class
    {
        private readonly McpartsDbContext _databaseContext;
        private readonly DbSet<T> _dbSet;
        private readonly IMapper mapper;

        public GenericRepository(McpartsDbContext context, IMapper mapper)
        {
            _databaseContext = context;
            this.mapper = mapper;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TDto>> GetAllAsync(bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.ProjectTo<TDto>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<int> GetAllCount(bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.CountAsync();
        }

        public async Task<int> GetAllCountByExpresson(Expression<Func<T, bool>> predicate, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.CountAsync(predicate);
        }

        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FindAsync(predicate);
        }

        public async Task<List<TDto?>> GetListByExpressionAsync(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = _dbSet;

            query = query.AsNoTracking();

            if (predicate == null)
            {
                return await query.ProjectTo<TDto?>(mapper.ConfigurationProvider).ToListAsync();
            }
            else
            {
                return await query.Where(predicate).ProjectTo<TDto?>(mapper.ConfigurationProvider).ToListAsync();
            }
        }

        public async Task<T?> GetSingleEntityExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet;
            query = query.AsNoTracking();
            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IQueryable<T?>> GetByExpressionODataQueryAsync(Expression<Func<T, bool>> predicate,
            ODataQueryOptions<T> options)
        {
            return await _dbSet.Where(predicate).GetQueryAsync(mapper, options, querySettings: null);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            //await SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            //await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(object id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                // await SaveAsync();
            }
        }

        public async Task DeleteSoftByExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            var entityToDelete = await GetSingleEntityExpressionAsync(predicate);
            if (entityToDelete != null)
            {
                _databaseContext.Entry(entityToDelete).State = EntityState.Unchanged;
                _databaseContext.Entry(entityToDelete).Property("isdeleted").CurrentValue = true;
                _databaseContext.Entry(entityToDelete).Property("isdeleted").IsModified = true;
                // await SaveAsync();
            }
        }

        public async Task DeleteHardByExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            var entityToDelete = await _dbSet.FindAsync(predicate);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);

                // await SaveAsync();
            }
        }

        public async Task DeleteHardByExpressionAsyncRange(Expression<Func<T, bool>> predicate)
        {
            await _dbSet.Where(predicate).ExecuteDeleteAsync();
        }
    }
}
