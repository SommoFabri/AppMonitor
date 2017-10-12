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

        public CreaGriglia()
        {

        }

        public void creaGrigliaHead(Grid gridLayout, TotaliBean totali)
        {
            gridLayout = GrigliaBody.creaGrigliaBody(totali, gridLayout);
        }


    }
}
