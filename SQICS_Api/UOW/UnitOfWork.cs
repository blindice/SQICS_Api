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
        private SQICSContext _context;
        private ITransactionRepository _transaction;
        private ISubAssyRepository _subAssy;

        public UnitOfWork(SQICSContext context) => _context = context;

        public ITransactionRepository Transaction
        {
            get
            {
                if (_transaction == null)
                {
                    _transaction = new TransactionRepository(_context);
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
                    _subAssy = new SubAssyRepository(_context);
                }
                return _subAssy;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
