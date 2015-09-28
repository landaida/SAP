using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SAPbobsCOM;
using System.Windows.Forms;
using SAP.forms.util;
using System.Data;

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
            conn.Open();
            SqlCommand sc = new SqlCommand("select " + valueMember + "," + displayMember + " from [" + tableName + "] " + where, conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();


            List<T> result = new List<T>();
            while (reader.Read())
            {
                T item = Activator.CreateInstance<T>();
                

                foreach (var property in typeof(T).GetProperties())
                {   
                    
                    if (string.CompareOrdinal(property.PropertyType.FullName, "System.String") == 0)
                    {
                        item.GetType().GetProperty(property.Name).SetValue(item, reader[property.Name].ToString(), null);
                    }
                    else if (string.CompareOrdinal(property.PropertyType.FullName, "System.Int16") == 0 )
                    {
                        item.GetType().GetProperty(property.Name).SetValue(item, Convert.ToInt16(reader[property.Name]), null);
                    }
                    else if (string.CompareOrdinal(property.PropertyType.FullName, "System.Int32") == 0)
                    {
                        item.GetType().GetProperty(property.Name).SetValue(item, Convert.ToInt32(reader[property.Name]), null);
                    }
                    else if (string.CompareOrdinal(property.PropertyType.FullName, "System.Int64") == 0)
                    {
                        item.GetType().GetProperty(property.Name).SetValue(item, Convert.ToInt64(reader[property.Name]), null);
                    }
                }                
                result.Add(item);
            }
            reader.Close();
            conn.Close();
            return result.OfType<T>();

            
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

        public static T getValueFromQuery<T>(String query)
        {
            try
            {
                SqlConnection conn = ConexaoFactory.Connection;
                conn.Open();
                SqlCommand sc = new SqlCommand(query, conn);

                var value = sc.ExecuteScalar();

                conn.Close();
                return value is DBNull ? default(T) : (T)value;
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return default(T);            
        }


        public static int createUpdateFromQuery(String query, List<SqlParameter> parameters)
        {
            int recordsAffected = 0;

            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = ConexaoFactory.Connection;// <== lacking
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddRange(parameters.ToArray());

                    recordsAffected = command.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    Util.showMessage(e.Message);
                }
                finally
                {
                    command.Connection.Close();
                }                        
            }
            return recordsAffected;

            /*  Ayuda a crear un CRUD manual usando el metodo mas arriba

            SELECT ','+COLUMN_NAME, ',@'+COLUMN_NAME, data_type
            ,'new SqlParameter() {ParameterName = "@'+COLUMN_NAME+'", SqlDbType = SqlDbType.'+case when t.DATA_TYPE in ('int', 'smallint') then 'Int' when t.DATA_TYPE = 'datetime' then 'DateTime' else 'NVarChar' end +', Value= wddCode},'
            FROM INFORMATION_SCHEMA.COLUMNS t
            WHERE TABLE_NAME = 'OAIB'


            */
        }


        public static void showMessage(String msg, String title = "Aviso", MessageBoxButtons btns = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(msg, title, btns, icon);
        }

        public static Double getItemPrice(String cardCode, String itemCode, DateTime dateTime)
        {
            //// Get an initialized SBObob object
            SBObob oSBObob = (SAPbobsCOM.SBObob)GlobalVar.Empresa.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
            //// Get an initialized Recordset object
            Recordset oRecordSet = (SAPbobsCOM.Recordset)GlobalVar.Empresa.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            oRecordSet = oSBObob.GetItemPrice(cardCode, itemCode, 1, dateTime);
            System.Console.WriteLine(oRecordSet.Fields.Item(0).Value + " " + oRecordSet.Fields.Item(1).Value);
            return oRecordSet.Fields.Item(0).Value;
        }



}


}

public static class ControlExtension
{


}
