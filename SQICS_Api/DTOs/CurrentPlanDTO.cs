﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.DTOs
{
    public class CurrentPlanDTO
    {

        public int Id { get; set; }

        public string TransNo { get; set; }
        public string LotNo { get; set; }

        public string RefNo { get; set; }

        public int Qty { get; set; }

        public string PartCode { get; set; }

        public string PartName { get; set; }

        public string Status { get; set; }

        public int Count { get; set; }

        public string Remarks { get; set; }

        public int Most { get; set; }
    }
}
