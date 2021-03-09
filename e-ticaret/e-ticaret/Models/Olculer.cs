using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Olculer
    {
        public int ID { get; set; }
        public int UrunID { get; set; }
        public string OlcuAdi { get; set; }
        public bool Aktif { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
