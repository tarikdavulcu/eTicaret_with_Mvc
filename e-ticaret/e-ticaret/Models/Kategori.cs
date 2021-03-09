using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Kategori
    {
        public Kategori()
        {
            this.KategoriLs = new List<KategoriL>();
            this.Urunlers = new List<Urunler>();
        }

        public int ID { get; set; }
        public string Adi { get; set; }
        public string Resim { get; set; }
        public bool Aktif { get; set; }
        public virtual ICollection<KategoriL> KategoriLs { get; set; }
        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}
