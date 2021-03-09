using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Promosyon
    {
        public int ID { get; set; }
        public string Resim { get; set; }
        public string URL { get; set; }
        public Nullable<int> SiraNo { get; set; }
        public string Adi { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public Nullable<int> OlcuY { get; set; }
        public Nullable<int> OlcuX { get; set; }
    }
}
