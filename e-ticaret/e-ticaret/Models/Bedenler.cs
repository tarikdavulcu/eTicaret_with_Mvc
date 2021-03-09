using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Bedenler
    {
        public int ID { get; set; }
        public Nullable<int> UrunID { get; set; }
        public string BedenAdi { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
