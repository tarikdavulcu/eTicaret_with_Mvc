using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Metinler
    {
        public int ID { get; set; }
        public string Hakkimizda { get; set; }
        public string SatisSozlesmesi { get; set; }
        public string GizlilikPolitikasi { get; set; }
        public string UyelikSozlesmesi { get; set; }
        public string Iadeİptal { get; set; }
        public string Bilgilendirme { get; set; }
        public string GirisYazisiBaslik { get; set; }
        public string GirisYazisi { get; set; }
        public string Vizyon { get; set; }
        public string Misyon { get; set; }
        public string Strateji { get; set; }
        public Nullable<int> DilID { get; set; }
        public virtual Dil Dil { get; set; }
    }
}
