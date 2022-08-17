using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class AddAssyDefectDTO
    {
        [Required]
        public string fld_pieceCode { get; set; }
        [Required]
        public string fld_pieceLot { get; set; }
        [Required]
        public string fld_assyCode { get; set; }
        [Required]
        public string fld_assyLot { get; set; }
        [Required]
        public int? fld_defectId { get; set; }
        [Required]
        public string fld_remarks { get; set; }
        [Required]
        public int? fld_qty { get; set; }
        [Required]
        public int? fld_createdBy { get; set; }
    }
}
