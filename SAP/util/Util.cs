using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SAP.model;
using SAPbobsCOM;

namespace SAP.util
{
    public static class Util
    {
        public static IEnumerable<T> getGenericList<T>(String valueMember, String displayMember, String tableName)
        {
            SqlConnection conn = ConexaoFactory.Connection;
            SqlCommand sc = new SqlCommand("select " + valueMember + "," + displayMember + " from [" + tableName + "]", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();

            if (typeof(T) == typeof(Cliente))
            {
                List<Cliente> result = new List<Cliente>();
                while (reader.Read())
                {                    
                    result.Add(new Cliente(reader[valueMember].ToString(), reader[displayMember].ToString()));
                }
                reader.Close();
                return result.OfType<T>();
            } else if (typeof(T) == typeof(Producto))
            {
                List<Producto> result = new List<Producto>();
                while (reader.Read())
                {
                    result.Add(new Producto(reader[valueMember].ToString(), reader[displayMember].ToString()));
                }
                reader.Close();
                return result.OfType<T>();
            }





            return null;
            //conn.Close();
        }
    }
}
