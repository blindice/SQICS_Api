using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Model
{
    public class AddPlanDTO
    {
        public string SubAssyCode { get; set; }
        public int SupplierId { get; set; }

        public int LineId { get; set; }

        public int TransactionNo { get; set; }

        public int AssyId { get; set; }

        public int? Qty { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ETimeCompletion { get; set; }
    }
}
