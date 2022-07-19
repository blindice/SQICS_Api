using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Index(nameof(fld_transactionNo), Name = "transNo_unique", IsUnique = true)]
    public partial class tbl_t_transaction
    {
        [Key]
        public int fld_id { get; set; }
        public int fld_supplierId { get; set; }
        public int fld_lineId { get; set; }
        [Required]
        [StringLength(12)]
        public string fld_transactionNo { get; set; }
        public int fld_assyId { get; set; }
        public int fld_qty { get; set; }
        public int fld_createdBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fld_createdDate { get; set; }
        public int? fld_updatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_updatedDate { get; set; }
        public DateTime ETimeCompletion { get; set; }
    }
}
