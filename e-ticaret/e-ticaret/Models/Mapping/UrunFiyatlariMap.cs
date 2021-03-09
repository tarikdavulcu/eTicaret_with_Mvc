using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class UrunFiyatlariMap : EntityTypeConfiguration<UrunFiyatlari>
    {
        public UrunFiyatlariMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DilID, t.UrunID });

            // Properties
            this.Property(t => t.DilID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UrunID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ParaBirimi)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("UrunFiyatlari");
            this.Property(t => t.DilID).HasColumnName("DilID");
            this.Property(t => t.UrunID).HasColumnName("UrunID");
            this.Property(t => t.KDV).HasColumnName("KDV");
            this.Property(t => t.NakitIndirim).HasColumnName("NakitIndirim");
            this.Property(t => t.KampanyaIndirim).HasColumnName("KampanyaIndirim");
            this.Property(t => t.OzelIndirim).HasColumnName("OzelIndirim");
            this.Property(t => t.KargoIndirimi).HasColumnName("KargoIndirimi");
            this.Property(t => t.Fiyat).HasColumnName("Fiyat");
            this.Property(t => t.TaksitliFiyat).HasColumnName("TaksitliFiyat");
            this.Property(t => t.ParaBirimi).HasColumnName("ParaBirimi");
        }
    }
}
