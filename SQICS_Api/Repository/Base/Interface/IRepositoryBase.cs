using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Repository.Base.Interface
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> QueryAsync();

    }
}
