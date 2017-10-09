using System;
using System.Collections.Generic;
namespace PsMonitor
{
    public class RigaBean
    {
        public string stato { get; set; }
        public List<ValoreBean> valori { get; set; }
        public int bianchi { get; set; }
        public int verdi { get; set; }
        public int gialli { get; set; }
        public int rossi { get; set; }
        public RigaBean()
        {
        }
    }
}
