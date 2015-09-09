using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{
    class Vendedor
    {
        public Vendedor()
        {}
        
        public Vendedor(string userId, string userName)
        {
            this.SlpCode = userId;
            this.SlpName = userName;
        }
        public string SlpName { get; set; }        
        public string SlpCode { get; set; }

        public override string ToString()
        {
            return SlpName;
        }
    }

    
}
