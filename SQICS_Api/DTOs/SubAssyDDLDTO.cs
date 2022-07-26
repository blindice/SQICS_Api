using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class SubAssyDDLDTO
    {
        public int SubAssyId { get; set; }

        public string SubAssyCode { get; set; }

        public string SubAssyName { get; set; }

        public int? MOST { get; set; }

        public int? SPQ { get; set; }
    }
}
