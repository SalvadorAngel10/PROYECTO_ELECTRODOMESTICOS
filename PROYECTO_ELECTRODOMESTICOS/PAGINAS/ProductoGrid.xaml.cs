using PROYECTO_ELECTRODOMESTICOS.Productos;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.MySQLData;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.LocalImages;
using PROYECTO_ELECTRODOMESTICOS.XML;
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
using System.Xml.Linq;

namespace PROYECTO_ELECTRODOMESTICOS.PAGINAS
{
    
    public partial class ProductoGrid : Page
    {
        ProductoHandler ProductoHandler;
        private XDocument xml = Class1.ReturnXDocument();
        //private XDocument xml = XDocument.Load("../../XML/XMLFile1.xml");
        private ObservableCollection<Producto> listaFiltrada;

        public ProductoGrid(ProductoHandler productHandler)
        {
            InitializeComponent();
            this.ProductoHandler = productHandler;
            UpdateProductList();
            InitCategoryCombo();

        }

        public ProductoGrid()
        {
        }

        private void InitCategoryCombo()
        {
            categoryCombo.Items.Add("Todas ...");
            var listaCategoriasXML = xml.Root.Elements("Categoria").Attributes("idCategoria");

            foreach (XAttribute categoriaXML in listaCategoriasXML)
            {

                categoryCombo.Items.Add(categoriaXML.Value);
            }
            categoryCombo.SelectedIndex = 0;
        }

        private void UpdateProductList()
        {
            ProductoHandler.Actualizarxml();
            categoryCombo.SelectedIndex = 0;
            busquedaTextBox.Text = "";
            listaFiltrada = new ObservableCollection<Producto>(ProductoHandler.ProductList);
            myDataGrid.ItemsSource = ProductoHandler.ProductList;
            myDataGrid.DataContext = ProductoHandler.ProductList;
            myDataGrid.Items.Refresh();
           
        }

        private void categoryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categoryCombo.SelectedIndex == 0)
            {

                UpdateProductList();

            }
            else
            {

                listaFiltrada.Clear();


                foreach (Producto product in ProductoHandler.ProductList)
                {

                    if (product.Categoria.Equals((string)categoryCombo.SelectedItem))
                    {

                        listaFiltrada.Add(product);
                    }
                }

                myDataGrid.ItemsSource = listaFiltrada;
                myDataGrid.DataContext = listaFiltrada;
                myDataGrid.Items.Refresh();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<Producto> nuevaListaFiltrada = new ObservableCollection<Producto>();
            foreach (Producto product in listaFiltrada)
            {

                if (product.GetAllValues().Contains(busquedaTextBox.Text))
                {

                    nuevaListaFiltrada.Add(product);

                }
            }
            myDataGrid.ItemsSource = nuevaListaFiltrada;
            myDataGrid.DataContext = nuevaListaFiltrada;
            myDataGrid.Items.Refresh();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Producto product = (Producto)myDataGrid.SelectedItem;
            
            MainWindow.myNavigationFrame.NavigationService.Navigate(new NewOrModifyProducto("MODIFICAR ELECTRODOMÉSTICO", ProductoHandler, product));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Desea Borrarlo?", "Borrar", MessageBoxButton.YesNo, MessageBoxImage.Information);

            switch (resultado)
            {
                case MessageBoxResult.Yes:
                    Producto product = (Producto)myDataGrid.SelectedItem;
                    Class1.RemoveProducto(product);
                    UpdateProductList();
                    ImageDBHandler.deleteElectrodomestico(product);
                    LocalImageDBHandler.RemoveData(product.Referencia);


                    break;
                case MessageBoxResult.No:
                    break;


            }
         
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateProductList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Desea realizar estos cambios en la base de datos?", "Publicar", MessageBoxButton.YesNo, MessageBoxImage.Information);

            switch (resultado)
            {
                case MessageBoxResult.Yes:
                    Producto producto = (Producto)myDataGrid.SelectedItem;
                    if (producto.publish == false)
                    {

                        ImageDBHandler.addElectrodomestico(producto);

                        producto.publish = true;


                    }
                    else
                    {

                        ImageDBHandler.deleteElectrodomestico(producto);
                        producto.publish = false;


                    }
                    Class1.editarProducto(producto);
                    UpdateProductList();


                    break;
                case MessageBoxResult.No:
                    break;


            }
           


        }
    }
}
