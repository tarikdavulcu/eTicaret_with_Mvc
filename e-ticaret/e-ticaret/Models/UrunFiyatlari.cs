using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class UrunFiyatlari
    {
        public int DilID { get; set; }
        public int UrunID { get; set; }
        public Nullable<decimal> KDV { get; set; }
        public Nullable<decimal> NakitIndirim { get; set; }
        public Nullable<decimal> KampanyaIndirim { get; set; }
        public Nullable<decimal> OzelIndirim { get; set; }
        public Nullable<decimal> KargoIndirimi { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public Nullable<decimal> TaksitliFiyat { get; set; }
        public string ParaBirimi { get; set; }
    }
}
