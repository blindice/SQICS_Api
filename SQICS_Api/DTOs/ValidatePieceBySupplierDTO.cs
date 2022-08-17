using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class ValidatePieceBySupplierDTO
    {
        public int SupplierId { get; set; }

        public string PiecePartCode { get; set; }
    }
}
