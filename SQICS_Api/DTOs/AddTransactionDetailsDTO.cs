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
        public int fld_stationId { get; set; }
        [Required]
        public string fld_employeeId { get; set; }
        [Required]
        public string fld_pieceId { get; set; }
        [Required]
        public string fld_lotNo { get; set; }
        [Required]
        public string fld_referenceNo { get; set; }
        [Required]
        public int fld_qty { get; set; }

        [Required]
        public int fld_createdBy { get; set; }
    }
}
