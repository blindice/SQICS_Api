using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class AddTransactionDetailsDTO
    {
        [Required]
        public string fld_transactionId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Station ID can't be zero!")]
        public int? fld_stationId { get; set; }
        [Required]
        public string fld_employeeId { get; set; }

        public int fld_pieceId { get; set; }
        [Required]
        public string fld_lotNo { get; set; }
        public string fld_referenceNo { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Qty can't be zero!")]
        public int? fld_qty { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Created By can't be zero!")]
        public int? fld_createdBy { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public string PiecePartCode { get; set; }
    }
}
