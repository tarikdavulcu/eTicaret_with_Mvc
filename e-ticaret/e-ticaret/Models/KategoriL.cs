using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class KategoriL
    {
        public int KID { get; set; }
        public int DID { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public string Seolink { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public Nullable<int> SiraNo { get; set; }
        public virtual Dil Dil { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
