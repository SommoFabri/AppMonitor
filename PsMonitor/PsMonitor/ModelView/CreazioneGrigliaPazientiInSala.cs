using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PsMonitor.ModelView
{
    class CreazioneGrigliaPazientiInSala
    {
        public static Grid GrigliaPazienti(ValoreBean i)
        {
            int row_image = 0;
            int column_image = 0;
            //creo griglia per cerchietti
            var grid_Reparto = new Grid
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            grid_Reparto.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            for (int y = 0; y < 4; y++)
            {
                grid_Reparto.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int y = 0; y < 4; y++)
            {
                string immagine = "";
                string numero = "";
                switch (y)
                {
                    case 0:
                        immagine = "bianco.png";
                        numero = i.bianchi.ToString();
                        break;
                    case 1:
                        immagine = "verde.png";
                        numero = i.verdi.ToString();
                        break;
                    case 2:
                        immagine = "giallo.png";
                        numero = i.gialli.ToString();
                        break;
                    case 3:
                        immagine = "rosso.png";
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
                    FontAttributes = FontAttributes.Bold
                };
                grid_Reparto.Children.Add(image, column_image, row_image);
                grid_Reparto.Children.Add(label_image, column_image, row_image);
                column_image++;
            }
            column_image = 0;
            return grid_Reparto;
        }
    }
}
