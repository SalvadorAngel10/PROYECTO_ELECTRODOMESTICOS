using PROYECTO_ELECTRODOMESTICOS.Productos;
using PROYECTO_ELECTRODOMESTICOS.XML;
using System;
using System.Collections.Generic;
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
   
    public partial class ProductoShow : Page
    {
        public ProductoHandler ProductoHandler;
        public Producto producto;
        public int pos;
        public ProductoShow(ProductoHandler productoHandler)
        {
            InitializeComponent();
            this.ProductoHandler = productoHandler;
            comboProduct.DataContext = productoHandler;
            pos = comboProduct.SelectedIndex;
            buttonsPanel.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Class1.editarProducto(producto);
            MainWindow.myNavigationFrame.NavigationService.Navigate(new NewOrModifyProducto("MODIFICAR ELECTRODOMÉSTICO", ProductoHandler, (Producto)producto.Clone()));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Class1.RemoveProducto(producto);
            MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
        }

        private void comboProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            producto = (Producto)comboProduct.SelectedItem;
            ProductoDataGrid.DataContext = producto;
            pos = comboProduct.SelectedIndex;
            buttonsPanel.Visibility = Visibility.Visible;
        }
    }
}
