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
            else
            {

            }

            return okConsulta;
        }
    }
}
