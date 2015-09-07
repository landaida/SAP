using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{
    class Usuario
    {
        public Usuario()
        {}
        
        public Usuario(string userId, string userName)
        {
            this.UserId = userId;
            this.U_Name = userName;
        }
        public string U_Name { get; set; }        
        public string UserId { get; set; }

        public override string ToString()
        {
            return U_Name;
        }
    }

    
}
