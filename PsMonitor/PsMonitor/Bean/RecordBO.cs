using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsMonitor;

namespace PsMonitor
{
    public class RecordBO
        {

            private List<RecordBean> lista = new List<RecordBean>();
            private string[] sale = { "MEDICO", "ORTOPEDICO", "CHIRURGICO" };
            private string[] stati = { "Accettato", "In Visita", "In Attesa Referto", "In Osservazione OBI", "Attesa Ricovero" };

            private List<SalaBean> listSale;
            private List<RigaBean> listStato;
            private TotaliBean totale;

            private int totaleGeneraleBianchi = 0;
            private int totaleGeneraleVerdi = 0;
            private int totaleGeneraleGialli = 0;
            private int totaleGeneraleRossi = 0;

            public RecordBO(List<RecordBean> lista)
            {
                this.lista = lista;
            }

            public TotaliBean getJSONData()
            {
                this.listSale = new List<SalaBean>();
                for (int i = 0; i < sale.Length; i++)
                {
                    SalaBean sala = new SalaBean()
                    {
                        codice = sale[i],
                        descrizione = sale[i]
                    };
                    listSale.Add(sala);
                }
                this.listStato = new List<RigaBean>();
                for (int i = 0; i < stati.Length; i++)
                {
                    RigaBean riga = new RigaBean();
                    riga.stato = stati[i];
                    listStato.Add(riga);
                }
                totale = new TotaliBean();
                totale.sale = this.setSale();
                totale.righe = this.getRighe();
                totale.bianchi = this.totaleGeneraleBianchi;
                totale.verdi = this.totaleGeneraleVerdi;
                totale.gialli = this.totaleGeneraleGialli;
                totale.rossi = this.totaleGeneraleRossi;
                return totale;
            }
        private List<string> setSale()
        {
            List<string> returnValue = new List<string>();
            for (int i = 0; i < this.listSale.Count; i++)
            {
                string sala = listSale[i].descrizione;
                returnValue.Add(sala);
            }
            return returnValue;
        }
        private List<RigaBean> getRighe()
        {
            List<RigaBean> returnValue = new List<RigaBean>();
            for (int i = 0; i < listStato.Count; i++)
            {

                RigaBean riga = listStato[i];
                int totaleRigaBianchi = 0;
                int totaleRigaVerdi = 0;
                int totaleRigaGialli = 0;
                int totaleRigaRossi = 0;
                riga.stato = listStato[i].stato;
                List<ValoreBean> valori = new List<ValoreBean>();
                for (int x = 0; x < listSale.Count; x++)
                {
                    SalaBean salaObject = listSale[x];
                    string sala = salaObject.descrizione;
                    ValoreBean valore = new ValoreBean();
                    int totaleBianchi = this.getTotale(riga.stato, "Bianco", sala);
                    int totaleVerdi = this.getTotale(riga.stato, "Verde", sala);
                    int totaleGialli = this.getTotale(riga.stato, "Giallo", sala);
                    int totaleRossi = this.getTotale(riga.stato, "Rosso", sala);
                    valore.bianchi = totaleBianchi;
                    valore.verdi = totaleVerdi;
                    valore.gialli = totaleGialli;
                    valore.rossi = totaleRossi;
                    valori.Add(valore);
                    totaleRigaBianchi += totaleBianchi;
                    totaleRigaVerdi += totaleVerdi;
                    totaleRigaGialli += totaleGialli;
                    totaleRigaRossi += totaleRossi;
                    if (!riga.stato.Equals("In Osservazione OBI"))
                    {
                        totaleGeneraleBianchi += totaleBianchi;
                        totaleGeneraleVerdi += totaleVerdi;
                        totaleGeneraleGialli += totaleGialli;
                        totaleGeneraleRossi += totaleRossi;
                    }
                }
                riga.valori = valori;

                riga.bianchi = totaleRigaBianchi;
                riga.verdi = totaleRigaVerdi;
                riga.gialli = totaleRigaGialli;
                riga.rossi = totaleRigaRossi;

                returnValue.Add(riga);
            }
            return returnValue;
        }

        private int getTotale(string stato, string coloreTriage, string sala)
        {
            int returnValue = 0;
            foreach (RecordBean itr in this.lista)
            {
                if (itr.stato.Equals(stato) && itr.coloreprimotriage.Equals(coloreTriage) && itr.salaprimotriage.Equals(sala))
                {
                    returnValue = itr.totaletriage;
                }
            }
            return returnValue;
        }
    }
}
