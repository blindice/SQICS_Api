using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Helper.POCO
{
    public class SearchParameters
    {
        public string TransactionNo { get; set; }

        public DateTime ProdDate { get; set; }

        public int Shift { get; set; }

        public string SubAssyCode { get; set; }
    }
}
