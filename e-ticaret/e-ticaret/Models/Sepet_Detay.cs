using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Sepet_Detay
    {
        public int ID { get; set; }
        public int SepetID { get; set; }
        public Nullable<int> MID { get; set; }
        public int UrunID { get; set; }
        public Nullable<int> Adet { get; set; }
        public Nullable<double> Fiyat { get; set; }
        public Nullable<double> IndirimOrani { get; set; }
        public string Tarih { get; set; }
        public string Renk { get; set; }
        public string Beden { get; set; }
        public virtual Sepet Sepet { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
