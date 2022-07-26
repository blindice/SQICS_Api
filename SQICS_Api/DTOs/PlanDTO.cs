using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class PlanDTO
    {
        public int Id { get; set; }

        public string TransactionNo { get; set; }

        public DateTime ProdDate { get; set; }

        private string _shift;

        public string Shift { 
            get 
            {
                return _shift;
            }
            set
            {
                _shift = value.ToString() switch
                {
                    "1" => "Day Shift",
                    "2" => "Night Shift",
                    _ => "Not Set"
                };
            }
        }

        public string SubAssyCode { get; set; }

        public string SubAssyName { get; set; }

        public int? Qty { get; set; }

        public DateTime? ETimeCompletion { get; set; } 
    }
}
