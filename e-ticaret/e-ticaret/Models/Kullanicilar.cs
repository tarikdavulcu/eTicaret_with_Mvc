using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Kullanicilar
    {
        public Kullanicilar()
        {
            this.BlogHaberLs = new List<BlogHaberL>();
        }

        public int ID { get; set; }
        public int RolID { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSifre { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public virtual ICollection<BlogHaberL> BlogHaberLs { get; set; }
        public virtual KullaniciRol KullaniciRol { get; set; }
    }
}
