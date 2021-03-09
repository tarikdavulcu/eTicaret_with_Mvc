using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Urun_Yorumlari
    {
        public int ID { get; set; }
        public int UrunID { get; set; }
        public string Yorum { get; set; }
        public string YorumuYazan { get; set; }
        public string Mail { get; set; }
        public string Tarih { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
