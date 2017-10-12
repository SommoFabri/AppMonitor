using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace PsMonitor.Service
{
    class Connessione
    {
        public Connessione()
        {
            getData();
        }
        private string response;
        public RecordBO record;
        public void getData()
        {
            string URL = DateNow();
            response = REST(URL).Result;
            System.Diagnostics.Debug.WriteLine(response);
            JObject jObject = JObject.Parse(response);
            JArray jArray = (JArray)jObject["data"];
            var result = JsonConvert.DeserializeObject<List<RecordBean>>(jArray.ToString()) as List<RecordBean>;
            System.Diagnostics.Debug.WriteLine("Response: " + result.Count);
            record = new RecordBO(result);
        }

        public static string DateNow()
        {
            var data = DateTime.Today;
            var data1 = data.AddDays(-1);
            var ora = DateTime.Now.Hour.ToString();
            var day = data1.Day.ToString();
            var month = data1.Month.ToString();
            var anno = data1.Year.ToString();
            string URL= "http://192.168.8.12:3004/whmonitorps?dataingresso=" + anno + "-" + month + "-" + day + "&oraingresso=20:00";
            return URL;

        }

        public static async Task<string> REST(string URL)
        {
            string strResponse = "";
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(URL).Result;

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
