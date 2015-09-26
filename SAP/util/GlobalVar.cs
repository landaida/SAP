using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using System.Threading;

namespace SAP.util
{
    public static class GlobalVar
    {

        private static Company empresa;
        public static bool isReady = false;
        public static String cardCode;
        public static DateTime datetime;

        public static void inicializarEmpresa()
        {
            int res = 0;
            if (empresa == null)
            {
                empresa = new Company();
                empresa.DbServerType = DBConfig.DBServerType;
                empresa.Server = DBConfig.Server;
                empresa.CompanyDB = DBConfig.DBName;
                empresa.UserName = DBConfig.BOUser;
                empresa.Password = DBConfig.BOPassword;
                empresa.DbUserName = DBConfig.DBUser;
                empresa.DbPassword = DBConfig.DBPassword;
                res = empresa.Connect();                
            }

            if (res != 0)
            {
                Console.WriteLine(empresa.GetLastErrorDescription());
            }
            else
            {
                isReady = true;
                Console.WriteLine("ok create Conexion with SAP licensing server");
            }
        }

        public static Company Empresa
        {
            get
            {                
                return empresa;                
            }
            set
            {
                empresa = value;
            }
        }

    }
}
