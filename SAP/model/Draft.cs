using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{    
    class Draft
    {
        /*private int docNum;
        private int docEntry;
        private DateTime docDate;
        private string cardCode;
        private Double docTotal;
        private string comments;
        private string docStatus;
        private string wddStatus;*/

        public int DocNum{ get; set;}
        public int DocEntry { get; set; }
        public DateTime DocDate { get; set; }
        public string CardCode { get; set; }
        public Double DocTotal { get; set; }
        public string Comments { get; set; }
        public string DocStatus { get; set; }
        public string WddStatus { get; set; }
    }
}
