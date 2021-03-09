using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class MenuL
    {
        public int MID { get; set; }
        public int DID { get; set; }
        public string Adi { get; set; }
        public string SeoLink { get; set; }
        public string URL { get; set; }
        public virtual Dil Dil { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
