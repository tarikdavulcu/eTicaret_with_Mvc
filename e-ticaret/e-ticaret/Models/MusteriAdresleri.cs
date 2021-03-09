using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class MusteriAdresleri
    {
        public int ID { get; set; }
        public int MID { get; set; }
        public string Adres { get; set; }
        public string Adres1 { get; set; }
        public string Sehir { get; set; }
        public string Ulke { get; set; }
        public string PostaKodu { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Mail { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Sirket { get; set; }
        public string SirketUnvani { get; set; }
        public string Adresİsmi { get; set; }
    }
}
