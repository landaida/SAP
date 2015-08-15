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
        public static List<String> populateComboBox(ComboBox cmb, String valueMember, String displayMember, String tableName)
        {
            SqlConnection conn = ConexaoFactory.getSQLConection();
            SqlCommand sc = new SqlCommand("select "+valueMember+","+displayMember+" from ["+tableName+"]", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add(valueMember, typeof(string));
            dt.Columns.Add(displayMember, typeof(string));
            dt.Load(reader);

            List<String> result = new List<string>();

            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                result.Add(row[0].ToString()+"-"+ row[1].ToString());
            }

            cmb.ValueMember = valueMember;
            cmb.DisplayMember = displayMember;
            cmb.DataSource = dt;

            conn.Close();

            return result;
        }

      
    }
}
