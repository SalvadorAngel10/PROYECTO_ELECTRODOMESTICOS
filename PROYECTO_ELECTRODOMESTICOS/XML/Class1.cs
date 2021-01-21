﻿using PROYECTO_ELECTRODOMESTICOS.Productos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROYECTO_ELECTRODOMESTICOS.XML
{//MAL FORMULADO LA CLASE VA A PARTE
    public class Class1
    {
        private static XDocument xml;
        public static Producto producto;
        private static XElement xmlCategoria;
        private static XElement xmlModelo;

        private static void LoadXMl() { xml = XDocument.Load("../../XML/XMLFile1.xml"); }
        private static void saveXML()
        {
            xml.Save("../../XML/XMLFile1.xml");
        }



        private static void AddCategoria(Producto p)
        {
            var listaCAtegorias = xml.Root.Elements("Categoria").Attributes("idCategoria");
            bool isNewCategory = true;
            foreach (XAttribute categoria in listaCAtegorias)
            {
                if (categoria.Value.Equals(p.Referencia))
                {
                    xmlCategoria = categoria.Parent;
                    isNewCategory = false;
                    break;
                }
                else
                {
                    xmlCategoria = new XElement("Categoria", new XAttribute("idCategoria", p.Referencia /*category*/));
                    xmlModelo = new XElement("Marca", new XAttribute("nombre", producto.Clase));
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
            foreach (XAttribute modelo in xmlCategoria.Elements().Attributes("nombre"))
            {
                if (modelo.Value.Equals(producto.Clase))
                {
                    xmlModelo = modelo.Parent;
                    isNewModelo = false;
                    break;
                }
                else
                {
                    xmlModelo = new XElement("modelo", new XAttribute("nombre", producto.Clase));
                    isNewModelo = true;
                }
            }
            if (isNewModelo) { xmlCategoria.Add(xmlModelo); }
        }

        private static void crearProducto()
        {
            XElement xmlProducto = new XElement("Electrodomestico",new XAttribute("Referencia",producto.Referencia), 
            new XAttribute("Precio", producto.Precio),new XAttribute("Stock", producto.stock), new XAttribute("Fecha", producto.fechaAlta));
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
              //MAL// producto.Precio= productoxml.Attribute("Precio").Value;
              //MAL//producto.stock = productoxml.Attribute("Stock").Value;
                DateTime.Parse(productoxml.Attribute("Fecha").Value);
                // producto.fechaAlta = productoxml.Attribute("Fecha").Value;
                producto.Clase = productoxml.Parent.Attribute("nombre").Value;
                producto.Descripcion = productoxml.Parent.Parent.Attribute("idCategoria").Value;
                productiList.Add(producto);

            }
            return productiList;
        }

        public static void RemoveProducto(String Precio)
        {
            LoadXMl();
            var listaProductos = xml.Root.Elements("tipo").Elements("modelo").Elements("Producto").Attributes("Precio");

            foreach (XAttribute precio in listaProductos)
            {
                if (Precio == precio.Value)
                {
                    precio.Parent.Remove();
                    break;
                }
            }
            saveXML();
        }

        public static void editarProducto(Producto p)
        {
            LoadXMl();
            var listaProductos = xml.Root.Elements("Categoria").Elements("Marca").Elements("Electrodomestico").Attributes("Precio");

            foreach (XAttribute precio in listaProductos)
            {
                if (p.Precio.ToString() == precio.Value)
                {
                    precio.Parent.Remove();
                    break;
                }
            }
            saveXML();
            addXMLProduct(p);
        }
    }
    /*para pasar a tipo string tienes que poner al final .ToString()
de string a float: float.Parse(tu variable);
de string a datetime. DateTime.Parse(tu varibale);*/
}
