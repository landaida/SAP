using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using SAP.model;
namespace SAP.util
{
    public static class ComboUtil
    {
        public static void populateComboBox(ComboBox cmb, String valueMember, String displayMember, String tableName, Type type)
        {
            if(typeof(Cliente) == type)
            {
                List<Cliente> lista = Util.getGenericList<Cliente>(valueMember, displayMember, tableName).ToList<Cliente>();
                cmb.DataSource = lista;
                
            } else if (typeof(Producto) == type)
            {
                List<Producto> lista = Util.getGenericList<Producto>(valueMember, displayMember, tableName).ToList<Producto>();
                cmb.DataSource = lista;
            }
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;


        }

        public static void confgComboBox<T>(ComboBox cmb, String valueMember, String displayMember, List<T> lista)
        {
            cmb.DataSource = lista;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
        }

        public static void confgComboBox<T>(DataGridViewComboBoxColumn cmb, String valueMember, String displayMember, List<T> lista)
        {
            cmb.DataSource = lista;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
        }

    }
}
