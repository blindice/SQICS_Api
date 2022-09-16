using AutoMapper;
using Microsoft.AspNetCore.Http;
using SQICS_Api.DTOs;
using SQICS_Api.Enum;
using SQICS_Api.Helper.CustomException;
using SQICS_Api.Helper.POCO;
using SQICS_Api.Model;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Plan
{
    public class PlanService : IPlanService
    {
        IUnitOfWork _uow;
        IMapper _mapper;

        public PlanService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<SubAssyByOperatorIdDTO> GetOperatorDetailsAsync(string operatorId)
        {
            var @operator = await _uow.Operator.GetOperatorByEmpId(operatorId);

            if (@operator is null)
            {
                @operator = new SubAssyByOperatorIdDTO
                {
                    OperatorId = Convert.ToInt32(operatorId),
                    OperatorName = "4M"
                };
            }

            return @operator;
        }

        public async Task<List<SubAssyDDLDTO>> GetSubAssyDdlDataAsync(int supplierId)
        {
            var subAssies = await _uow.SubAssy.GetSubAssyBySupplierId(supplierId);

            if (subAssies is null) throw new CustomException("No Subassy for DDL Found!");

            var subAssiDTO = _mapper.Map<List<SubAssyDDLDTO>>(subAssies);

            if (subAssiDTO is null || subAssiDTO.Count == 0)
                throw new Exception("Invalid Mapping from tbl_m_part to SubAssyDDLDTO!");

            return subAssiDTO;
        }

        public async Task<SubAssyDetailsDTO> GetSubAssyByCodeAsync(int supplierId, string subassyCode)
        {
            var subAssies = await _uow.SubAssy.GetSubAssyBySupplierId(supplierId);

            if (subAssies is null) throw new CustomException("No Subassies Found!");

            var subAssy = subAssies.Where(s => s.fld_partCode.Equals(subassyCode)).FirstOrDefault();

            if (subAssy is null) throw new CustomException("No Subassy Found!");

            var subAssyDTO = _mapper.Map<SubAssyDetailsDTO>(subAssy);

            if (subAssyDTO is null)
                throw new Exception("Invalid Mapping from tbl_m_part to SubAssyDetailsDTO!");

            return subAssyDTO;
        }

        public async Task<SubAssyDetailsDTO> GetSubAssyByNameAsync(int supplierId, string subAssyName)
        {
            var subAssies = await _uow.SubAssy.GetSubAssyBySupplierId(supplierId);

            if (subAssies is null) throw new CustomException("No Subassies Found!");

            var subAssy = subAssies.Where(s => s.fld_partName.Equals(subAssyName)).FirstOrDefault();

            if (subAssy is null) throw new CustomException("No Subassy Found!");

            var subAssyDTO = _mapper.Map<SubAssyDetailsDTO>(subAssy);

            if (subAssyDTO is null)
                throw new Exception("Invalid Mapping from tbl_m_part to SubAssyDetailsDTO!");

            return subAssyDTO;
        }

        #region Add Plan
        public async Task AddPlansAsync(List<AddPlanDTO> plansDTO)
        {
            var plans = _mapper.Map<List<tbl_t_transaction>>(plansDTO);
            var transNo = await GenerateTransactionNo();

            var generatedPlans = await AddToTransactions(plans, transNo);

            await AddToLotLabel(plansDTO, generatedPlans);

            await AddToHeader(plans, transNo);
        }

        private async Task AddToLotLabel(List<AddPlanDTO> plansDTO, List<tbl_t_transaction> generatedPlans)
        {
            var subAssyId = plansDTO.Select(p => p.fld_assyId).FirstOrDefault();

            var subAssy = await _uow.SubAssy.GetAssyByIdAsync((int)subAssyId);

            var lotLabels = (from label in generatedPlans
                             select new tbl_t_lot_label
                             {
                                 fld_transactionId = label.fld_transactionNo,
                                 fld_referenceNo = plansDTO.Select(p => p.ReferenceNo).FirstOrDefault(),
                                 fld_lotNo = label.fld_subAssyLotNo,
                                 fld_partCode = subAssy.fld_partCode,
                                 fld_partName = subAssy.fld_partName,
                                 fld_qty = label.fld_qty,
                                 fld_createdBy = label.fld_createdBy,
                                 fld_createdDate = label.fld_createdDate
                             }).ToList();

            await _uow.LotLabel.AddLotLabelsAsync(lotLabels);
        }

        private async Task AddToHeader(List<tbl_t_transaction> plans, string transNo)
        {
            var header = (from trans in plans
                          select new tbl_t_transaction_header
                          {
                              TransNo = transNo,
                              SupplierId = trans.fld_supplierId,
                              LineId = trans.fld_lineId,
                              StationId = (int)trans.fld_stationId,
                              Qty = plans.Sum(_ => _.fld_qty),
                              StatusId = 0,
                              CreatedBy = trans.fld_createdBy,
                              CreatedDate = trans.fld_createdDate
                          }).FirstOrDefault();

            await _uow.THeader.AddHeaderAsync(header);

            await _uow.SaveAsync();
        }

        private async Task<List<tbl_t_transaction>> AddToTransactions(List<tbl_t_transaction> plans, string transNo)
        {
            List<tbl_t_transaction> generatedPlans = new();

            foreach (var plan in plans)
            {
                if (plan.fld_supplierId == 0 || plan.fld_lineId == 0)
                    throw new CustomException("Cannot Add Plan! Incomplete details!");

                plan.fld_transactionNo = transNo;
                plan.fld_shiftId = GetShift();
                plan.fld_statusId = 0;
                plan.fld_createdDate = DateTime.Now;
                plan.fld_subAssyLotNo = await GenerateLotNoAsync(plan.fld_supplierId, plan.fld_lineId);

                await _uow.Transaction.AddTransactionAsync(plan);

                await _uow.SaveAsync();

                generatedPlans.Add(plan);
            };

            return generatedPlans;
        }

        private async Task<string> GenerateTransactionNo()
        {
            return await _uow.Transaction.GenerateTransactionNoAsync();
        }

        private async Task<string> GenerateLotNoAsync(int supplierId, int lineId)
        {
            var lotNo = await _uow.Transaction.GenerateLotNoAsync(supplierId, lineId);

            if (lotNo is null) throw new Exception("Unable to Create Lot No! Contact Administrator!");

            return lotNo;
        }

        private int GetShift()
        {
            var currentTIme = DateTime.Now.Hour;

            return (currentTIme >= 7 && currentTIme < 19) ? (int)Shift.Day : (int)Shift.Night;
        }
        #endregion

        public async Task<List<CurrentPlanDTO>> GetCurrentPlansByLineIdAsync(int lineId)
        {
            var plans = await _uow.Transaction.GetCurrentPlansAsyncByLineId(lineId);

            if (plans is null) throw new CustomException("Invalid Line Id");

            return plans.ToList();
        }

        #region Start Process
        public async Task StartProcessAsync(AddOngoingDTO transaction)
        {
            var lineId = (int)transaction.fld_lineId;

            await AddOngoingLotAsync(transaction, (int)Status.OnGoing);

            await UpdateTransactionStatus(transaction, (int)Status.OnGoing);

            await _uow.SaveAsync();
        }

        private async Task AddOngoingLotAsync(AddOngoingDTO transaction, int? statusId)
        {
            var onGoing = _mapper.Map<tbl_t_lot_ongoing>(transaction);

            if (onGoing is null) throw new CustomException("Invalid Mapping!");

            if (statusId is null) throw new CustomException("Invalid Status Id!");

            onGoing.fld_statusId = statusId;

            await _uow.Ongoing.AddOngoingLotAsync(onGoing);
        }

        private async Task UpdateTransactionStatus(AddOngoingDTO transaction, int? statusId)
        {
            var trans = await _uow.Transaction.GetTransactionByIdAsync(transaction.TransId);

            if (trans is null) throw new CustomException("Invalid Transaction!");

            var operatorId = transaction.fld_createdBy;
            trans.fld_statusId = statusId;
            trans.fld_updatedBy = operatorId;
            trans.fld_updatedDate = DateTime.Now;

            _uow.Transaction.UpdateTransaction(trans);
        }
        #endregion

        public async Task<List<LineDDLDTO>> GetLineDataAsync(int supplierId)
        {
            var lines = await _uow.Line.GetLineDDLBySupplierIdAsync(supplierId);

            if (lines is null) throw new CustomException("Line DDL Not Found!");

            return lines.ToList();
        }

        public async Task<List<StationDDLDTO>> GetStationDataByLineAsync(int lineId)
        {
            var stations = await _uow.Station.GetStationDDLByLineIdAsync(lineId);

            if (stations is null) throw new CustomException("Station DDL Not Found!");

            return stations.ToList();
        }

        #region Delete Plan
        public async Task DeletePlanAsync(DeletePlanDTO field)
        {
            await RemoveLotFromOngoingTable(field.LotNo);

            await UpdateLotStatusToDeletedInTransaction(field);

            await _uow.SaveAsync();
        }

        //private async Task UpdateLotStatusToDeletedInHeader(string transNo)
        //{
        //    var headers = await _uow.THeader.GetHeadersByTransNoAsync(transNo);

        //    if (headers is null) throw new CustomException("Invalid Transaction No.!");

        //    headers.ToList().ForEach(_ => _.StatusId = (int)Status.Deleted);

        //    _uow.THeader.UpdateHeaders(headers);
        //}

        private async Task UpdateLotStatusToDeletedInTransaction(DeletePlanDTO field)
        {
            var transaction = await _uow.Transaction.GetTransactionByAssyLot(field.LotNo);

            if (transaction is null) throw new CustomException("Invalid Transaction No.!");

            transaction.fld_statusId = (int)Status.Deleted;
            transaction.fld_updatedBy = field.OperatorId;
            transaction.fld_updatedDate = DateTime.Now;

            _uow.Transaction.UpdateTransaction(transaction);
        }

        private async Task RemoveLotFromOngoingTable(string LotNo)
        {
            var lot = await _uow.Ongoing.GetOngoingByAssyLot(LotNo);

            if (lot is null) throw new CustomException("Invalid Transaction No.!");

            _uow.Ongoing.RemoveOnGoing(lot);
        }
        #endregion

        public async Task<string> GetPiecePartnameAsync(ValidatePieceBySupplierDTO info)
        {
            var isValid = await _uow.PiecePart.ValidatePiecepartBySupplierIdAsync(info);

            if (!isValid) throw new CustomException("Piece part Not Found!");

            var piece = await _uow.PiecePart.GetPiecePartByCode(info.PiecePartCode);

            var pieceName = piece.fld_partName;

            return pieceName;
        }

        public async Task<string> GetSubAssyNameAsync(ValidateSubAssyBySupplierDTO info)
        {
            var isValid = await _uow.SubAssy.ValidatePiecepartBySupplierIdAsync(info);

            if (!isValid) throw new CustomException("Sub-assy Not Found!");

            var subassy = await _uow.SubAssy.GetSubAssyByCode(info.AssyCode);

            var subassyName = subassy.fld_partName;

            return subassyName;
        }

        public async Task AddAssyDefectAsync(AddAssyDefectDTO dto)
        {
            var defect = _mapper.Map<tbl_t_assy_defect>(dto);

            if (defect is null)
                throw new CustomException("Invalid Mapping");

            defect.fld_createdDate = DateTime.Now;

            await _uow.AssyDefect.AddAssyDefectAsync(defect);

            await _uow.SaveAsync();
        }

        public async Task<List<DefectDTO>> GetDefectDDLAsync()
        {
            var defects = await _uow.Defect.GetAllDefectAsync();

            if (defects is null) throw new CustomException("No Defects Found!");

            var result = _mapper.Map<List<DefectDTO>>(defects);

            return result;
        }

        #region Add Transaction Details

        public async Task AddTransactionDetails(AddTransactionDetailsDTO details)
        {
            var isValid = await _uow.PiecePart.ValidatePiecepartBySupplierIdAsync(
                new ValidatePieceBySupplierDTO { PiecePartCode = details.PiecePartCode, SupplierId = details.SupplierId });

            if (!isValid) throw new CustomException("Invalid Piece Part Code!");

            var piece = await _uow.PiecePart.GetPiecePartByCode(details.PiecePartCode);

            details.fld_pieceId = piece.fld_id;          

            var result = _mapper.Map<tbl_t_transaction_detail>(details);
            result.fld_createdDate = DateTime.Now;

            await _uow.TDetails.AddTransactionDetailsAsync(result);
            await _uow.SaveAsync();
        }

        #endregion

        public async Task<SubAssyLotDetailsDTO> GetSubAssyLotDetailsByLotAsync(string assyLot)
        {
            var trans = await _uow.Transaction.GetTransactionByAssyLot(assyLot);

            var ongoing = await _uow.Ongoing.GetOngoingByAssyLot(assyLot);

            if (trans is null || ongoing is null) throw new CustomException("Invalid Sub-assy Lot!");

            var assy = await _uow.SubAssy.GetAssyByIdAsync(trans.fld_assyId);

            if (assy is null) throw new CustomException("Invalid SubAssy!");

            var dtoResult = new SubAssyLotDetailsDTO()
            {
                SubAssyCode = assy.fld_partCode,
                SubAssyname = assy.fld_partName,
                SubAssyLot = trans.fld_subAssyLotNo,
                Qty = trans.fld_qty
            };

            return dtoResult;
        }

        public async Task<int> GetCountByAssyLotAsync(string assyLot)
        {
            var onGoing = await _uow.Ongoing.GetOngoingByAssyLot(assyLot);

            if (onGoing is null) throw new CustomException("Invalid SubAssy Lot!");

            return onGoing.fld_count;
        }

        #region Trigger Increment Count
        public async Task TriggerIncrementCountAsync(string assyLot, int operatorId)
        {
            var onGoing = await _uow.Ongoing.GetOngoingByAssyLot(assyLot);

            if (onGoing is null) throw new CustomException("Invalid SubAssy Lot!");

            await IncrementCountAsync(onGoing);

            if (onGoing.fld_count > onGoing.fld_qty)
                throw new CustomException("Invalid Count!");

            if (onGoing.fld_count < onGoing.fld_qty)
                return;

            if (onGoing.fld_count == onGoing.fld_qty)
            {
                await UpdateTransStatusToFinishAsync(assyLot, operatorId);

                _uow.Ongoing.RemoveOnGoing(onGoing);

                await _uow.SaveAsync();

                throw new CustomException("Proceed to next Lot!");
            }                        
        }

        private async Task IncrementCountAsync(tbl_t_lot_ongoing onGoing)
        {
            onGoing.fld_count += 1;
            _uow.Ongoing.UpdateOnGoing(onGoing);
            await _uow.SaveAsync();
        }

        async Task UpdateTransStatusToFinishAsync(string assyLot, int operatorId)
        {
            var trans = await _uow.Transaction.GetTransactionByAssyLot(assyLot);
            trans.fld_statusId = (int)Status.Finish;
            trans.fld_updatedBy = operatorId;
            trans.fld_updatedDate = DateTime.Now;
            _uow.Transaction.UpdateTransaction(trans);
        }

        #endregion
    }
}
