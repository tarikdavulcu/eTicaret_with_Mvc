using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class UrunlerL
    {
        public string UrunAdi { get; set; }
        public int DilID { get; set; }
        public int UrunID { get; set; }
        public string Aciklama { get; set; }
        public Nullable<int> SiraNo { get; set; }
        public string SeoLink { get; set; }
        public Nullable<double> Fiyat { get; set; }
        public Nullable<double> KDV { get; set; }
        public string MetaTit { get; set; }
        public string MetaKey { get; set; }
        public string MetaDes { get; set; }
        public string Resim { get; set; }
        public string TeknikAciklama { get; set; }
        public string TeknikAciklamaDevam { get; set; }
        public string TeknikDetay { get; set; }
        public virtual Dil Dil { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
