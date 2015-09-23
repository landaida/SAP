using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{
    class Condicion
    {
        public Condicion()
        {}
        
        public Condicion(string groupNum, string pymntGroup)
        {
            this.GroupNum = groupNum;
            this.PymntGroup = pymntGroup;
        }
        public string PymntGroup { get; set; }        
        public string GroupNum { get; set; }

        public override string ToString()
        {
            return PymntGroup;
        }
    }

    
}
