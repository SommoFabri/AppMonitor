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
        }

        public void RefreshConnection()
        {
            Device.StartTimer(TimeSpan.FromMinutes(1), () =>
            {
                Service.Connessione connessione = new Service.Connessione();
                connessione.getData();
                return true;
            });

        }
    }
}
