using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PsMonitor.ModelView
{
    class CreazioneGrigliaCerchiTotali
    {
        
        public static Grid griglia_cerchiTotali(RigaBean i,Label[] cerchi_tot,int z)
        {
            int row_image = 0;
            int column_image = 0;
            //creo griglia per cerchietti
            var grid_image = new Grid
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            grid_image.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            for (int y = 0; y < 1; y++)
            {
                grid_image.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int y = 0; y < 1; y++)
            {
                string immagine = "";
                string numero = "";
                immagine = "cerchioTot.png";
                int j = i.bianchi + i.rossi + i.verdi + i.gialli;
                numero = j.ToString();

                var image = new Image
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Source = immagine,
                    Aspect = Aspect.AspectFill
                };
                 cerchi_tot[z] = new Label
                {
                    Text = numero,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 25

                };
                
                grid_image.Children.Add(image, column_image, row_image);
                grid_image.Children.Add(cerchi_tot[z], column_image, row_image);
                column_image++;
            }
            column_image = 0;
            return grid_image;
        }
    }
}
