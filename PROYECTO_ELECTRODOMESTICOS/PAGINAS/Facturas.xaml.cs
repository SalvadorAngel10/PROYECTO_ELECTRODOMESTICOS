using PROYECTO_ELECTRODOMESTICOS.Productos;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.Facturacion;
using PROYECTO_ELECTRODOMESTICOS.ReportsData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROYECTO_ELECTRODOMESTICOS.PAGINAS
{
    /// <summary>
    /// Lógica de interacción para Facturas.xaml
    /// </summary>
    public partial class Facturas : Page
    {
        ProductoHandler productoHandler;
        Producto producto;
        Cliente cliente;
        ObservableCollection<Producto> listaproductosF;

        public Facturas(ProductoHandler productoHandler)
        {
          
            InitializeComponent();
            cliente = new Cliente();
            this.datosCliente.DataContext = cliente;
            this.productoHandler = productoHandler;
            this.comboProductos.ItemsSource = productoHandler.ProductList;
            listaproductosF = new ObservableCollection<Producto>();
            tablaProductos.ItemsSource = listaproductosF;

        }
    


        private void productosCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            producto = (Producto)comboProductos.SelectedItem;
            cantidad.DataContext = producto;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (comboProductos.SelectedItem != null)
            {
                bool productoR = false;
                if (producto != null)
                {
                    foreach (Producto p in listaproductosF)
                    {
                        if (p.Referencia == producto.Referencia)
                        {
                            productoR = true;
                            p.Cantidad = p.Cantidad + int.Parse(cantidad.Text);
                        }
                    }
                }
                if (!productoR)
                {
                    listaproductosF.Add(producto);

                }
                comboProductos.SelectedIndex = -1;
                tablaProductos.Items.Refresh();

            }
            else { MessageBox.Show("Selecciona un producto antes de introducirlo"); }

        }

        private void tablaProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (nfactura.Text != "" && cif.Text!="" && nombre.Text!="" && direccion.Text!="")
            {
                DataTable error = FacturaDBHandler.GetFacturaByFactura(nfactura.Text);
                bool facturaExiste = false;
                if (error.Rows.Count > 0)
                {
                    facturaExiste = true;
                    System.Windows.MessageBox.Show("ya existe este numero de factura,pon otro distinto");
                }



                if ((listaproductosF.Count > 0) && (nfactura.Text != "") && (cliente != null) && !facturaExiste)
                {
                    MessageBoxResult resultado = System.Windows.MessageBox.Show("¿Desea crear la factura?", "Factura", MessageBoxButton.YesNo, MessageBoxImage.Information);

                    switch (resultado)
                    {
                        case MessageBoxResult.Yes:
                            Cliente cliente = new Cliente(cif.Text, nombre.Text, direccion.Text);
                            if (!FacturaDBHandler.ClienteRepetido(cif.Text))
                            {
                                FacturaDBHandler.AddCliente(cliente);
                            }

                            FacturaDBHandler.AddFactura(cliente, listaproductosF, nfactura.Text);
                            MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
                            ReportPreview report = new ReportPreview();
                            string factura = nfactura.Text;
                            if (nfactura.Text != "")
                            {
                                bool okConsulta = report.GetFacturaByFactura(factura);
                                if (okConsulta)
                                {
                                    report.Show();
                                }
                                else
                                {
                                    System.Windows.MessageBox.Show("no se ha encontrado el registro por factura");
                                }

                            }
                            else
                            {
                                System.Windows.MessageBox.Show("es necesario insertar por una factura");
                            }

                            break;
                        case MessageBoxResult.No:
                            break;


                    }
                   

                }
            }
            else { MessageBox.Show("INTRODUZCA TODOS LOS DATOS DEL CLIENTE"); }
          
        }

        private void cif_LostFocus(object sender, RoutedEventArgs e)
        {
            DataTable repetido = FacturaDBHandler.repetido(this.cif.Text);
            if (repetido.Rows.Count>0) 
            {
                this.nombre.Text = repetido.Rows[0]["nombre"].ToString();
                this.direccion.Text = repetido.Rows[0]["direccion"].ToString();

            }

        }

        private void cif_LostMouseCapture(object sender, MouseEventArgs e)
        {
           /* var clienteTabla = FacturaDBHandler.ClienteRepetido(cif.Text)


            if (clienteTabla.Rows.Count > 0)
            {
                foreach (DataRow cliente in clienteTabla.Rows)
                {
                    //Cliente c = new Cliente();
                    cliente. = cliente["cif"].ToString();
                    cliente.nombre = cliente["nombre"].ToString();
                    cliente.direccion = cliente["direccion"].ToString();
                }
                datosCliente.DataContext = cliente;
            }
            else { }*/
        }
    }
}
