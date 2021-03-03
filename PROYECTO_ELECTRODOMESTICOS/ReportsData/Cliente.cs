using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_ELECTRODOMESTICOS.ReportsData
{
    class Cliente
    {
        public String cif { set; get; }
        public String nombre { set; get; }
        public String direccion { set; get; }


        public Cliente(string cif, string nombre, string direccion)
        {
            this.cif = cif;
            this.nombre = nombre;
            this.direccion = direccion;
        }

        public Cliente() { }

    }
}
