using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class BlogHaberLMap : EntityTypeConfiguration<BlogHaberL>
    {
        public BlogHaberLMap()
        {
            // Primary Key
            this.HasKey(t => new { t.BlogHaberID, t.DilID });

            // Properties
            this.Property(t => t.BlogHaberID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DilID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Baslik)
                .HasMaxLength(150);

            this.Property(t => t.Resim)
                .HasMaxLength(150);

            this.Property(t => t.Tarih)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("BlogHaberL");
            this.Property(t => t.BlogHaberID).HasColumnName("BlogHaberID");
            this.Property(t => t.DilID).HasColumnName("DilID");
            this.Property(t => t.Baslik).HasColumnName("Baslik");
            this.Property(t => t.Detay).HasColumnName("Detay");
            this.Property(t => t.Resim).HasColumnName("Resim");
            this.Property(t => t.Tarih).HasColumnName("Tarih");
            this.Property(t => t.KullaniciID).HasColumnName("KullaniciID");
            this.Property(t => t.Aktif).HasColumnName("Aktif");

            // Relationships
            this.HasRequired(t => t.BlogHaber)
                .WithMany(t => t.BlogHaberLs)
                .HasForeignKey(d => d.BlogHaberID);
            this.HasRequired(t => t.Dil)
                .WithMany(t => t.BlogHaberLs)
                .HasForeignKey(d => d.DilID);
            this.HasOptional(t => t.Kullanicilar)
                .WithMany(t => t.BlogHaberLs)
                .HasForeignKey(d => d.KullaniciID);

        }
    }
}
