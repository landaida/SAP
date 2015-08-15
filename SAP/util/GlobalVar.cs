using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;

namespace SAP.util
{
    public static class GlobalVar
    {

        public static Company empresa;

        public static void inicializarEmpresa()
        {
            int res = 0;
            if (empresa == null)
            {
                empresa = new Company();
                empresa.DbServerType = BoDataServerTypes.dst_MSSQL2008;
                empresa.Server = "WINSERVER";
                empresa.CompanyDB = "SBO_SideragroNueva";
                empresa.UserName = "emerson";
                empresa.Password = "0104452";
                empresa.DbUserName = "sa";
                empresa.DbPassword = "raposa28@09";

                res = empresa.Connect();
            }

            if (res != 0)
            {
                Console.WriteLine(empresa.GetLastErrorDescription());
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
