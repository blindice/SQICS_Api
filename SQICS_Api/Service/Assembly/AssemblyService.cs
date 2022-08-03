﻿using AutoMapper;
using SQICS_Api.DTOs;
using SQICS_Api.Helper.CustomException;
using SQICS_Api.Model;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Service.Assembly
{
    public class AssemblyService : IAssemblyService
    {
        IUnitOfWork _uow;
        IMapper _mapper;

        public AssemblyService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<SubAssyByOperatorIdDTO> GetOperatorDetailsAsync(string operatorId)
        {
            var @operator = await _uow.Operator.GetOperatorByEmpId(operatorId);

            if (@operator is null) throw new CustomException("Operator Not Found!");

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

        public async Task AddPlansAsync(List<AddPlanDTO> plansDTO)
        {
            var plans = _mapper.Map<List<tbl_t_transaction>>(plansDTO);
            var transNo = await GenerateTransactionNo();
            try
            {
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
                };
            }catch(Exception ex)
            {
                throw new CustomException(ex.Message);
            }
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
            
            return (currentTIme >= 7 && currentTIme < 19) ? 1 : 2;
        }
    }
} 
