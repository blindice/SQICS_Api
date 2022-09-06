using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class DefectInquiryParams
    {
        [Required]
        public int? SupplierId { get; set; }

        [Required]
        public DateTime? DateFrom { get; set; }

        [Required]
        public DateTime? DateTo { get; set; }

        public int? DefectId { get; set; }

        public int? ShiftId { get; set; }

    }
}
