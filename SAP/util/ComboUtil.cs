using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
namespace SAP.util
{
    public static class ComboUtil
    {
        public static void populateComboBox(ComboBox cmb, String valueMember, String displayMember, String tableName)
        {
            SqlConnection conn = ConexaoFactory.Connection;
            SqlCommand sc = new SqlCommand("select "+valueMember+","+displayMember+" from ["+tableName+"]", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();

            List<string> result = new List<string>();

            while (reader.Read())
            {
                result.Add(reader[displayMember].ToString());
            }
            reader.Close();
            
            cmb.DataSource = result.ToArray();

            //conn.Close();
        }

      
    }
}
