using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Model
{
    public class TransactionDetailsDTO
    {
        public string StationName { get; set; }

        public string EmployeeId { get; set; }

        public string PiecePartCode { get; set; }

        public string PiecePartName { get; set; }

        public string LotNo { get; set; }

        public int Qty { get; set; }

        public bool Judgement { get; set; }
    }
}
