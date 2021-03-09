using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class Sepet_DetayMap : EntityTypeConfiguration<Sepet_Detay>
    {
        public Sepet_DetayMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Tarih)
                .HasMaxLength(50);

            this.Property(t => t.Renk)
                .HasMaxLength(50);

            this.Property(t => t.Beden)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Sepet_Detay");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SepetID).HasColumnName("SepetID");
            this.Property(t => t.MID).HasColumnName("MID");
            this.Property(t => t.UrunID).HasColumnName("UrunID");
            this.Property(t => t.Adet).HasColumnName("Adet");
            this.Property(t => t.Fiyat).HasColumnName("Fiyat");
            this.Property(t => t.IndirimOrani).HasColumnName("IndirimOrani");
            this.Property(t => t.Tarih).HasColumnName("Tarih");
            this.Property(t => t.Renk).HasColumnName("Renk");
            this.Property(t => t.Beden).HasColumnName("Beden");

            // Relationships
            this.HasRequired(t => t.Sepet)
                .WithMany(t => t.Sepet_Detay)
                .HasForeignKey(d => d.SepetID);
            this.HasRequired(t => t.Urunler)
                .WithMany(t => t.Sepet_Detay)
                .HasForeignKey(d => d.UrunID);

        }
    }
}
