using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class UpdateOrCreatePartColorDTO
    {
        [Required]
        public int fld_supplierId { get; set; }

        [Required]
        public string fld_partCode { get; set; }

        [Required]
        public string fld_partName { get; set; }

        [Required]
        public string fld_Color { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
