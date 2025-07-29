using AutoMapper;
using Mcparts.DataAccess.Interfaces;
using Mcparts.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly McpartsDbContext _dbContext;
        private readonly IMapper mapper;

        public UnitOfWork(McpartsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IGenericRepository<T, TDto> Repository<T, TDto>()
            where T : class
            where TDto : class
        {
            return new GenericRepository<T, TDto>(_dbContext, mapper);
        }
    }
}
