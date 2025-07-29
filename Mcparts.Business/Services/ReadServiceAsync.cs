using AutoMapper;
using Mcparts.Business.CustomExceptions;
using Mcparts.Business.Services.IServices;
using Mcparts.DataAccess.Interfaces;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Business.Services
{
    public class ReadServiceAsync<TEntity, TDto> : IReadServiceAsync<TEntity, TDto>
         where TEntity : class
         where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReadServiceAsync(IUnitOfWork unitOfWork, IMapper mapper) : base()
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.Repository<TEntity, TDto>().GetAllAsync();

                if (result.Any())
                {
                    return _mapper.Map<IEnumerable<TDto>>(result);
                }
                else
                {
                    return new List<TDto>();
                    //throw new EntityNotFoundException($"No {typeof(TDto).Name}s were found");
                }

            }
            catch (EntityNotFoundException ex)
            {
                var message = $"Error retrieving all {typeof(TDto).Name}s";

                throw new EntityNotFoundException(message, ex);
            }
        }

        public async Task<int> GetAllCount()
        {
            try
            {
                return await _unitOfWork.Repository<TEntity, TDto>().GetAllCount();

            }
            catch (EntityNotFoundException ex)
            {
                var message = $"Error retrieving all {typeof(TDto).Name}s";

                throw new EntityNotFoundException(message, ex);
            }
        }

        public async Task<int> GetAllCountByExpresson(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _unitOfWork.Repository<TEntity, TDto>().GetAllCountByExpresson(predicate);

            }
            catch (EntityNotFoundException ex)
            {
                var message = $"Error retrieving all {typeof(TDto).Name}s";

                throw new EntityNotFoundException(message, ex);
            }
        }

        public async Task<TDto> GetByIdAsync(object id)
        {
            try
            {
                var result = await _unitOfWork.Repository<TEntity, TDto>().GetByIdAsync(id);

                if (result is null)
                {
                    return null;
                }

                return _mapper.Map<TDto>(result);
            }

            catch (EntityNotFoundException ex)
            {
                var message = $"Error retrieving {typeof(TDto).Name} with Id: {id}";

                throw new EntityNotFoundException(message, ex);
            }
        }

        public async Task<IQueryable<TDto?>> GetByExpressionODataQueryAsync(Expression<Func<TEntity, bool>> predicate,
            ODataQueryOptions<TEntity> options)
        {
            try
            {
                var result = await _unitOfWork.Repository<TEntity, TDto>().GetByExpressionODataQueryAsync(predicate, options);

                if (result is null)
                {
                    return (IQueryable<TDto?>)new List<TDto>();
                }

                return (IQueryable<TDto?>)_mapper.Map<TDto>(result);
            }

            catch (EntityNotFoundException ex)
            {
                var message = $"Error retrieving";

                throw new EntityNotFoundException(message, ex);
            }
        }

        public async Task<List<TDto?>> GetListByExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await _unitOfWork.Repository<TEntity, TDto>().GetListByExpressionAsync(predicate);

                if (result is null)
                {
                    return new List<TDto>();
                }

                return result;
            }

            catch (EntityNotFoundException ex)
            {
                var message = $"Error retrieving ";

                throw new EntityNotFoundException(message, ex);
            }
        }

        public async Task<TDto?> GetSingleEntityByExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await _unitOfWork.Repository<TEntity, TDto>().GetSingleEntityExpressionAsync(predicate);

                if (result is null)
                {
                    return null;
                }

                return _mapper.Map<TDto>(result);
            }

            catch (EntityNotFoundException ex)
            {
                var message = $"Error retrieving ";

                throw new EntityNotFoundException(message, ex);
            }
        }
    }
}


