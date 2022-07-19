using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class PlanDTO
    {
        public int Id { get; set; }

        public string TransactionNo { get; set; }

        public string SubAssyCode { get; set; }

        public string SubAssyName { get; set; }

        public int? Qty { get; set; }

        public DateTime? ETimeCompletion { get; set; } 
    }
}
