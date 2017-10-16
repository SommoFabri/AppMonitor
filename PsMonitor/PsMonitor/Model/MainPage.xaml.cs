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

        public Label[] label_image_tot = new Label[10];
        public List<Label[]> labelCerchiStato = new List<Label[]>();
        public List<Label[]> labelPersoneSala = new List<Label[]>();

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
                RefreshConnectionLost();
            }

        }
        public async void CreazioneGriglia()
        {
            ModelView.CreaGriglia griglia = new CreaGriglia();
            gridLayoutHead = await griglia.creaGrigliaHead(gridLayoutHead, totali, label_image_tot,labelCerchiStato,labelPersoneSala);

        }
        public void RefreshConnection()
        {
            bool flag = false;
            Device.StartTimer(TimeSpan.FromSeconds(20), () =>
           {
               Service.Connessione connessioni = new Connessione();
               TotaliBean totale = connessioni.record.getJSONData();
              
               Aggiornamento_Tab.aggiornamento(gridLayoutHead, totale, label_image_tot, labelCerchiStato, labelPersoneSala);
               BindingContext = new Settatotali(totale);
               return true;

           });
        }
        public void RefreshConnectionLost()
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
