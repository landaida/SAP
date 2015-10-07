using System;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace SAP.util
{
    public static class ReportUtils
    {


        public static readonly String reportPath = AppDomain.CurrentDomain.BaseDirectory + Properties.Settings.Default.reportPath;

        public static void reportLoad(string reportName, string docEntry)
        {
            string filePath = reportPath + reportName;
            ReportDocument crReport = new ReportDocument();
            if (File.Exists(filePath))
            {
                crReport.Load(filePath);
                //set parameters for your report  
                crReport.SetParameterValue("DocKey@", docEntry);
                crReport.PrintOptions.PrinterName = "";
                crReport.DataSourceConnections[0].SetConnection(GlobalVar.Empresa.Server, GlobalVar.Empresa.CompanyDB, false);
                crReport.DataSourceConnections[0].SetLogon(GlobalVar.Empresa.DbUserName, DBConfig.DBPassword);
                crReport.PrintToPrinter(1, false, 1, 1);
            }

            /*
            string test = "select * from tablename";
            DataSet testds = new DataSet();
            SqlConnection cnn = ConexaoFactory.Connection;
            SqlCommand testcmd = new SqlCommand(test, cnn);
            testcmd.CommandType = CommandType.Text;
            SqlDataAdapter testda = new SqlDataAdapter(testcmd);
            testda.Fill(testds, "testttable");
            cnn.Open();

            ReportDocument myReportDocument;
            myReportDocument = new ReportDocument();
            myReportDocument.Load(@filePath);
            myReportDocument.SetDataSource(testds);
            myReportDocument.SetDatabaseLogon("username", "pwd");
            //crystalReportViewer1.ReportSource = myReportDocument;
            //crystalReportViewer1.DisplayToolbar = true;
            PrintDialog print = new PrintDialog();
            DialogResult dr = print.ShowDialog();
            myReportDocument.PrintOptions.PrinterName = print.PrinterSettings.PrinterName;
            myReportDocument.PrintToPrinter(print.PrinterSettings.Copies, print.PrinterSettings.Collate, print.PrinterSettings.FromPage, print.PrinterSettings.ToPage);*/
        }

        public static void printReport(string reportName)
        {
            string filePath = reportPath + reportName;

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.RefreshReport += reportLoaded;
            cryRpt.Load(@filePath);

            TableLogOnInfo crTableLogonInfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables crTables;

            crConnectionInfo.ServerName = "myServer";
            crConnectionInfo.DatabaseName = "myDatabase";
            crConnectionInfo.UserID = "myUser";
            crConnectionInfo.Password = "myPass";

            crTables = cryRpt.Database.Tables;

            foreach (Table table in crTables)
            {
                crTableLogonInfo = table.LogOnInfo;
                crTableLogonInfo.ConnectionInfo = crConnectionInfo;
                table.ApplyLogOnInfo(crTableLogonInfo);
            }

            //cryRpt.SetParameterValue("@report_type", type);

            cryRpt.Refresh();
        }

        public static void reportLoaded(object sender, EventArgs e)
        {
            PrintDialog print = new PrintDialog();
            DialogResult dr = print.ShowDialog();

            if (dr == DialogResult.OK)
            {
                ReportDocument cryRpt = (ReportDocument)sender;
                cryRpt.PrintOptions.PrinterName = print.PrinterSettings.PrinterName;
                cryRpt.PrintToPrinter(print.PrinterSettings.Copies, print.PrinterSettings.Collate, print.PrinterSettings.FromPage, print.PrinterSettings.ToPage);
            }
        }

    }
}
