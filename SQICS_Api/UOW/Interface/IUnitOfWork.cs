﻿using SQICS_Api.Model.Context;
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

        ITransactionDetailsRepository TDetails { get; }

        IOperatorRepository Operator { get; }

        IPiecePartRepository PiecePart { get; }

        IDefectRepository Defect { get; }

        IOngoingRepository Ongoing { get; }

        IStationRepository Station { get; }

        ILineRepository Line { get; }

        ITransactionHeaderRepository THeader { get; }

        IAssyDefectRepository AssyDefect { get; }

        ILotLabelRepository LotLabel { get; }

        IQCInspectionRepository QCInspection { get; }

        IInspectionModeRepository InspectionMode { get; }

        IPartCodeColorRepository PartCodeColor { get; }

        Task SaveAsync();
    }
}
