using PROYECTO_ELECTRODOMESTICOS.Productos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROYECTO_ELECTRODOMESTICOS.XML
{ 
    public class Class1
    {
        private static XDocument xml;
        public static Producto producto;
        private static XElement xmlCategoria;
        private static XElement xmlModelo;

        public static void LoadXMl() { xml = XDocument.Load("../../XML/XMLFile1.xml"); }
        private static void saveXML()
        {
            xml.Save("../../XML/XMLFile1.xml");
        }

        public static bool existsRef(string referencia)
        {
            LoadXMl();
            bool exists = false;

            foreach (var referenciaXML in xml.Root.Elements("Categoria").Elements("Marca").Elements("Electrodomestico").Attributes("Referencia"))
            {
                if (referenciaXML.Value==referencia)
                {
                    exists = true;
                    break;
                }
                else
                {
                    exists = false;
                }

            }
            return exists;
        }


        private static void AddCategoria(Producto p)
        {
            var listaCAtegorias = xml.Root.Elements("Categoria").Attributes("idCategoria");
            bool isNewCategory = true;
            foreach (XAttribute categoria in listaCAtegorias)
            {
                if (categoria.Value.Equals(p.Categoria))
                {
                    xmlCategoria = categoria.Parent;
                    isNewCategory = false;
                    break;
                }
                else
                {
                    xmlCategoria = new XElement("Categoria", new XAttribute("idCategoria", p.Categoria));
                    xmlModelo = new XElement("Marca", new XAttribute("nombre", producto.Marca));
                    isNewCategory = true;
                }
            }
            if (isNewCategory)
            {
                xmlCategoria.Add(xmlModelo);
                xml.Root.Add(xmlCategoria);
            }
        }
        public static void addXMLProduct(Producto p)
        {
            producto = p;
            LoadXMl();
            AddCategoria(p);
            addModelo();
            crearProducto();
            saveXML();
        }

        private static void addModelo()
        {
            bool isNewModelo = true;
            foreach (XAttribute marca in xmlCategoria.Elements("Marca").Attributes("nombre"))
            {
                if (marca.Value.Equals(producto.Marca))
                {
                    xmlModelo = marca.Parent;
                    isNewModelo = false;
                    break;
                }
                else
                {
                    xmlModelo = new XElement("Marca", new XAttribute("nombre", producto.Marca));
                    isNewModelo = true;
                }
            }
            if (isNewModelo) { xmlCategoria.Add(xmlModelo); }
        }

        public static void crearProducto()
        {
            XElement xmlProducto = new XElement("Electrodomestico",new XAttribute("Referencia",producto.Referencia), 
            new XAttribute("Precio", producto.Precio),new XAttribute("Clase",producto.Clase),new XAttribute("Stock", producto.stock), new XAttribute("Fecha", producto.fechaAlta),new XAttribute("publish",producto.publish));
            xmlModelo.Add(xmlProducto);
        }

        public static ObservableCollection<Producto> LoadProductos()
        {
            ObservableCollection<Producto> productiList = new ObservableCollection<Producto>();
            LoadXMl();
            var listaProductos = xml.Root.Elements("Categoria").Elements("Marca").Elements("Electrodomestico");
            foreach (XElement productoxml in listaProductos)
            {
               
                producto = new Producto();
                producto.Referencia = productoxml.Attribute("Referencia").Value;
                producto.Categoria = productoxml.Parent.Parent.Attribute("idCategoria").Value;
                producto.Marca = productoxml.Parent.Attribute("nombre").Value;
                producto.Clase = productoxml.Attribute("Clase").Value;
                producto.Precio=float.Parse( productoxml.Attribute("Precio").Value);
                producto.stock =int.Parse( productoxml.Attribute("Stock").Value);
                producto.fechaAlta =DateTime.Parse(productoxml.Attribute("Fecha").Value);
                producto.publish = bool.Parse(productoxml.Attribute("publish").Value);

                productiList.Add(producto);

            }
            return productiList;
        }

        public static void RemoveProducto(Producto p)
        {
            LoadXMl();
            var listaProductos = xml.Root.Elements("Categoria").Elements("Marca").Elements("Electrodomestico").Attributes("Referencia");

            foreach (XAttribute referencia in listaProductos)
            {
                if (p.Referencia == referencia.Value)
                {
                    referencia.Parent.Remove();
                    break;
                }
            }
            saveXML();
        }

        public static void editarProducto(Producto p)
        {
            LoadXMl();
            var listaProductos = xml.Root.Elements("Categoria").Elements("Marca").Elements("Electrodomestico").Attributes("Referencia");

            foreach (XAttribute Referencia in listaProductos)
            {
                if (p.Referencia == Referencia.Value)
                {
                    Referencia.Parent.Remove();
                    break;
                }
            }
            saveXML();
            addXMLProduct(p);
        }
    }
   
}
