using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace SAP.util
{
    public static class ConexaoFactory
    {
        private static SqlConnection connection;
        
        public static SqlConnection initSQLConection() 
        {            
            connection = new SqlConnection(DBConfig.cadenaConexionBD);            
            connection.Open();
            Console.WriteLine("ok create Conexion with DB");
            return connection;            
        }

        public static SqlConnection Connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }

    }
}
