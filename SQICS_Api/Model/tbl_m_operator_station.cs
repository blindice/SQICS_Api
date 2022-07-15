using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQICS_Api.Model
{
    [Table("tbl_m_operator_station")]
    public partial class tbl_m_operator_station
    {
        [Key]
        public int fld_id { get; set; }
        public int fld_operatorId { get; set; }
        public int fld_stationId { get; set; }
        public int fld_createdBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime fld_createdDate { get; set; }
        public int? fld_updatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? fld_updatedDate { get; set; }
    }
}
