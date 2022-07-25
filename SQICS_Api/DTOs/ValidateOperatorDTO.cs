using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class ValidateOperatorDTO
    {
        [JsonIgnore]
        public int? OperatorId { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public int? SubAssyId { get; set; }
        [Required]
        public int? StationId { get; set; }
    }
}
