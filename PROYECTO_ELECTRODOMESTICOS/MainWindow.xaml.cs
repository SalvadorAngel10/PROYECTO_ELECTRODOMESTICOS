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
using System.Windows.Forms;
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
           
            myNavigationFrame.NavigationService.Navigate(new NewOrModifyProducto("NUEVO ELECTRODOMÉSTICO", productoHandler));

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
            MessageBoxResult resultado = System.Windows.MessageBox.Show("¿Desea volver al menu principal?", "Volver", MessageBoxButton.YesNo, MessageBoxImage.Information);

            switch (resultado)
            {
                case MessageBoxResult.Yes:

                    myNavigationFrame.NavigationService.Navigate(new MainPage());

                    break;
                case MessageBoxResult.No:
                    break;


            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = System.Windows.MessageBox.Show("¿Desea salir de la aplicaion?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Information);

            switch (resultado)
            {
                case MessageBoxResult.Yes:

                    this.Close();

                    break;
                case MessageBoxResult.No:
                    break;


            }
         
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            
            myNavigationFrame.NavigationService.Navigate(new Informe(productoHandler));

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
           
           Help.ShowHelp(null,"help/help1.chm");
        }
    }
}
