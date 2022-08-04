using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Index(nameof(fld_name), Name = "name_unique", IsUnique = true)]
    public partial class tbl_m_station
    {
        [Key]
        public int fld_id { get; set; }
        public int fld_supplierId { get; set; }
        public int fld_lineId { get; set; }
        public int fld_userId { get; set; }
        [Required]
        [StringLength(50)]
        public string fld_name { get; set; }
        public int fld_order { get; set; }
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
