using AutoMapper;
using Mcparts.Business.Services.IServices;
using Mcparts.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.OData.Query;
using AutoMapper.AspNet.OData;

namespace Mcparts.Business.Services
{
    public class GenericServiceAsync<TEntity, TDto> : ReadServiceAsync<TEntity, TDto>, IGenericServiceAsync<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public GenericServiceAsync(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(TDto dto)
        {
            await _unitOfWork.Repository<TEntity, TDto>().AddAsync(_mapper.Map<TEntity>(dto));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteSoftByExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await _unitOfWork.Repository<TEntity, TDto>().DeleteSoftByExpressionAsync(predicate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteHardByExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await _unitOfWork.Repository<TEntity, TDto>().DeleteHardByExpressionAsync(predicate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteHardByExpressionAsyncRange(Expression<Func<TEntity, bool>> predicate)
        {
            await _unitOfWork.Repository<TEntity, TDto>().DeleteHardByExpressionAsyncRange(predicate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            await _unitOfWork.Repository<TEntity, TDto>().DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _unitOfWork.Repository<TEntity, TDto>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}

