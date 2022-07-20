using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.UOW
{
    public interface IUnitOfWork
    {
        ITransactionRepository Transaction { get; }

        ISubAssyRepository SubAssy { get; }

        ILoginRepository Login { get; }

        Task SaveAsync();
    }
}
