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
        //public const String DBUser = "sa";
        public static readonly String DBUser = Properties.Resources.DBUser;
        //public static readonly String DBPassword = "raposa28@09";
        public static readonly String DBPassword = Properties.Resources.DBPassword;
        //public const String DBPassword = "py2008";
        //public static readonly String DBName = "SBO_SideragroNueva";
        public static readonly String DBName = Properties.Resources.DBName;
        //public const String DBName = "ZPortal";
        
        public static readonly BoDataServerTypes DBServerType = Properties.Resources.DBServerType.Equals("MSSQL2008") ? BoDataServerTypes.dst_MSSQL2008 : BoDataServerTypes.dst_MSSQL2012;

        //public static readonly String BOUser = "emerson";
        public static readonly String BOUser = Properties.Resources.BOUser;
        //public const String BOUser = "guilherm";
        //public static readonly String BOPassword = "0104452";
        public static readonly String BOPassword = Properties.Resources.BOPassword;
        //public const String BOPassword = "belgo";
        //public static readonly String Server = "winserver";
        public static readonly String Server = Properties.Resources.Server;
        //public const String Server = "cameras.myvnc.com:30015";
        //public const String Server = "181.40.121.26";
        //public const String Server = "192.168.1.106";

        public static readonly String cadenaConexionBD = @"Data Source=" + DBConfig.Server + ";Initial Catalog=" + DBConfig.DBName + ";User ID=" + DBConfig.DBUser + ";Password=" + DBConfig.DBPassword;
        //public const String cadenaConexionBD = @"Data Source=.\SQLEXPRESS;Initial Catalog=" + DBConfig.DBName + ";User ID=" + DBConfig.DBUser + ";Password=" + DBConfig.DBPassword;
    }
}
