using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using PsMonitor;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using PsMonitor.Service;

namespace PsMonitor
{
    class Settatotali : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string totalebianchi = "0";
        string totaleverdi = "0";
        string totalegialli = "0";
        string totalerossi = "0";
        public TotaliBean totali;
        public Settatotali( )
        {
            Service.Connessione connessione = new Connessione();
            totali = connessione.record.getJSONData();
            totalebianchi = totali.bianchi.ToString();
            totaleverdi = totali.verdi.ToString();
            totalegialli = totali.gialli.ToString();
            totalerossi = totali.rossi.ToString();

        }
        public string TotaleBianchi
        {
            get { return totalebianchi; }
            set
            {
                totalebianchi = value;
            }
        }

        public string TotaleVerdi
        {
            get { return totaleverdi; }
            set
            {
                totaleverdi = value;
            }
        }

        public string TotaleGialli
        {
            get { return totalegialli; }
            set
            {
                totalegialli = value;
            }
        }

        public string TotaleRossi
        {
            get { return totalerossi; }
            set
            {
                totalerossi = value;
            }
        }
    }
}
