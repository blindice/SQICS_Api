using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Table("tbl_t_transaction_header")]
    public partial class tbl_t_transaction_header
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TransNo { get; set; }
        public int SupplierId { get; set; }
        public int LineId { get; set; }
        public int StationId { get; set; }
        public int Qty { get; set; }
        public int StatusId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
