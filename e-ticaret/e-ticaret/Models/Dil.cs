using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Dil
    {
        public Dil()
        {
            this.Ayarlars = new List<Ayarlar>();
            this.BlogHaberLs = new List<BlogHaberL>();
            this.BlogKategoriLs = new List<BlogKategoriL>();
            this.KategoriLs = new List<KategoriL>();
            this.MenuLs = new List<MenuL>();
            this.Metinlers = new List<Metinler>();
            this.SiteBilgileris = new List<SiteBilgileri>();
            this.UrunlerLs = new List<UrunlerL>();
        }

        public int ID { get; set; }
        public string Adi { get; set; }
        public string KisaAdi { get; set; }
        public string Resim { get; set; }
        public bool Aktif { get; set; }
        public virtual ICollection<Ayarlar> Ayarlars { get; set; }
        public virtual ICollection<BlogHaberL> BlogHaberLs { get; set; }
        public virtual ICollection<BlogKategoriL> BlogKategoriLs { get; set; }
        public virtual ICollection<KategoriL> KategoriLs { get; set; }
        public virtual ICollection<MenuL> MenuLs { get; set; }
        public virtual ICollection<Metinler> Metinlers { get; set; }
        public virtual ICollection<SiteBilgileri> SiteBilgileris { get; set; }
        public virtual ICollection<UrunlerL> UrunlerLs { get; set; }
    }
}
