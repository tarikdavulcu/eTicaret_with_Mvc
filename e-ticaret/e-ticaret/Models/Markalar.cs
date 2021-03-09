using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Markalar
    {
        public Markalar()
        {
            this.Urunlers = new List<Urunler>();
        }

        public int ID { get; set; }
        public string MarkaAdi { get; set; }
        public string Resim { get; set; }
        public Nullable<int> SiraNo { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}
