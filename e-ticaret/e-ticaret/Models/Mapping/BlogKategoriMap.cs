using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class BlogKategoriMap : EntityTypeConfiguration<BlogKategori>
    {
        public BlogKategoriMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("BlogKategori");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
        }
    }
}
