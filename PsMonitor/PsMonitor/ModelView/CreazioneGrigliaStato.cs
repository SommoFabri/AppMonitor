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
            for (int y = 0; y < 2; y++)
            {
                grid_image.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid_image.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int y = 0; y < 4; y++)
            {
                string immagine = "";
                string numero = "";
                switch (y)
                {
                    case 0:
                        immagine = "cerchioB.png";
                        numero = i.bianchi.ToString();
                        break;
                    case 1:
                        immagine = "cerchioV.png";
                        numero = i.verdi.ToString();
                        break;
                    case 2:
                        immagine = "cerchioG.png";
                        row_image = 1;
                        column_image = 0;
                        numero = i.gialli.ToString();
                        break;
                    case 3:
                        immagine = "cerchioR.png";
                        numero = i.rossi.ToString();
                        row_image = 1;
                        column_image = 1;
                        break;

                }
                var image = new Image
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Source = immagine,
                    Aspect = Aspect.AspectFill,
                    HeightRequest=35
                };
                var label_image = new Label
                {
                    Text = numero,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalOptions= LayoutOptions.Center,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold

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
