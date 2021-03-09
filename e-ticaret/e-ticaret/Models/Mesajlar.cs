using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Mesajlar
    {
        public int ID { get; set; }
        public string Gonderen { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
        public string Mesaj { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
