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
        public string TransactionNo { get; set; }
        [Required]
        public int StationId { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public string PiecePartId { get; set; }
        [Required]
        public string LotNo { get; set; }
        [Required]
        public string RefNo { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
