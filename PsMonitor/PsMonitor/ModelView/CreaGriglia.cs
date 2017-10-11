using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PsMonitor.Service;
using System.Collections;

namespace PsMonitor.ModelView
{
    class CreaGriglia
    {

        public TotaliBean totali;

        public CreaGriglia()
        {

            Service.Connessione connessione = new Connessione();
            totali = connessione.record.getJSONData();
        }

        public void creaGrigliaHead(Grid gridLayout)
        {
            gridLayout = GrigliaBody.creaGrigliaBody(totali, gridLayout);
        }


    }
}
