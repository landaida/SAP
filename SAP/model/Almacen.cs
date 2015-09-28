using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{
    class Almacen
    {
        public Almacen()
        {}
        
        public Almacen(string whsCode, string whsName)
        {
            this.WhsCode = whsCode;
            this.WhsName = whsName;
        }
        public string WhsName { get; set; }        
        public string WhsCode { get; set; }

        public override string ToString()
        {
            return WhsName;
        }
    }

    
}
