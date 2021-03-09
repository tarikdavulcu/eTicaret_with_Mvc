using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Ayarlar
    {
        public Nullable<bool> SatisAktif { get; set; }
        public Nullable<bool> BlogAktif { get; set; }
        public Nullable<bool> UyeliksizSatis { get; set; }
        public Nullable<bool> UyelikZorunlu { get; set; }
        public string GoogleClientID { get; set; }
        public string GoogleClientSecret { get; set; }
        public string FacebookAppID { get; set; }
        public string FacebookSecret { get; set; }
        public string TwitterApiID { get; set; }
        public string TwitterSecret { get; set; }
        public int DilID { get; set; }
        public int AcilisDili { get; set; }
        public string InstagramID { get; set; }
        public virtual Dil Dil { get; set; }
    }
}
