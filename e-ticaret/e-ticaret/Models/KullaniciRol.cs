using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class KullaniciRol
    {
        public KullaniciRol()
        {
            this.Kullanicilars = new List<Kullanicilar>();
        }

        public int ID { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<Kullanicilar> Kullanicilars { get; set; }
    }
}
