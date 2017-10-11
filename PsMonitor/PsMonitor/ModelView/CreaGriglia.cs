using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PsMonitor.Service;
using System.Collections;

namespace PsMonitor.ModelView
{
    class CreaGriglia
    {

        public TotaliBean totali;

        public CreaGriglia()
        {

            Service.Connessione connessione = new Connessione();
            totali = connessione.record.getJSONData();
        }

        public void  creaGrigliaHead (Grid gridLayout)
        {


            List <string> sala = new List<string>();
            sala.Add("stato");
            int row = 0;
            int column = 0;

            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            foreach (string i in totali.sale)
            {
             gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
             sala.Add(i);
            }
            foreach (string i in sala)
            {
                var label = new Label
                {
                    Text = i,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White,
                    FontAttributes = FontAttributes.Bold
                };
                gridLayout.Children.Add(label, column, row);
                column++;

            }
        }

        public void creaGrigliaBody(Grid gridLayout)
        {
            int row = 0;
            int column = 0;
            int row_image = 0;
            int column_image = 0;

            foreach ( var i in totali.righe)
            {
                //righe;
                gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); //stato
                //colonne;
                gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                foreach (var y in i.valori)
                {
                    //gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); //colonna per sala       }
                }
            }
            foreach (var i in totali.righe)
            {
                //Color sfondo = Color("#92adcc"); 
                var label = new Label
                {
                    Text = i.stato,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold
                };
                var stack_vertical = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    BackgroundColor = Color.Red,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                    
                };
                var stack_horizontal = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
                
                gridLayout.Children.Add(label, column, row);

              //creo griglia per cerchietti
              var grid_image = new Grid
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };
                grid_image.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                for (int y=0; y<4; y++)
                {
                    grid_image.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                }

                for (int y = 0; y < 4; y++)
                {
                    var image = new Image
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Source = "cerchio_r.png",
                        Aspect = Aspect.AspectFit
                    };
                    var label_image = new Label
                    {
                        Text = "0",
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Black,
                    };
                    grid_image.Children.Add(image, column_image, row_image);
                    grid_image.Children.Add(label_image, column_image, row_image);
                    column_image++;
                }
                row_image++;
                column_image = 0;
                row++;
                gridLayout.Children.Add(grid_image, column, row);
                stack_vertical.Children.Add(label);
                stack_vertical.Children.Add(stack_horizontal);
                stack_horizontal.Children.Add(grid_image);
            }



        }
    }
}
