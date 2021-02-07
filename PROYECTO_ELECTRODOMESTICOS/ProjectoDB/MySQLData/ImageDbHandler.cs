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
    }
}
