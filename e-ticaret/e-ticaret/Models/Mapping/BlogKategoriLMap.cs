using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class BlogKategoriLMap : EntityTypeConfiguration<BlogKategoriL>
    {
        public BlogKategoriLMap()
        {
            // Primary Key
            this.HasKey(t => new { t.BlogKategoriID, t.DilID });

            // Properties
            this.Property(t => t.BlogKategoriID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DilID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Adi)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("BlogKategoriL");
            this.Property(t => t.BlogKategoriID).HasColumnName("BlogKategoriID");
            this.Property(t => t.DilID).HasColumnName("DilID");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
            this.Property(t => t.Adi).HasColumnName("Adi");

            // Relationships
            this.HasRequired(t => t.BlogKategori)
                .WithMany(t => t.BlogKategoriLs)
                .HasForeignKey(d => d.BlogKategoriID);
            this.HasRequired(t => t.Dil)
                .WithMany(t => t.BlogKategoriLs)
                .HasForeignKey(d => d.DilID);

        }
    }
}
