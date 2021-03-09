using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class SiteBilgileri
    {
        public string FirmaAdi { get; set; }
        public string Adres { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Tel { get; set; }
        public string Faks { get; set; }
        public string MobilTel { get; set; }
        public string Mail { get; set; }
        public string URL { get; set; }
        public string KeyWords { get; set; }
        public string HaritaKodu { get; set; }
        public string SiteLogo { get; set; }
        public int DilID { get; set; }
        public virtual Dil Dil { get; set; }
    }
}
