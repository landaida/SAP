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
            Util.cursorShow();
            //SqlConnection conn = new SqlConnection(@"Data Source="+ DBConfig.Server+ ";Initial Catalog="+DBConfig.DBName+";User ID="+ DBConfig.DBUser+ ";Password="+ DBConfig.DBPassword);
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=" + DBConfig.DBName + ";User ID=" + DBConfig.DBUser + ";Password=" + DBConfig.DBPassword);
            connection.Open();
            Console.WriteLine("ok create Conexion with DB");
            Util.cursorHidden();
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
