using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Table("tbl_m_bom")]
    public partial class tbl_m_bom
    {
        [Key]
        public int fld_id { get; set; }
        public int fld_assyId { get; set; }
        public int fld_pieceId { get; set; }
        public int fld_qty { get; set; }
        public int fld_createdBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fld_creatdDate { get; set; }
        public int? fld_updatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_updatedDate { get; set; }
    }
}
