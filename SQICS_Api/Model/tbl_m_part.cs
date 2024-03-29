﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Index(nameof(fld_partCode), Name = "partCode_unique", IsUnique = true)]
    public partial class tbl_m_part
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
        public int? fld_spq { get; set; }
        public int? fld_most { get; set; }
        [StringLength(50)]
        public string fld_remarks { get; set; }
        [Required]
        public bool? fld_active { get; set; }
        public bool fld_isAssy { get; set; }
        public int fld_createdBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fld_createdDate { get; set; }
        public int? fld_updatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_updatedDate { get; set; }
    }
}
