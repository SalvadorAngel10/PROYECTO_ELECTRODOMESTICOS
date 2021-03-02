using PROYECTO_ELECTRODOMESTICOS.Productos;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.Facturacion;
using PROYECTO_ELECTRODOMESTICOS.ReportsData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private void tablaProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listaproductosF.Count > 0 && nfactura.Text != "" && cliente != null) 
            {
                FacturaDBHandler.AddCliente(cliente);
                FacturaDBHandler.AddFactura(cliente,listaproductosF,nfactura.Text);
                MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
            }
        }
    }
}
