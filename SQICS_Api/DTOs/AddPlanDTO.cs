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
        [Range(1, int.MaxValue, ErrorMessage = "Supplier ID can't be zero!")]
        public int? fld_supplierId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Line ID can't be zero!")]
        public int? fld_lineId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Line ID can't be zero!")]
        public int? fld_stationId { get; set; }
        [Required]

        [Range(1, int.MaxValue, ErrorMessage = "SubAssy ID can't be zero!")]
        public int? fld_assyId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Qty can't be zero!")]
        public int? fld_qty { get; set; }
        [Required]
        public DateTime? ETimeCompletion { get; set; }

        [Required]
        public int? fld_createdBy { get; set; }
    }
}
