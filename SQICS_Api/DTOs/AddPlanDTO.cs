using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class AddPlanDTO
    {
        public int fld_supplierId { get; set; }
        public int fld_lineId { get; set; }
        public int fld_assyId { get; set; }
        public int fld_qty { get; set; }
        public int fld_createdBy { get; set; }
        public DateTime ETimeCompletion { get; set; }
    }
}
