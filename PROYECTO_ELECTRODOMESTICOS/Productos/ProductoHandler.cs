using PROYECTO_ELECTRODOMESTICOS.XML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_ELECTRODOMESTICOS.Productos
{
    public class ProductoHandler
    {

        public ObservableCollection<Producto> ProductList { get; set; }

        public ProductoHandler()
        {
            this.ProductList = new ObservableCollection<Producto>();
            Actualizarxml();
        }

        public void Addproduct(Producto producto)
        {
            ProductList.Add(producto);
        }
        public void Modifyproduct(Producto producto, int pos)
        {
            ProductList[pos] = producto;
        }
        public void Removeproduct(int pos)
        {
            ProductList.RemoveAt(pos);
        }

        public void Actualizarxml()
        {
            this.ProductList = Class1.LoadProductos();
        }
    }
}
