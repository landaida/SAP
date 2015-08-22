using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;

namespace SAP.util
{
    public static class DBConfig
    {
        public const String DBUser = "sa";
        //public const String DBPassword = "raposa28@09";        
        public const String DBPassword = "py2008";
        public const String DBName = "SBO_SideragroNueva";

        public const BoDataServerTypes DBServerType = BoDataServerTypes.dst_MSSQL2008;

        public const String BOUser = "emerson";
        public const String BOPassword = "0104452";

        //public const String Server = "WINSERVER";
        public const String Server = "cameras.myvnc.com";        
    }
}
