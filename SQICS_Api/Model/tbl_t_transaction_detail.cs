using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    public partial class tbl_t_transaction_detail
    {
        [Key]
        public int fld_id { get; set; }
        [Required]
        [StringLength(12)]
        public string fld_transactionId { get; set; }
        public int fld_stationId { get; set; }
        [Required]
        [StringLength(25)]
        public string fld_employeeId { get; set; }
        public int fld_pieceId { get; set; }
        [Required]
        [StringLength(50)]
        public string fld_lotNo { get; set; }
        [Required]
        [StringLength(50)]
        public string fld_referenceNo { get; set; }
        public int fld_qty { get; set; }
        public bool fld_operatorFlag { get; set; }
        public bool fld_judgementFlag { get; set; }
        public int fld_createdBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fld_createdDate { get; set; }
        public int? fld_updatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_updatedDate { get; set; }
    }
}
