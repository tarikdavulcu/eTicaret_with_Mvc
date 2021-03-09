using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Urunler
    {
        public Urunler()
        {
            this.Bedenlers = new List<Bedenler>();
            this.Olculers = new List<Olculer>();
            this.Renklers = new List<Renkler>();
            this.Sepet_Detay = new List<Sepet_Detay>();
            this.Urun_Yorumlari = new List<Urun_Yorumlari>();
            this.UrunlerLs = new List<UrunlerL>();
            this.UrunResimleris = new List<UrunResimleri>();
            this.Etikets = new List<Etiket>();
        }

        public int ID { get; set; }
        public string UrunAdi { get; set; }
        public int KategoriID { get; set; }
        public Nullable<int> TedarikciID { get; set; }
        public Nullable<int> MarkaID { get; set; }
        public string UrunKodu { get; set; }
        public string Barkod { get; set; }
        public bool Aktif { get; set; }
        public string Resim { get; set; }
        public virtual ICollection<Bedenler> Bedenlers { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Markalar Markalar { get; set; }
        public virtual ICollection<Olculer> Olculers { get; set; }
        public virtual ICollection<Renkler> Renklers { get; set; }
        public virtual ICollection<Sepet_Detay> Sepet_Detay { get; set; }
        public virtual ICollection<Urun_Yorumlari> Urun_Yorumlari { get; set; }
        public virtual ICollection<UrunlerL> UrunlerLs { get; set; }
        public virtual ICollection<UrunResimleri> UrunResimleris { get; set; }
        public virtual ICollection<Etiket> Etikets { get; set; }
    }
}
