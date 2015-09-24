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
        public const String DBPassword = "raposa28@09";
        //public const String DBPassword = "py2008";
        public const String DBName = "SBO_SideragroNueva";
        //public const String DBName = "ZPortal";

        public const BoDataServerTypes DBServerType = BoDataServerTypes.dst_MSSQL2008;

        public const String BOUser = "emerson";
        //public const String BOUser = "guilherm";
        public const String BOPassword = "0104452";
        //public const String BOPassword = "belgo";
        public const String Server = "winserver";
        //public const String Server = "cameras.myvnc.com:30015";
        //public const String Server = "181.40.121.26";
        //public const String Server = "192.168.1.106";

        public const String cadenaConexionBD = @"Data Source=" + DBConfig.Server + ";Initial Catalog=" + DBConfig.DBName + ";User ID=" + DBConfig.DBUser + ";Password=" + DBConfig.DBPassword;
        //public const String cadenaConexionBD = @"Data Source=.\SQLEXPRESS;Initial Catalog=" + DBConfig.DBName + ";User ID=" + DBConfig.DBUser + ";Password=" + DBConfig.DBPassword;
    }
}
