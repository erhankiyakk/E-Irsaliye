using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Irsaliye
{
    public class Irsaliye
    {
        public string IrsaliyeNo { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public DateTime Tarih { get; set; }
        public string SubeKodu { get; set; }
        public string SubeAdi { get; set; }
        public decimal Tutar { get; set; }
        public decimal Isklonto { get; set; }
        public decimal NetTutar { get; set; }
        public decimal KdvTutari { get; set; }
        public decimal ToplamTutar { get; set; }
    }
}
