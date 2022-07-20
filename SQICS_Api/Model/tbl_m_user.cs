using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Index(nameof(fld_username), Name = "username_Unique", IsUnique = true)]
    public partial class tbl_m_user
    {
        [Key]
        public int fld_id { get; set; }
        [Required]
        [StringLength(25)]
        public string fld_username { get; set; }
        [Required]
        [StringLength(100)]
        public string fld_name { get; set; }
        [Required]
        [StringLength(100)]
        public string fld_email { get; set; }
        public int fld_role { get; set; }
        public int? fld_supplierId { get; set; }
        [Required]
        [StringLength(300)]
        public string fld_password { get; set; }
        [Required]
        [StringLength(100)]
        public string fld_salt { get; set; }
        [Required]
        public bool? fld_resetPasswordFlag { get; set; }
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
