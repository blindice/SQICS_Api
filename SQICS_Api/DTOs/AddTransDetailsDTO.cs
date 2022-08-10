using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class AddTransDetailsDTO
    {
        public int? TransId { get; set; }

        public int? StationId { get; set; }

        public int? EmployeeId { get; set; }

        public int? PieceId { get; set; }

        public string LotNo { get; set; }

        public string RefNo { get; set; }

        public int? Qty { get; set; }

        public int? CreatedBy { get; set; }
    }
}
