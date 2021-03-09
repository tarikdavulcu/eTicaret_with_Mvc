using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class UrunlerMap : EntityTypeConfiguration<Urunler>
    {
        public UrunlerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.UrunAdi)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.UrunKodu)
                .HasMaxLength(50);

            this.Property(t => t.Barkod)
                .HasMaxLength(50);

            this.Property(t => t.Resim)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Urunler");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UrunAdi).HasColumnName("UrunAdi");
            this.Property(t => t.KategoriID).HasColumnName("KategoriID");
            this.Property(t => t.TedarikciID).HasColumnName("TedarikciID");
            this.Property(t => t.MarkaID).HasColumnName("MarkaID");
            this.Property(t => t.UrunKodu).HasColumnName("UrunKodu");
            this.Property(t => t.Barkod).HasColumnName("Barkod");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
            this.Property(t => t.Resim).HasColumnName("Resim");

            // Relationships
            this.HasRequired(t => t.Kategori)
                .WithMany(t => t.Urunlers)
                .HasForeignKey(d => d.KategoriID);
            this.HasOptional(t => t.Markalar)
                .WithMany(t => t.Urunlers)
                .HasForeignKey(d => d.MarkaID);

        }
    }
}
