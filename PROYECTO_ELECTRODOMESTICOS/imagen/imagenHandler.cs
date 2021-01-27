using Microsoft.Win32;
using PROYECTO_ELECTRODOMESTICOS.ProjectoDB.SQLData.LocalImages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PROYECTO_ELECTRODOMESTICOS.imagen
{
   public class imagenHandler
    {
        public static BitmapImage GetBitmapImage() 
        {
            OpenFileDialog opf = new OpenFileDialog();
            BitmapImage bitmapImage = new BitmapImage();
            opf.Filter = "elige imagen | *.jpg; *.png";
             bool? dialogOK=  opf.ShowDialog();


            if (dialogOK == true) 
            {
                string imageName = opf.FileName;
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(imageName, UriKind.Absolute);
                bitmapImage.EndInit();
                return bitmapImage;

            }
            return null;
        }

        public static void AddImage(string Referencia,BitmapImage bitmapImage) 
        {
            LocalImageDBHandler.addData_toDB(Referencia, EncodeImage(bitmapImage));
        }


        public static BitmapImage GetImage(string Referencia) 
        {
            BitmapImage bitmapImage = LoadDefaultImage();

            byte[] dataImage = LocalImageDBHandler.GetDataFromDB(Referencia);
            if (dataImage != null) 
            {
                bitmapImage = DecodeImage(dataImage);
            }
            return bitmapImage;
        }

        public static BitmapImage LoadDefaultImage() 
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource =new Uri("/imagen/almacen.jpg",UriKind.Relative);
            bitmapImage.EndInit();
            return bitmapImage;
        }

        public static byte[] EncodeImage(BitmapImage bitmapImage)
        {

            byte[] imageByte;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                imageByte = ms.ToArray();
            }
            return imageByte;
        }




        public static BitmapImage DecodeImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }



    }
}
