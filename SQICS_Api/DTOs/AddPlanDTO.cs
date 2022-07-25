using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class AddPlanDTO
    {
        [Required]
        public int? fld_supplierId { get; set; }
        [Required]
        public int? fld_lineId { get; set; }
        [Required]
        public int? fld_assyId { get; set; }
        [Required]
        public int? fld_qty { get; set; }
        [Required]
        public DateTime? ETimeCompletion { get; set; }
    }
}
