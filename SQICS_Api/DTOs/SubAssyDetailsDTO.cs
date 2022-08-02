using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class SubAssyDetailsDTO
    {

        public int fld_id { get; set; }

        public string fld_partName { get; set; }

        public string fld_partCode { get; set; }

        public int fld_spq { get; set; }

        public int fld_most { get; set; }
    }
}
