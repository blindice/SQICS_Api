using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class ValidatePiecePartDTO
    {
        [Required]
        public string PiecePartCOde { get; set; }
        [JsonIgnore]
        public int? PiecePartId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "SubAssy ID can't be zero!")]
        public int? SubAssyId { get; set; }
    }
}
