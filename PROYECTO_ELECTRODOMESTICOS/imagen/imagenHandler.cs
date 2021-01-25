using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PROYECTO_ELECTRODOMESTICOS.imagen
{
    class imagenHandler
    {
        public static BitmapImage GetBitmapImage() 
        {
            OpenFileDialog opf = new OpenFileDialog();
            BitmapImage bitmapImage = new BitmapImage();
            opf.Filter = "elige imagen *.jpg; *.png";
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
    }
}
