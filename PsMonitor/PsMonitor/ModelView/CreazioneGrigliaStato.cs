using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace PsMonitor.ModelView
{
    class CreazioneGrigliaStato
    {
        public static Grid griglia_cerchi(RigaBean i)
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
            for (int y = 0; y < 4; y++)
            {
                grid_image.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int y = 0; y < 4; y++)
            {
                string immagine = "";
                string numero = "";
                switch (y)
                {
                    case 0:
                        immagine = "cerchio_b";
                        numero = i.bianchi.ToString();
                        break;
                    case 1:
                        immagine = "cerchio_v";
                        numero = i.verdi.ToString();
                        break;
                    case 2:
                        immagine = "cerchio_g";
                        numero = i.gialli.ToString();
                        break;
                    case 3:
                        immagine = "cerchio_r";
                        numero = i.rossi.ToString();
                        break;

                }
                var image = new Image
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Source = immagine,
                    Aspect = Aspect.AspectFill
                };
                var label_image = new Label
                {
                    Text = numero,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    TextColor = Color.Black,
                };
                grid_image.Children.Add(image, column_image, row_image);
                grid_image.Children.Add(label_image, column_image, row_image);
                column_image++;
            }
            column_image = 0;
            return grid_image;
        }
    }
}
