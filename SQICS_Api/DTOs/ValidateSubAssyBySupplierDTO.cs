using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class ValidateSubAssyBySupplierDTO
    {
        public int SupplierId { get; set; }

        public string PieceCode { get; set; }

        public string AssyCode { get; set; }
    }
}
