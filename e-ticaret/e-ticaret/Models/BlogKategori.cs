using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class BlogKategori
    {
        public BlogKategori()
        {
            this.BlogHabers = new List<BlogHaber>();
            this.BlogKategoriLs = new List<BlogKategoriL>();
        }

        public int ID { get; set; }
        public string Adi { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public virtual ICollection<BlogHaber> BlogHabers { get; set; }
        public virtual ICollection<BlogKategoriL> BlogKategoriLs { get; set; }
    }
}
