using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{
    class Cliente
    {
        public Cliente()
        {}
        
        public Cliente(string cardCode, string cardName)
        {
            this.CardCode = cardCode;
            this.CardName = cardName;
        }
        public string CardName { get; set; }        
        public string CardCode { get; set; }
    }
}
