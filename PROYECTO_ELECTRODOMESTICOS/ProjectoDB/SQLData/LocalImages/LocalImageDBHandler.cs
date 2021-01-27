using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.LocalImages.LocalImagesDataSet;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.LocalImages.LocalImagesDataSet.DataSet_Local_ImagesTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.LocalImages
{
     public class LocalImageDBHandler
    {
        private static ImagesTableAdapter imagesTableAdapter = new ImagesTableAdapter();
        private static DataSet_Local_Images dataset = new DataSet_Local_Images();

        public static void addData_toDB (string idIMage,byte[] productImage)
        {
            imagesTableAdapter.Insert(idIMage, productImage);
            imagesTableAdapter.Update(dataset);
        }

        public static byte[] GetDataFromDB(string idImage) 
        {
            byte[] dataImage = null;
            try
            {
                
                dataImage= imagesTableAdapter.GetImage(idImage).ElementAt(0).productImage;
            }
            catch(Exception ex) { }

            return dataImage;
        }
    }
}
