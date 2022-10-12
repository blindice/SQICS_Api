using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class AddQCInspectionDTO
    {
        [Required]
        public int? SupplierId { get; set; }

        [Required]
        public int? PieceId { get; set; }

        [Required]
        public string PartName { get; set; }

        [Required]
        public string SubassyLot { get; set; }

        [Required]
        public string RefNo { get; set; }

        [Required]
        public int? Qty { get; set; }

        [Required]
        public string Remarks { get; set; }

        [Required]
        public int? InspectionMode { get; set; }

        [Required]
        public int? InspectionQty { get; set; }

        [Required]
        public bool Judgement { get; set; }
    }
}
