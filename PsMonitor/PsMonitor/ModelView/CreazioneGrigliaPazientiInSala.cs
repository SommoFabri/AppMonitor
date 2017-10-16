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
        public static Grid GrigliaPazienti(ValoreBean i, List<Label[]> pasienti)
        {
            int row_image = 0;
            int column_image = 0;
            int z = 0;
            Label[] label = new Label[4];
            //creo griglia per cerchietti
            var grid_Reparto = new Grid
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            grid_Reparto.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid_Reparto.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            for (int y = 0; y < 2; y++)
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
                        immagine = "Bianco.png";
                        numero = i.bianchi.ToString();
                        break;
                    case 1:
                        immagine = "Verde.png";
                        numero = i.verdi.ToString();
                        break;
                    case 2:
                        immagine = "Giallo.png";
                        numero = i.gialli.ToString();
                        row_image = 1;
                        column_image = 0;
                        break;
                    case 3:
                        immagine = "Rosso.png";
                        numero = i.rossi.ToString();
                        row_image = 1;
                        column_image = 1;
                        break;

                }
                var image = new Image
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Source = immagine
                };
                label[z] = new Label
                {
                    Text = numero,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold
                };
                grid_Reparto.Children.Add(image, column_image, row_image);
                grid_Reparto.Children.Add(label[z], column_image, row_image);
                z++;
                column_image++;
            }
            column_image = 0;
            pasienti.Add(label);
            return grid_Reparto;
        }
    }
}
