using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Musteriler
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
