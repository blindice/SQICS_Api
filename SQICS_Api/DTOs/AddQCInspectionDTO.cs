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
        public int? fld_supplierId { get; set; }

        [Required]
        public int? fld_pieceId { get; set; }

        [Required]
        public string fld_partName { get; set; }

        [Required]
        public string fld_assyLot { get; set; }

        [Required]
        public string fld_referenceNo { get; set; }

        [Required]
        public int? fld_qty { get; set; }

        [Required]
        public string fld_remarks { get; set; }

        [Required]
        public int? fld_inspectionMode { get; set; }

        [Required]
        public int? fld_inspectedQty { get; set; }

        [Required]
        public bool fld_judgement { get; set; }
    }
}
