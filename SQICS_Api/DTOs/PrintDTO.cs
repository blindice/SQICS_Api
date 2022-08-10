using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class PrintDTO
    {
        public string LotNo { get; set; }

        public int? OperatorId { get; set; }

        public int? LineId { get; set; }
    }
}
