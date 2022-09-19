using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class SubAssyLotDetailsDTO
    {
        public int TransId { get; set; }
        public string SubAssyCode { get; set; }

        public string SubAssyname { get; set; }

        public string SubAssyLot { get; set; }

        public int Qty { get; set; }
    }
}
