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

        public async Task<Grid>  creaGrigliaHead(Grid gridLayout, TotaliBean totali)
        {
            
           gridLayout= await GrigliaBody.creaGrigliaBody(totali, gridLayout);
            return gridLayout;
        }


    }
}
