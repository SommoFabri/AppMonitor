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
        Service.Connessione connessione = new Connessione();
        public MainPage()
        {
           
            InitializeComponent();
            caricamento.IsVisible = false;
            try
            {
                totali = connessione.record.getJSONData();
                BindingContext = new Settatotali(totali);
                CreazioneGriglia();
            }
            catch (Exception)
            {
                 
                caricamento.IsRunning = true;
                caricamento.IsVisible = true;
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
                Navigation.InsertPageBefore(new MainPage(), this);
                Navigation.PopAsync();
                return false;
            });
     
           
        }
     
    


    }
}
