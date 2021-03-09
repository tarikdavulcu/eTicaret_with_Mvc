using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class UrunResimleri
    {
        public int ID { get; set; }
        public string Resim { get; set; }
        public Nullable<int> SiraNo { get; set; }
        public int UrunID { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
