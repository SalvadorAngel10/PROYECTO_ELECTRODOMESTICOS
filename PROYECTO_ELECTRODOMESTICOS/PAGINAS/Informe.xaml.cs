using PROYECTO_ELECTRODOMESTICOS.Productos;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.Facturacion;
using PROYECTO_ELECTRODOMESTICOS.ReportsData;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROYECTO_ELECTRODOMESTICOS.PAGINAS
{
    /// <summary>
    /// Lógica de interacción para Informe.xaml
    /// </summary>
    public partial class Informe : Page
    {
         ProductoHandler productoHandler;

        public Informe(ProductoHandler productoHandler)
        {
            InitializeComponent();
            this.productoHandler = productoHandler;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Butons.IsVisible)
            {
                Butons.Visibility = Visibility.Hidden;
            }
            else { Butons.Visibility = Visibility.Visible; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dni.IsVisible)
            {
                dni.Visibility = Visibility.Hidden;
            }
            else { dni.Visibility = Visibility.Visible; }

            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (fechas.IsVisible)
            {
                fechas.Visibility = Visibility.Hidden;
            }
            else { fechas.Visibility = Visibility.Visible; }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (factura.IsVisible)
            {
                factura.Visibility = Visibility.Hidden;
            }
            else { factura.Visibility = Visibility.Visible; }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow.myNavigationFrame.NavigationService.Navigate(new Facturas(productoHandler));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ReportPreview report = new ReportPreview();
            string cif = nif.Text;
            if (nif.Text != "")
            {
                bool okConsulta = report.GetFacturaCif(cif);
                if (okConsulta) { report.Show(); } else { System.Windows.MessageBox.Show("no se ha encontrado el registro por cif"); }

            }
            else 
            {
                System.Windows.MessageBox.Show("es necesario insertar por cif");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
           
            if (startDate.Text != "" && endDate.Text != "")
            {
                string fechainicio = startDate.Text;
                string fechafin = endDate.Text;
                ReportPreview report= new ReportPreview();
                bool okConsulta = report.MostrarInformeFecha(fechainicio,fechafin);

                if (okConsulta)
                {
                    report.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("No existen registros para las fechas seleccionadas");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Selecciona Fecha Inicio y Fecha Fin");

            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            
            
                ReportPreview report = new ReportPreview();
                string factura = Nfacturas.Text;
                if (Nfacturas.Text != "")
                {
                    bool okConsulta = report.GetFacturaByFactura(factura);
                    if (okConsulta) { report.Show(); } else { System.Windows.MessageBox.Show("no se ha encontrado el registro por factura"); }

                }
                else
                {
                    System.Windows.MessageBox.Show("es necesario insertar por una factura");
                }
           
        }
    }
}
