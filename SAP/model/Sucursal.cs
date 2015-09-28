using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{
    class Sucursal
    {
        public Sucursal()
        {}
        
        public Sucursal(string ocrCode, string prcCode)
        {
            this.OcrCode = ocrCode;
            this.PrcCode = prcCode;
        }
        public string PrcCode { get; set; }        
        public string OcrCode { get; set; }

        public override string ToString()
        {
            return PrcCode;
        }
    }

    
}
