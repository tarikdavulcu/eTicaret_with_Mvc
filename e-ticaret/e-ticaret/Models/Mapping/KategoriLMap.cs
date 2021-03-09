using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class KategoriLMap : EntityTypeConfiguration<KategoriL>
    {
        public KategoriLMap()
        {
            // Primary Key
            this.HasKey(t => new { t.KID, t.DID, t.Adi, t.Aciklama, t.Seolink });

            // Properties
            this.Property(t => t.KID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Aciklama)
                .IsRequired();

            this.Property(t => t.Seolink)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("KategoriL");
            this.Property(t => t.KID).HasColumnName("KID");
            this.Property(t => t.DID).HasColumnName("DID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.Seolink).HasColumnName("Seolink");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
            this.Property(t => t.SiraNo).HasColumnName("SiraNo");

            // Relationships
            this.HasRequired(t => t.Dil)
                .WithMany(t => t.KategoriLs)
                .HasForeignKey(d => d.DID);
            this.HasRequired(t => t.Kategori)
                .WithMany(t => t.KategoriLs)
                .HasForeignKey(d => d.KID);

        }
    }
}
