using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class PromosyonMap : EntityTypeConfiguration<Promosyon>
    {
        public PromosyonMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Resim)
                .HasMaxLength(150);

            this.Property(t => t.URL)
                .HasMaxLength(150);

            this.Property(t => t.Adi)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Promosyon");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Resim).HasColumnName("Resim");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.SiraNo).HasColumnName("SiraNo");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
            this.Property(t => t.OlcuY).HasColumnName("OlcuY");
            this.Property(t => t.OlcuX).HasColumnName("OlcuX");
        }
    }
}
