using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PsMonitor.ModelView;
using PsMonitor.Service;
using PsMonitor.Model;
using System.Diagnostics;

namespace PsMonitor
{
    public partial class MainPage : ContentPage
    {
       public TotaliBean totali;
        public Stopwatch stopwatch = new Stopwatch();
        public bool start=false;
        public TimeSpan tempo;
        public string deltatemporale, tempotrascorso;
        public MainPage()
        {
           
            InitializeComponent();
            Service.Connessione connessione = new Connessione();
            try
            {
                totali = connessione.record.getJSONData();
                BindingContext = new Settatotali(totali);
                CreazioneGriglia();
            }
            catch (Exception)
            {

                Navigation.PushModalAsync(new PaginaManutenzione());
            }
               
         
            RefreshConnection();
        }
        public async void CreazioneGriglia()
        {
            ModelView.CreaGriglia griglia = new CreaGriglia();
            gridLayoutHead = await griglia.creaGrigliaHead(gridLayoutHead, totali);
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
