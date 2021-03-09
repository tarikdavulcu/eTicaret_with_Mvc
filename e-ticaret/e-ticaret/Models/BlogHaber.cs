using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class BlogHaber
    {
        public BlogHaber()
        {
            this.BlogHaberLs = new List<BlogHaberL>();
        }

        public int ID { get; set; }
        public Nullable<int> BlogKategoriID { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public string Baslik { get; set; }
        public virtual BlogKategori BlogKategori { get; set; }
        public virtual ICollection<BlogHaberL> BlogHaberLs { get; set; }
    }
}
