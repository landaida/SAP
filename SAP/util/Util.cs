﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
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


            List<T> result = new List<T>();
            while (reader.Read())
            {
                T item = Activator.CreateInstance<T>(); ;
                

                foreach (var property in typeof(T).GetProperties())
                {   
                    
                    if (string.CompareOrdinal(property.PropertyType.FullName, "System.String") == 0)
                    {
                        item.GetType().GetProperty(property.Name).SetValue(item, reader[property.Name].ToString(), null);
                    }
                    //else if (string.CompareOrdinal(property.PropertyType.FullName, "System.") == 0)
                    //{
                    //    item.GetType().GetProperty(property.Name).SetValue(item, int.Parse(Sanitizer.GetSafeHtmlFragment(property.GetValue(item, null).ToString())), null);
                    //}
                }                
                result.Add(item);
            }
            reader.Close();
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

        public static T getValueFromQuery<T>(String query, String fieldName)
        {
            try
            {
                SqlConnection conn = ConexaoFactory.Connection;
                SqlCommand sc = new SqlCommand(query, conn);
                SqlDataReader reader;

                reader = sc.ExecuteReader();

                var value = reader.GetValue(reader.GetOrdinal(fieldName));

                reader.Close();

                return value is DBNull ? default(T) : (T)value;
            }
            catch(Exception e)
            {
                Util.AutoClosingMessageBox.Show(e.Message, "Error", 3000);
            }
            return default(T);            
        }
    }
}

public static class ControlExtension
{


}
