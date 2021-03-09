using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class BlogKategoriL
    {
        public int BlogKategoriID { get; set; }
        public int DilID { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public string Adi { get; set; }
        public virtual BlogKategori BlogKategori { get; set; }
        public virtual Dil Dil { get; set; }
    }
}
