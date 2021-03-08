using PROYECTO_ELECTRODOMESTICOS.Productos;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.Facturacion.FacturaDS;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.Facturacion.FacturaDS.FacturasDataSetTableAdapters;
using PROYECTO_ELECTRODOMESTICOS.ReportsData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.Facturacion
{
    class FacturaDBHandler
    {
        public static ClienteTableAdapter clienteTableAdapter = new ClienteTableAdapter();
        public static facturaTableAdapter facturaTableAdapter = new facturaTableAdapter();
        public static producto_facturaTableAdapter producto_FacturaTable = new producto_facturaTableAdapter();
        public static FacturasDataSet facturasDataSet = new FacturasDataSet();
        public static InformeTableAdapter InformeTableAdapter = new InformeTableAdapter();
        public static DataTable1TableAdapter DataTable1TableAdapter = new DataTable1TableAdapter();

        public static void AddCliente(Cliente cliente) 
        {
            clienteTableAdapter.Insert(cliente.cif,cliente.nombre,cliente.direccion);
        }

        public static void AddFactura(Cliente cliente, ObservableCollection<Producto> listaProducto, string refFactura) 
        {
            facturaTableAdapter.Insert(refFactura,cliente.cif,DateTime.Today.Date);
            foreach (Producto producto in listaProducto) 
            {
                producto_FacturaTable.Insert(producto.Referencia, refFactura,producto.Categoria, producto.Cantidad, producto.Precio);
            }
            
        }

        public static bool ClienteRepetido(string cif) 
        {
            DataTable dataTable = clienteTableAdapter.GetDataRepetido(cif);
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        public static DataTable repetido(string cif) 
        {
            return clienteTableAdapter.GetDataRepetido(cif);
        }

        public static DataTable GetFacturaByCif(string cif) 
        {
            return InformeTableAdapter.GetDataByCif(cif);
        }

        public static DataTable GetFacturaByFactura(string factura)
        {
            return InformeTableAdapter.GetDataByRefFactura(factura);
        }

        public static DataTable PorCif(string cif) 
        {
            return DataTable1TableAdapter.GetDataByCif1(cif);
        }
        public static DataTable GetDataFechas(String fecha1, String fecha2)
        {

            return InformeTableAdapter.GetDataByFecha(fecha1, fecha2);
        }
        public static DataTable GetDataFechas1(String fecha1, String fecha2)
        {

            return DataTable1TableAdapter.GetDataByFecha1(fecha1, fecha2);
        }



    }
}
