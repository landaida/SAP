using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{
    class Aprobador
    {
        public Aprobador()
        {}
        
        public Aprobador(int wstCode, int userId)
        {
            this.WstCode = wstCode;
            this.UserId = userId;
        }
        public int UserId { get; set; }        
        public int WstCode { get; set; }

        
    }

    
}
