using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class MusterilerMap : EntityTypeConfiguration<Musteriler>
    {
        public MusterilerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .HasMaxLength(50);

            this.Property(t => t.Soyadi)
                .HasMaxLength(50);

            this.Property(t => t.KullaniciAdi)
                .HasMaxLength(150);

            this.Property(t => t.Sifre)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Musteriler");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Soyadi).HasColumnName("Soyadi");
            this.Property(t => t.KullaniciAdi).HasColumnName("KullaniciAdi");
            this.Property(t => t.Sifre).HasColumnName("Sifre");
        }
    }
}
