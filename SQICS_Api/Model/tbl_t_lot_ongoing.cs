using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Table("tbl_t_lot_ongoing")]
    public partial class tbl_t_lot_ongoing
    {
        [Key]
        public Guid fld_id { get; set; }
        public int fld_lineId { get; set; }
        public int fld_stationId { get; set; }
        [StringLength(50)]
        public string fld_trans { get; set; }
        [StringLength(50)]
        public string fld_lotNo { get; set; }
        [StringLength(50)]
        public string fld_partCode { get; set; }
        public int? fld_qty { get; set; }
        public int? fld_statusId { get; set; }
    }
}
