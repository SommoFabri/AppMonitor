using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PsMonitor.ModelView;
using PsMonitor.Service;

namespace PsMonitor
{
    public partial class MainPage : ContentPage
    {

        public TotaliBean totali;
        public MainPage()
        {
            Service.Connessione connessione = new Connessione();
            totali = connessione.record.getJSONData();
            InitializeComponent();
            BindingContext = new Settatotali(totali);
            ModelView.CreaGriglia griglia= new CreaGriglia();
            griglia.creaGrigliaHead(gridLayoutHead, totali);
            RefreshConnection();
          
        }

        public void RefreshConnection()
        {
            Device.StartTimer(TimeSpan.FromMinutes(1), () =>
            {
               /* Service.Connessione connessione = new Service.Connessione();
                connessione.getData();*/
                var vUpdatedPage = new MainPage();
                Navigation.InsertPageBefore(vUpdatedPage, this);
                Navigation.PopAsync();
                return true;
            });
        }
    }
}
