using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PsMonitor.ModelView
{
    class GrigliaBody
    {
        public static async Task<Grid> creaGrigliaBody(TotaliBean totali, Grid gridLayout)
        {

            int row = 0;
            int column = 0;

            List<string> sala = new List<string>();

            sala.Add("Stato");
            var stack_Stato = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Brown
            };
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            foreach (string i in totali.sale)
            {
                gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                sala.Add(i);
            }
            sala.Add("Totali");
            foreach (string i in sala)
            {
                var label = new Label
                {
                    Text = i,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White,
                    FontAttributes = FontAttributes.Bold,
                    BackgroundColor=Color.Chocolate,
                    
                    
                    
                };
                gridLayout.Children.Add(label, column, row);
                column++;
            }
            column = 0;
            row = 1; 
            
            foreach (var i in totali.righe)
            {
                //righe;
                gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); //stato
                //colonne;

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
                    Orientation = StackOrientation.Vertical,
                    BackgroundColor = Color.LightGray
                };
                var stack_Due = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };
                gridLayout.Children.Add(label, column, row);
                gridLayout.Children.Add(stack_vertical, column, row);
                stack_vertical.Children.Add(stack_Due);
                Grid grid_image = CreazioneGrigliaStato.griglia_cerchi(i);
                gridLayout.Children.Add(grid_image, column, row);
                stack_vertical.Children.Add(grid_image);
                stack_Due.Children.Add(label);
                foreach (var a in i.valori)
                {
                    column++;
                    var stack_verticalUno = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        BackgroundColor = Color.LightGray
                    };
                    var stack_DueUno = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal
                    };
                    gridLayout.Children.Add(stack_verticalUno, column, row);
                    stack_verticalUno.Children.Add(stack_DueUno);
                    Grid grid_Pazienti = CreazioneGrigliaPazientiInSala.GrigliaPazienti(a);
                    gridLayout.Children.Add(grid_Pazienti, column, row);
                    stack_verticalUno.Children.Add(grid_Pazienti);
                }
                column++;
                var stack_verticalTotali = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    BackgroundColor = Color.LightGray
                };
                var stack_DueTotali = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };
                gridLayout.Children.Add(stack_verticalTotali, column, row);
                stack_verticalTotali.Children.Add(stack_DueTotali);
                Grid grid_totali = CreazioneGrigliaCerchiTotali.griglia_cerchiTotali(i);
                gridLayout.Children.Add(grid_totali, column, row);
                stack_verticalTotali.Children.Add(grid_totali);
             

                row++;
                column = 0;

            }
            return gridLayout;
        }
        
        
    }
    
}

