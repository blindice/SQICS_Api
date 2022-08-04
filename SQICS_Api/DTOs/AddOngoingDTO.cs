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
        public int TransId { get; set; }
        [Required]
        public int? fld_lineId { get; set; }
        [Required]
        public int? fld_stationId { get; set; }
        [Required]
        public string fld_trans { get; set; }
        [Required]
        public string fld_lotNo { get; set; }
        [Required]
        public string fld_partCode { get; set; }
        [Required]
        public int? fld_qty { get; set; }
    }
}
