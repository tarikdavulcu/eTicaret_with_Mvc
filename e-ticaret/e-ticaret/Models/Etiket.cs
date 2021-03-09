using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Etiket
    {
        public Etiket()
        {
            this.Urunlers = new List<Urunler>();
        }

        public int ID { get; set; }
        public string Adi { get; set; }
        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}
