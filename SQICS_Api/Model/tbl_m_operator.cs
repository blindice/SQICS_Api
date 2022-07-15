using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Table("tbl_m_operator")]
    [Index(nameof(fld_employeeId), Name = "employeeId_unique", IsUnique = true)]
    public partial class tbl_m_operator
    {
        [Key]
        public int fld_id { get; set; }
        public int fld_supplierId { get; set; }
        [Required]
        [StringLength(25)]
        public string fld_employeeId { get; set; }
        [Required]
        [StringLength(100)]
        public string fld_lastName { get; set; }
        [Required]
        [StringLength(100)]
        public string fld_firstName { get; set; }
        [StringLength(100)]
        public string fld_middleName { get; set; }
        [Required]
        public bool? fld_active { get; set; }
        public int fld_createdBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fld_createdDate { get; set; }
        public int? fld_updatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_updatedDate { get; set; }
    }
}
