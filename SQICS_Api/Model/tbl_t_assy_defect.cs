using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    public partial class tbl_t_assy_defect
    {
        [Key]
        public int fld_id { get; set; }
        [Required]
        [StringLength(30)]
        public string fld_pieceCode { get; set; }
        [Required]
        [StringLength(30)]
        public string fld_pieceLot { get; set; }
        [Required]
        [StringLength(30)]
        public string fld_assyCode { get; set; }
        [Required]
        [StringLength(30)]
        public string fld_assyLot { get; set; }
        public int fld_defectId { get; set; }
        public string fld_remarks { get; set; }
        public int fld_qty { get; set; }
        public int fld_createdBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fld_createdDate { get; set; }
    }
}
