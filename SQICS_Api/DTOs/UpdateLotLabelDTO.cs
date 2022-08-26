using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class UpdateLotLabelDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "ID can't be zero!")]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CreatedBy can't be zero!")]
        public int CreatedBy { get; set; }
    }
}
