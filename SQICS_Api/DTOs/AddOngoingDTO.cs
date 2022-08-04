using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class AddOngoingDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Trans Id can't be zero!")]
        public int TransId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Line ID can't be zero!")]
        public int? fld_lineId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Station ID can't be zero!")]
        public int? fld_stationId { get; set; }
        [Required]
        public string fld_trans { get; set; }
        [Required]
        public string fld_lotNo { get; set; }
        [Required]
        public string fld_partCode { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Qty can't be zero!")]
        public int? fld_qty { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Created By can't be zero!")]
        public int fld_createdBy { get; set; }
    }
}
