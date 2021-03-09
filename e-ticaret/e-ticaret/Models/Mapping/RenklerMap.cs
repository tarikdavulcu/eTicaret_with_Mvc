using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class RenklerMap : EntityTypeConfiguration<Renkler>
    {
        public RenklerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RenkAdi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RenkKodu)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Renkler");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UrunID).HasColumnName("UrunID");
            this.Property(t => t.RenkAdi).HasColumnName("RenkAdi");
            this.Property(t => t.RenkKodu).HasColumnName("RenkKodu");
            this.Property(t => t.Aktif).HasColumnName("Aktif");

            // Relationships
            this.HasRequired(t => t.Urunler)
                .WithMany(t => t.Renklers)
                .HasForeignKey(d => d.UrunID);

        }
    }
}
