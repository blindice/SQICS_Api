using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class SubAssyByOperatorIdDTO
    {
        public int OperatorId { get; set; }

        public int SupplierId { get; set; }

        public string OperatorName { get; set; }

        public string SubAssyName { get; set; }

        public string SubAssyCode { get; set; }
    }
}
