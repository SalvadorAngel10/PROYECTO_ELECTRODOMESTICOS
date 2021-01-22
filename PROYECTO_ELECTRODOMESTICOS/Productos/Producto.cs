using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_ELECTRODOMESTICOS.Productos
{
    public class Producto : ICloneable
    {

        public String Referencia{set; get; }
        public String Categoria { set; get; }
        public String Marca { set; get; }
        public String Clase { set; get; }
        public float Precio { set; get; }
        public int stock { set; get; }
        public DateTime fechaAlta { set; get; }

        public Producto(string Referencia,string Categoria,string Marca, string Clase,float Precio ,int stock, DateTime fechaAlta)
        {

            this.Referencia = Referencia;
            this.Categoria = Categoria;
            this.Marca = Marca;
            this.Clase = Clase;
            this.Precio = Precio;
            this.stock = stock;
            this.fechaAlta = DateTime.Now;

        }
        public Producto()
        {
            this.Referencia = "";
            this.Categoria = "";
            this.Marca = "";
            this.Clase = "";
            this.Precio = 0;
            this.stock = 0;
            this.fechaAlta = DateTime.Now;
        }

        public override string ToString()
        {
            return Referencia;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public String GetAllValues()
        {
            return Referencia +""+Categoria+""+Marca+""+Clase+ " " + Precio + " " + stock + " " + fechaAlta;
        }
    }
}
