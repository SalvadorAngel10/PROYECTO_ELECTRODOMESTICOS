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
        public static ProductoHandler productoHandler;
        ObservableCollection<Producto> listaproductos;

        public Facturas(ProductoHandler productoHandler)
        {
            InitializeComponent();
            
        }

        private void productosCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tablaProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
