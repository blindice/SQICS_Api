using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class PrintDTO
    {
        [Required]
        public string LotNo { get; set; }

        [Required]
        public int? OperatorId { get; set; }

        [Required]
        public int? LineId { get; set; }
    }
}
