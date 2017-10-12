using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PsMonitor.ModelView;
using PsMonitor.Service;
using PsMonitor.Model;

namespace PsMonitor
{
    public partial class MainPage : ContentPage
    {

        public TotaliBean totali;
        public MainPage()
        {
           
            InitializeComponent();
            try
            {
                Service.Connessione connessione = new Connessione();
                totali = connessione.record.getJSONData();
                if(totali == null)
                {
                    Navigation.PushAsync(new PaginaManutenzione());
                }
                BindingContext = new Settatotali(totali);
                ModelView.CreaGriglia griglia = new CreaGriglia();
                griglia.creaGrigliaHead(gridLayoutHead, totali);
                RefreshConnection();
            }
            catch (Exception)
            {
                Navigation.PushModalAsync(new PaginaManutenzione());
            }
          
        }

        public void RefreshConnection()
        {
            Device.StartTimer(TimeSpan.FromSeconds(20), () =>
            {
                var vUpdatedPage = new MainPage();
                Navigation.InsertPageBefore(vUpdatedPage, this);
                Navigation.PopAsync();
                return false;
            });
        }
    }
}
