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
                totali = connessione.record.getJSONData();
                BindingContext = new Settatotali(totali);
                 CreazioneGriglia();
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
                return start;
            });
            start = true;
           
        }
    

        public void TempoStart()
        {
            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                stopwatch.Start();
                return start;
            });
        }

        public void TempoFineDomanda()
        {
            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                stopwatch.Stop();
                tempo = stopwatch.Elapsed;
                return start;
            });
        }

        public void TempoResetDomanda()
        {
            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                stopwatch.Reset();
                return start;
            });
        }

        public void TempoRestartDomanda()
        {
            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {   
                tempo = stopwatch.Elapsed;
                deltatemporale = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", tempo.Hours, tempo.Minutes, tempo.Seconds, tempo.Milliseconds);
                tempotrascorso = deltatemporale;
           
                stopwatch.Restart();
                return start;
            });
        }
    }
}
