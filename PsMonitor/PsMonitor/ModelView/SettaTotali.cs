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

namespace PsMonitor
{
    class Settatotali : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string totalebianchi = "0";
        string totaleverdi = "0";
        string totalegialli = "0";
        string totalerossi = "0";
        private string response;
        public RecordBO record;
        public TotaliBean totali;
        Grid grid = new Grid();
        public Settatotali()
        {
            getData();
            totali = record.getJSONData();
            int i = 0;
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
        public void getData()
        {

            response = REST().Result;
            System.Diagnostics.Debug.WriteLine(response);
            JObject jObject = JObject.Parse(response);
            JArray jArray = (JArray)jObject["data"];
            var result = JsonConvert.DeserializeObject<List<RecordBean>>(jArray.ToString()) as List<RecordBean>;
            System.Diagnostics.Debug.WriteLine("Response: " + result.Count);
            record = new RecordBO(result);
        }

        public static async Task<string> REST()
        {
            string strResponse = "";
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://192.168.8.12:3004/whmonitorps?dataingresso=2017-07-19&oraingresso=20:00").Result;

            if (response.IsSuccessStatusCode)
            {
                strResponse = await response.Content.ReadAsStringAsync();
            }
            else
            {
                strResponse = await response.Content.ReadAsStringAsync();
            }
            return strResponse;
        }
    }
}
