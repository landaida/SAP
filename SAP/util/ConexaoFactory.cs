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
        public static SqlConnection getSQLConection() 
        {
            SqlConnection conn = new SqlConnection(@"Data Source="+ DBConfig.Server+ ";Initial Catalog="+DBConfig.DBName+";User ID="+ DBConfig.DBUser+ ";Password="+ DBConfig.DBPassword);
            conn.Open();           
            return conn;
        }

    }
}
