using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    public partial class tbl_t_transaction
    {
        [Key]
        public int fld_transactionId { get; set; }
        public int fld_supplierId { get; set; }
        public int fld_lineId { get; set; }
        public int? fld_stationId { get; set; }
        [Required]
        [StringLength(30)]
        public string fld_transactionNo { get; set; }
        [StringLength(50)]
        public string fld_subAssyLotNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fld_prodDate { get; set; }
        public int fld_shiftId { get; set; }
        public int fld_assyId { get; set; }
        public int fld_qty { get; set; }
        public int? fld_statusId { get; set; }
        [StringLength(50)]
        public string fld_remarks { get; set; }
        public int fld_createdBy { get; set; }
        public DateTime fld_createdDate { get; set; }
        public int? fld_updatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_updatedDate { get; set; }
        public DateTime ETimeCompletion { get; set; }
    }
}
