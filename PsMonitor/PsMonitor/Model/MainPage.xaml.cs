using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PsMonitor.ModelView;
namespace PsMonitor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new Settatotali();
            ModelView.CreaGriglia griglia= new CreaGriglia();
            griglia.creaGrigliaHead(gridLayoutHead);
            RefreshConnection();
            Service.Connessione.DateNow();
        }

        public void RefreshConnection()
        {
            ModelView.CreaGriglia griglia = new CreaGriglia();
            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                Service.Connessione connessione = new Service.Connessione();
                connessione.getData();
                TotaliBean totali = connessione.record.getJSONData();
                AggiornaGriglia.Aggiorna_Griglia(gridLayoutHead,totali);
            });

        }
    }
}
