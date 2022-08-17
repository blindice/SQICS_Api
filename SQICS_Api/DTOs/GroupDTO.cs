using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class GroupDTO
    {
        [Required]
        public string ConnectionId { get; set; }

        [Required]
        public string GroupName { get; set; }
    }
}
