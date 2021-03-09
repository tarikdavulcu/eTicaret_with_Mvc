using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class DilMap : EntityTypeConfiguration<Dil>
    {
        public DilMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.KisaAdi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Resim)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Dil");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.KisaAdi).HasColumnName("KisaAdi");
            this.Property(t => t.Resim).HasColumnName("Resim");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
        }
    }
}
