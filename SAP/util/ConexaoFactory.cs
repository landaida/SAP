using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace SAP.util
{
    public static class ConexaoFactory
    {
        private static SqlConnection connection;
        
        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(DBConfig.cadenaConexionBD);
            }
            set
            {
                connection = value;
            }
        }

    }
}
