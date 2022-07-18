using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Interface;
using SQICS_Api.Repository.SubAssy;
using SQICS_Api.Repository.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private SQICSContext _efContext;
        private DapperContext _dapperContext;
        private ITransactionRepository _transaction;
        private ISubAssyRepository _subAssy;

        public UnitOfWork(SQICSContext efContext, DapperContext dapperContext)
        {
            _efContext = efContext;
            _dapperContext = dapperContext;
        }

        public ITransactionRepository Transaction
        {
            get
            {
                if (_transaction == null)
                {
                    _transaction = new TransactionRepository(_efContext, _dapperContext);
                }
                return _transaction;
            }
        }

        public ISubAssyRepository SubAssy
        {
            get
            {
                if (_subAssy == null)
                {
                    _subAssy = new SubAssyRepository(_efContext, _dapperContext);
                }
                return _subAssy;
            }
        }

        public async Task Save()
        {
            await _efContext.SaveChangesAsync();
        }
    }
}
