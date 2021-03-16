using PROYECTO_ELECTRODOMESTICOS.PAGINAS;
using PROYECTO_ELECTRODOMESTICOS.Productos;
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

namespace PROYECTO_ELECTRODOMESTICOS
{
    public partial class MainWindow : Window
    {
        public static Frame myNavigationFrame;
        public static ProductoHandler productoHandler;

        public MainWindow()
        {
            InitializeComponent();
            myNavigationFrame = myFrame;
            productoHandler = new ProductoHandler();
        }

    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Botones.IsVisible)
            {
                Botones.Visibility = Visibility.Hidden;
            }
            else { Botones.Visibility = Visibility.Visible; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new NewOrModifyProducto("NUEVO ELECTRODOMÉSTICO",productoHandler));
        }

       /* private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            productoHandler.Actualizarxml();
            myNavigationFrame.NavigationService.Navigate(new ProductoShow(productoHandler));
        }*/

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new ProductoGrid(productoHandler));

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new MainPage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new Informe(productoHandler));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }
    }
}
