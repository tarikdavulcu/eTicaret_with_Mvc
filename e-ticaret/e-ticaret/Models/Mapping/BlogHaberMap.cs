using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class BlogHaberMap : EntityTypeConfiguration<BlogHaber>
    {
        public BlogHaberMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Baslik)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("BlogHaber");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BlogKategoriID).HasColumnName("BlogKategoriID");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
            this.Property(t => t.Baslik).HasColumnName("Baslik");

            // Relationships
            this.HasOptional(t => t.BlogKategori)
                .WithMany(t => t.BlogHabers)
                .HasForeignKey(d => d.BlogKategoriID);

        }
    }
}
