using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Table("tbl_t_lot_label")]
    public partial class tbl_t_lot_label
    {
        [Key]
        public int fld_id { get; set; }
        public int fld_transactionId { get; set; }
        [Required]
        [StringLength(50)]
        public string fld_referenceNo { get; set; }
        [Required]
        [StringLength(50)]
        public string fld_lotNo { get; set; }
        [Required]
        [StringLength(25)]
        public string fld_partCode { get; set; }
        [Required]
        [StringLength(100)]
        public string fld_partName { get; set; }
        public int fld_qty { get; set; }
        [Required]
        [StringLength(50)]
        public string fld_remarks { get; set; }
        public int? fld_modelId { get; set; }
        [StringLength(100)]
        public string fld_modelName { get; set; }
        public bool fld_printed { get; set; }
        public bool fld_reprinted { get; set; }
        public int fld_createdBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fld_createdDate { get; set; }
        public int? fld_updatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_updatedDate { get; set; }
    }
}
