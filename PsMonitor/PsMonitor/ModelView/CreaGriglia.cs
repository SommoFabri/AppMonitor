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

        public async Task<Grid>  creaGrigliaHead(Grid gridLayout, TotaliBean totali,Label[] cerchi_tot, List<Label[]> labelCerchiStato, List<Label[]> labelPersoneSala)
        {
            
           gridLayout= await GrigliaBody.creaGrigliaBody(totali, gridLayout, cerchi_tot, labelCerchiStato, labelPersoneSala);
            return gridLayout;
        }


    }
}
