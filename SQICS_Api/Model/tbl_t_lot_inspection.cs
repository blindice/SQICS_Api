using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Table("tbl_t_lot_inspection")]
    public partial class tbl_t_lot_inspection
    {
        [Key]
        public int fld_id { get; set; }
        public int fld_supplierId { get; set; }
        [Required]
        [StringLength(30)]
        public string fld_partCode { get; set; }
        [Required]
        [StringLength(30)]
        public string fld_partName { get; set; }
        [Required]
        [StringLength(50)]
        public string fld_assyLot { get; set; }
        [Required]
        [StringLength(50)]
        public string fld_referenceNo { get; set; }
        public int fld_qty { get; set; }
        [Required]
        [StringLength(50)]
        public string fld_remarks { get; set; }
        public int fld_inspectionMode { get; set; }
        public int fld_inspectedQty { get; set; }
        public bool fld_judgement { get; set; }
        public int fld_shiftId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fld_prodDate { get; set; }
        public int fld_createdBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fld_createdDate { get; set; }
        public bool? fld_updateFlag { get; set; }
        public int? fld_updatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_updatedDate { get; set; }
        public bool? fld_deleteFlag { get; set; }
        public int? fld_deletedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_deletedDate { get; set; }
    }
}
