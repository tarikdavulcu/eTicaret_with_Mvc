using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Slider
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public string Resim { get; set; }
        public string BaslikIcerik { get; set; }
        public string BaslikEk { get; set; }
        public string ButtonName { get; set; }
        public string URL { get; set; }
        public Nullable<bool> Aktif { get; set; }
    }
}
