using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class KategoriMap : EntityTypeConfiguration<Kategori>
    {
        public KategoriMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Resim)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Kategori");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Resim).HasColumnName("Resim");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
        }
    }
}
