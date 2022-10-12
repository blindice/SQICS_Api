using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Keyless]
    [Table("tbl_m_inspection_mode")]
    public partial class tbl_m_inspection_mode
    {
        public int fld_id { get; set; }
        [StringLength(20)]
        public string fld_description { get; set; }
        public int? fld_value { get; set; }
        public int? fld_createdBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_createdDate { get; set; }
    }
}
