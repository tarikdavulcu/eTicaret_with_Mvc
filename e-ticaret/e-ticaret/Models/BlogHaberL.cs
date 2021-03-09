using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class BlogHaberL
    {
        public int BlogHaberID { get; set; }
        public int DilID { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
        public string Resim { get; set; }
        public string Tarih { get; set; }
        public Nullable<int> KullaniciID { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public virtual BlogHaber BlogHaber { get; set; }
        public virtual Dil Dil { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
