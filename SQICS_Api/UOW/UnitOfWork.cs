﻿using SQICS_Api.Model.Context;
using SQICS_Api.Repository;
using SQICS_Api.Repository.AssyDefect;
using SQICS_Api.Repository.Defect;
using SQICS_Api.Repository.InspectionMode;
using SQICS_Api.Repository.Interface;
using SQICS_Api.Repository.Line;
using SQICS_Api.Repository.Login;
using SQICS_Api.Repository.LotLabel;
using SQICS_Api.Repository.Ongoing;
using SQICS_Api.Repository.Operator;
using SQICS_Api.Repository.PartCodeColor;
using SQICS_Api.Repository.PiecePart;
using SQICS_Api.Repository.QCInspection;
using SQICS_Api.Repository.SubAssy;
using SQICS_Api.Repository.Transaction;
using SQICS_Api.Repository.TransactionDetail;
using SQICS_Api.Repository.TransactionHeader;
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
        private IOngoingRepository _ongoing;
        private IStationRepository _station;
        private ILineRepository _line;
        private ITransactionHeaderRepository _header;
        private IAssyDefectRepository _assyDefect;
        private ILotLabelRepository _lotLabel;
        private IQCInspectionRepository _qcInspection;
        private IInspectionModeRepository _inspectionMode;
        private IPartCodeColorRepository _partCodeColor;

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

        public IOngoingRepository Ongoing
        {
            get
            {
                if (_ongoing == null)
                {
                    _ongoing = new OngoingRepository(_efContext, _dapperContext);
                }
                return _ongoing;
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

        public IStationRepository Station
        {
            get
            {
                if (_station == null)
                {
                    _station = new StationRepository(_efContext, _dapperContext);
                }
                return _station;
            }
        }

        public ILineRepository Line
        {
            get
            {
                if (_line == null)
                {
                    _line = new LineRepository(_efContext, _dapperContext);
                }
                return _line;
            }
        }

        public ITransactionHeaderRepository THeader {
            get
            {
                if (_header == null)
                {
                    _header = new TransactionHeaderRepository(_efContext, _dapperContext);
                }
                return _header;
            }
        }

        public IAssyDefectRepository AssyDefect
        {
            get
            {
                if (_assyDefect == null)
                {
                    _assyDefect = new AssyDefectRepository(_efContext, _dapperContext);
                }
                return _assyDefect;
            }
        }

        public ILotLabelRepository LotLabel
        {
            get
            {
                if (_lotLabel == null)
                {
                    _lotLabel = new LotLabelRepository(_efContext, _dapperContext);
                }
                return _lotLabel;
            }
        }

        public IQCInspectionRepository QCInspection
        {
            get
            {
                if (_qcInspection == null)
                {
                    _qcInspection = new QCInspectionRepository(_efContext, _dapperContext);
                }
                return _qcInspection;
            }
        }

        public IInspectionModeRepository InspectionMode
        {
            get
            {
                if (_inspectionMode == null)
                {
                    _inspectionMode = new InspectionModeRepository(_efContext, _dapperContext);
                }
                return _inspectionMode;
            }
        }

        public IPartCodeColorRepository PartCodeColor
        {
            get
            {
                if (_partCodeColor == null)
                {
                    _partCodeColor = new PartCodeColorRepository(_efContext, _dapperContext);
                }
                return _partCodeColor;
            }
        }

        public async Task SaveAsync()
        {
            await _efContext.SaveChangesAsync();
        }
    }
}
