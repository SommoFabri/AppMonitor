using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PsMonitor.ModelView;
using PsMonitor.Service;

namespace PsMonitor.Service
{
    class Aggiornamento_Tab
    {
        public async static void aggiornamento ( Grid layuout, TotaliBean totali, Label[] cerchi_tot,List<Label[]> cerchiStato, List<Label[]> PersoneSala)
        {
            int cont_tot = 0;
            int countStato = 0;
            int countPasienti = 0;
            foreach (var i in totali.righe)
            {
                int j = i.bianchi + i.rossi + i.verdi + i.gialli;
                cerchi_tot[cont_tot].Text = j.ToString() ;
                cont_tot++;
            }
            foreach(var i in cerchiStato)
            {
                    i[0].Text = totali.righe[countStato].bianchi.ToString();
                    i[1].Text = totali.righe[countStato].verdi.ToString();
                    i[2].Text = totali.righe[countStato].gialli.ToString();
                    i[3].Text = totali.righe[countStato].rossi.ToString();
                countStato++;

            }
            foreach(var i in totali.righe)
            {
                foreach (var a in i.valori)
                {
                    var z = PersoneSala[countPasienti];
                    z[0].Text = a.bianchi.ToString();
                    z[1].Text = a.verdi.ToString();
                    z[2].Text = a.gialli.ToString();
                    z[3].Text = a.rossi.ToString();
                    countPasienti++;
                }
               

            }


        }

    }
}
