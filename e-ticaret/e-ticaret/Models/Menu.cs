using System;
using System.Collections.Generic;

namespace e_ticaret.Models
{
    public partial class Menu
    {
        public Menu()
        {
            this.MenuLs = new List<MenuL>();
        }

        public int ID { get; set; }
        public string Adi { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<MenuL> MenuLs { get; set; }
    }
}
