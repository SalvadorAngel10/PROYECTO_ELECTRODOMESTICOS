using PROYECTO_ELECTRODOMESTICOS.Productos;
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
        public Producto producto;
        ObservableCollection<Producto> listaproductosF;

        public Facturas(ProductoHandler productoHandler)
        {
          
            InitializeComponent();
            this.productoHandler = productoHandler;
            this.comboProductos.ItemsSource = productoHandler.ProductList;
            listaproductosF = new ObservableCollection<Producto>();
            tablaProductos.ItemsSource = listaproductosF;

        }
    


        private void productosCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = (Producto)comboProductos.SelectedItem;
            listaproductosF.Add(producto);

        }

        private void tablaProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
