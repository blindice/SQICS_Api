using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class DeletePlanDTO
    {
        [Required]
        public string TransNo { get; set; }
        
        [Required]
        public int OperatorId { get; set; }
    }
}
