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

        }
    }
}
