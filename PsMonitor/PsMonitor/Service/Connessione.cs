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

            response = REST().Result;
            System.Diagnostics.Debug.WriteLine(response);
            JObject jObject = JObject.Parse(response);
            JArray jArray = (JArray)jObject["data"];
            var result = JsonConvert.DeserializeObject<List<RecordBean>>(jArray.ToString()) as List<RecordBean>;
            System.Diagnostics.Debug.WriteLine("Response: " + result.Count);
            record = new RecordBO(result);
        }

        public static void DateNow()
        {
            var data = DateTime.Today;
            var ora = DateTime.Now.Hour.ToString();
            var day = DateTime.Now.Day.ToString();
            var month = DateTime.Now.Month.ToString();

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
