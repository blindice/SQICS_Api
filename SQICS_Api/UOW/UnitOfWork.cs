using SQICS_Api.Model.Context;
using SQICS_Api.Repository.Defect;
using SQICS_Api.Repository.Interface;
using SQICS_Api.Repository.Login;
using SQICS_Api.Repository.Operator;
using SQICS_Api.Repository.PiecePart;
using SQICS_Api.Repository.SubAssy;
using SQICS_Api.Repository.Transaction;
using SQICS_Api.Repository.TransactionDetail;
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
        private ILoginRepository _login;
        private ITransactionDetailsRepository _tDetail;
        private IOperatorRepository _operator;
        private IPiecePartRepository _piecePart;
        private IDefectRepository _defect;

        public UnitOfWork(SQICSContext efContext, DapperContext dapperContext)
        {
            _efContext = efContext;
            _dapperContext = dapperContext;
        }

        public IDefectRepository Defect
        {
            get
            {
                if (_defect == null)
                {
                    _defect = new DefectRepository(_efContext, _dapperContext);
                }
                return _defect;
            }
        }

        public IPiecePartRepository PiecePart
        {
            get
            {
                if (_piecePart == null)
                {
                    _piecePart = new PiecePartRepository(_efContext, _dapperContext);
                }
                return _piecePart;
            }
        }

        public IOperatorRepository Operator
        {
            get
            {
                if (_operator == null)
                {
                    _operator = new OperatorRepository(_efContext, _dapperContext);
                }
                return _operator;
            }
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

        public ITransactionDetailsRepository TDetails
        {
            get
            {
                if (_tDetail == null)
                {
                    _tDetail = new TransactionDetailsRepository(_efContext, _dapperContext);
                }
                return _tDetail;
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

        public ILoginRepository Login
        {
            get
            {
                if (_login == null)
                {
                    _login = new LoginRepository(_efContext, _dapperContext);
                }
                return _login;
            }
        }

        public async Task SaveAsync()
        {
            await _efContext.SaveChangesAsync();
        }
    }
}
