using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class DefectInquiryDTO
    {
        public string PiecePartCode { get; set; }

        public string PiecePartName { get; set; }

        public string PiecePartLot { get; set; }

        public string SubAssyCode { get; set; }

        public string SubAssyName { get; set; }

        public string SubAssyLot { get; set; }

        public string DefectName { get; set; }

        public string ShiftId { get; set; }

        public string Remarks { get; set; }

        public string ProdDate { get; set; }
    }
}
