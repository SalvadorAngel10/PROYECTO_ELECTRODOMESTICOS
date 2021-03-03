using Microsoft.Reporting.WinForms;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.Facturacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROYECTO_ELECTRODOMESTICOS.ReportsData
{
    /// <summary>
    /// Lógica de interacción para ReportPreview.xaml
    /// </summary>
    public partial class ReportPreview : Window
    {
        public ReportPreview()
        {
            InitializeComponent();
        }

        public bool GetFacturaCif(string cif) 
        {
            bool okConsulta = false;
            DataTable tablaInforme = FacturaDBHandler.GetFacturaByCif(cif);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = tablaInforme;
            myReportView.LocalReport.ReportPath="../../ReportsData/Factura.rdlc";
            myReportView.LocalReport.DataSources.Add(rds);
            myReportView.RefreshReport();
            if (tablaInforme.Rows.Count > 0)
            {
                okConsulta = true;
            }
          

            return okConsulta;
        }

        public bool GetFacturaByFactura(string factura)
        {
            bool okConsulta = false;
            DataTable tablaInforme = FacturaDBHandler.GetFacturaByFactura(factura);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet3";
            rds.Value = tablaInforme;
            myReportView.LocalReport.ReportPath = "../../ReportsData/FacturaN.rdlc";
            myReportView.LocalReport.DataSources.Add(rds);
            myReportView.RefreshReport();
            if (tablaInforme.Rows.Count > 0)
            {
                okConsulta = true;
            }


            return okConsulta;
        }

        public bool MostrarInformeFecha(String fecha1, String fecha2)
        {
            DataTable informe =FacturaDBHandler.GetDataFechas(fecha1, fecha2);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet2";
            rds.Value = informe;
            myReportView.LocalReport.ReportPath = "../../ReportsData/FacturasFechas.rdlc";
            myReportView.LocalReport.DataSources.Add(rds);
            myReportView.RefreshReport();

            bool okConsulta = false;
            if (informe.Rows.Count > 0)
            {
                okConsulta = true;
            }
            return okConsulta;
        }
    }
}
