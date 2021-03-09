using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using e_ticaret.Models.Mapping;

namespace e_ticaret.Models
{
    public partial class eTicaretContext : DbContext
    {
        static eTicaretContext()
        {
            Database.SetInitializer<eTicaretContext>(null);
        }

        public eTicaretContext()
            : base("Name=eTicaretContext")
        {
        }

        public DbSet<Ayarlar> Ayarlars { get; set; }
        public DbSet<Bedenler> Bedenlers { get; set; }
        public DbSet<BlogHaber> BlogHabers { get; set; }
        public DbSet<BlogHaberL> BlogHaberLs { get; set; }
        public DbSet<BlogKategori> BlogKategoris { get; set; }
        public DbSet<BlogKategoriL> BlogKategoriLs { get; set; }
        public DbSet<Dil> Dils { get; set; }
        public DbSet<Etiket> Etikets { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<KategoriL> KategoriLs { get; set; }
        public DbSet<Kullanicilar> Kullanicilars { get; set; }
        public DbSet<KullaniciRol> KullaniciRols { get; set; }
        public DbSet<Markalar> Markalars { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuL> MenuLs { get; set; }
        public DbSet<Mesajlar> Mesajlars { get; set; }
        public DbSet<Metinler> Metinlers { get; set; }
        public DbSet<MusteriAdresleri> MusteriAdresleris { get; set; }
        public DbSet<Musteriler> Musterilers { get; set; }
        public DbSet<OdemeDetay> OdemeDetays { get; set; }
        public DbSet<Olculer> Olculers { get; set; }
        public DbSet<Promosyon> Promosyons { get; set; }
        public DbSet<Renkler> Renklers { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<Sepet_Detay> Sepet_Detay { get; set; }
        public DbSet<SiteBilgileri> SiteBilgileris { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Tedarikci_Firmalar> Tedarikci_Firmalar { get; set; }
        public DbSet<Urun_Yorumlari> Urun_Yorumlari { get; set; }
        public DbSet<UrunFiyatlari> UrunFiyatlaris { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }
        public DbSet<UrunlerL> UrunlerLs { get; set; }
        public DbSet<UrunResimleri> UrunResimleris { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AyarlarMap());
            modelBuilder.Configurations.Add(new BedenlerMap());
            modelBuilder.Configurations.Add(new BlogHaberMap());
            modelBuilder.Configurations.Add(new BlogHaberLMap());
            modelBuilder.Configurations.Add(new BlogKategoriMap());
            modelBuilder.Configurations.Add(new BlogKategoriLMap());
            modelBuilder.Configurations.Add(new DilMap());
            modelBuilder.Configurations.Add(new EtiketMap());
            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new KategoriLMap());
            modelBuilder.Configurations.Add(new KullanicilarMap());
            modelBuilder.Configurations.Add(new KullaniciRolMap());
            modelBuilder.Configurations.Add(new MarkalarMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new MenuLMap());
            modelBuilder.Configurations.Add(new MesajlarMap());
            modelBuilder.Configurations.Add(new MetinlerMap());
            modelBuilder.Configurations.Add(new MusteriAdresleriMap());
            modelBuilder.Configurations.Add(new MusterilerMap());
            modelBuilder.Configurations.Add(new OdemeDetayMap());
            modelBuilder.Configurations.Add(new OlculerMap());
            modelBuilder.Configurations.Add(new PromosyonMap());
            modelBuilder.Configurations.Add(new RenklerMap());
            modelBuilder.Configurations.Add(new SepetMap());
            modelBuilder.Configurations.Add(new Sepet_DetayMap());
            modelBuilder.Configurations.Add(new SiteBilgileriMap());
            modelBuilder.Configurations.Add(new SliderMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new Tedarikci_FirmalarMap());
            modelBuilder.Configurations.Add(new Urun_YorumlariMap());
            modelBuilder.Configurations.Add(new UrunFiyatlariMap());
            modelBuilder.Configurations.Add(new UrunlerMap());
            modelBuilder.Configurations.Add(new UrunlerLMap());
            modelBuilder.Configurations.Add(new UrunResimleriMap());
        }
    }
}
