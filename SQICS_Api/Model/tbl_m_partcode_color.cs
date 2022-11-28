using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Table("tbl_m_partcode_color")]
    public partial class tbl_m_partcode_color
    {
        [Key]
        public int fld_id { get; set; }
        public int fld_supplierId { get; set; }
        [Required]
        [StringLength(25)]
        public string fld_partCode { get; set; }
        [Required]
        [StringLength(100)]
        public string fld_partName { get; set; }
        [Required]
        [StringLength(7)]
        public string fld_Color { get; set; }
        public int? fld_CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_CreatedDate { get; set; }
        public int? fld_UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_UpdatedDate { get; set; }
    }
}
