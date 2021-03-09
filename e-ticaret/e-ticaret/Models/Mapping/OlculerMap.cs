using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class OlculerMap : EntityTypeConfiguration<Olculer>
    {
        public OlculerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.OlcuAdi)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Olculer");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UrunID).HasColumnName("UrunID");
            this.Property(t => t.OlcuAdi).HasColumnName("OlcuAdi");
            this.Property(t => t.Aktif).HasColumnName("Aktif");

            // Relationships
            this.HasRequired(t => t.Urunler)
                .WithMany(t => t.Olculers)
                .HasForeignKey(d => d.UrunID);

        }
    }
}
