namespace PsMonitor.Bean
{
    public class SalaBean
    {
        public string codice { get; set; }
        public string descrizione { get; set; }

        public SalaBean() { }

        public SalaBean(string codice, string descrizione)
        {
            this.codice = codice;
            this.descrizione = descrizione;
        }
    }
}