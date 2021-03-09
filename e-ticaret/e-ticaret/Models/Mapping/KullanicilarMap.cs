using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class KullanicilarMap : EntityTypeConfiguration<Kullanicilar>
    {
        public KullanicilarMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.KullaniciAdi)
                .HasMaxLength(150);

            this.Property(t => t.KullaniciSifre)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Kullanicilar");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RolID).HasColumnName("RolID");
            this.Property(t => t.KullaniciAdi).HasColumnName("KullaniciAdi");
            this.Property(t => t.KullaniciSifre).HasColumnName("KullaniciSifre");
            this.Property(t => t.Aktif).HasColumnName("Aktif");

            // Relationships
            this.HasRequired(t => t.KullaniciRol)
                .WithMany(t => t.Kullanicilars)
                .HasForeignKey(d => d.RolID);

        }
    }
}
