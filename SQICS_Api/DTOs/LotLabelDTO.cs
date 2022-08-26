using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class LotLabelDTO
    {
        public string fld_transactionId { get; set; }

        public string fld_referenceNo { get; set; }

        public string fld_lotNo { get; set; }

        public string fld_partCode { get; set; }

        public string fld_partName { get; set; }

        public string fld_remarks { get; set; }

        public int? fld_updatedBy { get; set; }

        public DateTime? fld_updatedDate { get; set; }
    }
}
