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
using System.Xml.Linq;

namespace PROYECTO_ELECTRODOMESTICOS.PAGINAS
{
    /// <summary>
    /// Lógica de interacción para NewOrModifyProducto.xaml
    /// </summary>
    public partial class NewOrModifyProducto : Page
    {

        private XDocument xml = XDocument.Load("../../XML/XMLFile1.xml");
        public ProductoHandler productoHandler;
        public Producto producto;
        public bool verify;
        public NewOrModifyProducto(ProductoHandler productoHandler)
        {
            this.productoHandler = productoHandler;
        }

        private bool Validation()
        {

            bool validate = true;

            foreach (UIElement element in productGrid.Children)
            {

                if (element is TextBox)
                {
                    TextBox textBox = (TextBox)element;

                    if (textBox.Text.Equals(""))
                    {
                        textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                        validate = false;
                    }
                    else
                    {
                        textBox.BorderBrush = new SolidColorBrush(Colors.LightGray);
                    }
                }

            }

            return validate;
        } //validacion
        //constructor de nuevo
        public NewOrModifyProducto(string title, ProductoHandler productoHandler)
        {
            InitializeComponent();
            Combo();
            productoNM.Text = title;
            this.productoHandler = productoHandler;
            this.verify = false;
            producto = new Producto();
            this.productGrid.DataContext = producto;
        }

        //constructor de modificar
        public NewOrModifyProducto(string title, ProductoHandler productoHandler, Producto producto)
        {
            InitializeComponent();
            Combo();
            productoNM.Text = title;
            this.productoHandler = productoHandler;
            this.producto = producto;
            this.productGrid.DataContext = producto;
            this.verify = true;

        }

        private void Combo()
        {
            var listaProductos = xml.Root.Elements("Categoria").Attributes("idCategoria");

            for (int i = 0; i < listaProductos.Count(); i++)
            {
                ComboCategoria.Items.Add(listaProductos.ElementAt(i).Value);
            }
        }

        private void txt_tipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboMarca.Items.Clear();
            var modeloList = xml.Root.Elements("Categoria").ElementAt(ComboCategoria.SelectedIndex).Elements("Marca").Attributes("nombre");

            for (int i = 0; i < modeloList.Count(); i++)
            {
                ComboMarca.Items.Add(modeloList.ElementAt(i).Value);
            }
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (verify)
            {
                //productoHandler.Modifyproduct(producto, pos);
                Class1.editarProducto(producto);
                MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());

            }
            else
            {

                String Referencia = tReferencia.Text;
                String Categoria = tCategoria.Text;
                String Marca = tMarca.Text;
                String Clase = ComboClase.Text;
                float Precio =float.Parse(tPrecio.Text);
                int stock =int.Parse( tStock.Text);
                DateTime fechaAlta = (DateTime)tFecha.SelectedDate;
               


                if (Validation())
                {
                    MessageBoxResult resultado = MessageBox.Show(
                    "Referencia: " + Referencia + "\n" +
                    "Categoria: " + Categoria + "\n" +
                    "Marca:" +Marca + "\n" +
                    "Clase: " + Clase + "\n" +
                    "Precio:" +Precio + "\n" +
                    "Stock: " + stock + "\n" +
                    "Fecha de alta: " + fechaAlta + "\n\n" +
                    "¿ESTOS DATOS SON CORRECTOS?",
                    "registro usuarios",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Question);

                    switch (resultado)
                    {
                        case MessageBoxResult.Yes:
                            MessageBox.Show("se ha refistrado bien");
                            Producto producto = new Producto(Referencia,Categoria ,Marca,Clase ,Precio, stock, fechaAlta);
                            Class1.addXMLProduct(producto);
                            MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
                            //MostrarUsuario mostrarUsuario = new MostrarUsuario(usuario);
                            //mostrarUsuario.Show();
                            break;
                        case MessageBoxResult.No:
                            break;
                        case MessageBoxResult.Cancel:
                            break;

                    }
                }
                else
                {
                    label.Content = "INTRODUZCA BIEN LA INFORMACION DEL PRODUCTO";
                    label.Visibility = Visibility.Visible;
                }
            }
        }

        private void checkCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (ComboCategoria.IsVisible)
            {
                ComboCategoria.Visibility = Visibility.Hidden;
                ComboMarca.Visibility = Visibility.Hidden;
                tCategoria.Visibility = Visibility.Visible;
                tMarca.Visibility = Visibility.Visible;
                checkCategoria.IsEnabled = true;
            }
            else
            {
                ComboCategoria.Visibility = Visibility.Visible;
                ComboMarca.Visibility = Visibility.Visible;
                tCategoria.Visibility = Visibility.Hidden;
                tMarca.Visibility = Visibility.Hidden;
                checkCategoria.IsEnabled = false;
            }
        }
        private void checkMarca_Click(object sender, RoutedEventArgs e)
        {
            if (ComboMarca.IsVisible)
            {

                ComboMarca.Visibility = Visibility.Hidden;

                tMarca.Visibility = Visibility.Visible;
                checkMarca.IsEnabled = true;
            }
            else
            {

                ComboMarca.Visibility = Visibility.Visible;
                checkMarca.IsEnabled = false;
            }

        }

        
    }
}
