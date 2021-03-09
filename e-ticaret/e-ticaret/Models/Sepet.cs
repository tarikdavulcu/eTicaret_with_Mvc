using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Sepet
    {
        public Sepet()
        {
            this.Sepet_Detay = new List<Sepet_Detay>();
        }

        public int ID { get; set; }
        public string Tarih { get; set; }
        public string Cookie { get; set; }
        public bool Aktif { get; set; }
        public virtual ICollection<Sepet_Detay> Sepet_Detay { get; set; }
    }
}
