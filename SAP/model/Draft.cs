﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{    
    class Draft
    {
        private int docNum;
        private DateTime docDate;
        private string cardCode;
        private Double docTotal;
        private string comments;

        public int DocNum{ get; set;}
        public DateTime DocDate { get; set; }
        public string CardCode { get; set; }
        public Double DocTotal { get; set; }
        public string Comments { get; set; }
    }
}