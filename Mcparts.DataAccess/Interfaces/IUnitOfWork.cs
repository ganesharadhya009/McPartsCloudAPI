using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        IGenericRepository<T, TDto> Repository<T, TDto>()
            where T : class
            where TDto : class;
    }
}
