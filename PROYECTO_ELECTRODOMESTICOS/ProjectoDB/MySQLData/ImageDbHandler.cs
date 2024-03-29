﻿using PROYECTO_ELECTRODOMESTICOS.imagen;
using PROYECTO_ELECTRODOMESTICOS.Productos;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.MySQLData.pruebaDataSEt;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.MySQLData.pruebaDataSEt.mydbDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_ELECTRODOMESTICOS.ProjectoDB.MySQLData
{
   public class ImageDBHandler
    {
        private static imagenesTableAdapter imagenesTableAdapter = new imagenesTableAdapter();
        private static mydbDataSet dataset = new mydbDataSet();


        public static void addElectrodomestico(Producto productos) 
        {
            byte[] imagen = imagenHandler.EncodeImage(productos.imagen);
            imagenesTableAdapter.Insert(productos.Referencia,productos.Categoria,productos.Marca,productos.Clase,productos.Precio,productos.stock,productos.fechaAlta,imagenHandler.EncodeImage(productos.imagen));
            imagenesTableAdapter.Update(dataset);
        }
        public static void deleteElectrodomestico(Producto productos)
        {
            imagenesTableAdapter.DeleteElectrodomestico(productos.Referencia);
            imagenesTableAdapter.Update(dataset);

        }
        public static bool updateElectrodomestico(Producto productos) 
        {
            bool borrar = false;
            if (productos!=null) {
                byte[] imagen = imagenHandler.EncodeImage(productos.imagen);
                float precio = productos.Precio;
                decimal Precio = Convert.ToDecimal(precio);
                imagenesTableAdapter.ActualizarElectrodomesticos(productos.Referencia, productos.Categoria, productos.Marca, productos.Clase, Precio, productos.stock, productos.fechaAlta, imagenHandler.EncodeImage(productos.imagen));
            }
            return borrar;
        }




    }
}
