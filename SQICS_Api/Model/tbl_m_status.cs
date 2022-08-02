using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Table("tbl_m_status")]
    public partial class tbl_m_status
    {
        [Key]
        public int fld_id { get; set; }
        public int fld_statusCode { get; set; }
        [Required]
        [StringLength(30)]
        public string fld_statusName { get; set; }
    }
}
