using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Renkler
    {
        public int ID { get; set; }
        public int UrunID { get; set; }
        public string RenkAdi { get; set; }
        public string RenkKodu { get; set; }
        public bool Aktif { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
