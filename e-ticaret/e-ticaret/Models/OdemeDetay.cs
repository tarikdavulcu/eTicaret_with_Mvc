using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class OdemeDetay
    {
        public int ID { get; set; }
        public int SepetID { get; set; }
        public string OdemeTuru { get; set; }
        public Nullable<decimal> ToplamTurtar { get; set; }
        public string Aciklama { get; set; }
        public string IpAdresi { get; set; }
    }
}
