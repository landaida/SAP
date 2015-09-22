using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SAP.model;
using SAPbobsCOM;
using System.Windows.Forms;
using SAP.forms.util;

namespace SAP.util
{
    public static class Util
    {
        public static readonly SplashScreen splashScreen = new SplashScreen();

        public static IEnumerable<T> getGenericList<T>(String valueMember, String displayMember, String tableName, String where = "")
        {
            
            if(where != null && where.Trim().Length != 0)
            {
                where = " where 1 = 1 " + where;
            }
            SqlConnection conn = ConexaoFactory.Connection;
            SqlCommand sc = new SqlCommand("select " + valueMember + "," + displayMember + " from [" + tableName + "] " + where, conn);
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
            } else if (typeof(T) == typeof(Usuario))
            {
                List<Usuario> result = new List<Usuario>();
                while (reader.Read())
                {
                    result.Add(new Usuario(reader[valueMember].ToString(), reader[displayMember].ToString()));
                }
                reader.Close();
                return result.OfType<T>();
            }
            else if (typeof(T) == typeof(Vendedor))
            {
                List<Vendedor> result = new List<Vendedor>();
                while (reader.Read())
                {
                    result.Add(new Vendedor(reader[valueMember].ToString(), reader[displayMember].ToString()));
                }
                reader.Close();
                return result.OfType<T>();
            }





            return null;
            //conn.Close();
        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow(null, _caption);
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        public static void showSplashScreen(Form parentForm, String label = "")
        {
            if(label.Trim().Length > 0 )
                Util.splashScreen.setLabel(label);

            parentForm.BeginInvoke(new Action(() => Util.splashScreen.ShowDialog()));


            //Util.showForm(Util.splashScreen, parentForm, true);
        }

        public static void hideSplashScreen(Form parentForm)
        {
            parentForm.Invoke(new Action(Util.splashScreen.Hide));
            //Util.splashScreen.Hide();
        }

        public static void showForm(Form childForm, Form parentForm, bool dialog = false)
        {
            
            if (dialog)
                childForm.ShowDialog();
            else
            {
                childForm.MdiParent = parentForm;
                parentForm.IsMdiContainer = true;
                childForm.Show();
            }
                
        }

        public static T getValueFromQuery<T>(String query, String fieldName)
        {
            
            SqlConnection conn = ConexaoFactory.Connection;
            SqlCommand sc = new SqlCommand(query, conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();

            var value = reader.GetValue(reader.GetOrdinal(fieldName));

            reader.Close();

            return value is DBNull ? default(T) : (T)value;
            
        }
    }
}

public static class ControlExtension
{


}
