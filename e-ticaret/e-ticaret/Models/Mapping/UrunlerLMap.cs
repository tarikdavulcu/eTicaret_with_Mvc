using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class UrunlerLMap : EntityTypeConfiguration<UrunlerL>
    {
        public UrunlerLMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UrunAdi, t.DilID, t.UrunID });

            // Properties
            this.Property(t => t.UrunAdi)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.DilID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UrunID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SeoLink)
                .HasMaxLength(250);

            this.Property(t => t.MetaTit)
                .HasMaxLength(250);

            this.Property(t => t.MetaKey)
                .HasMaxLength(250);

            this.Property(t => t.MetaDes)
                .HasMaxLength(250);

            this.Property(t => t.Resim)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UrunlerL");
            this.Property(t => t.UrunAdi).HasColumnName("UrunAdi");
            this.Property(t => t.DilID).HasColumnName("DilID");
            this.Property(t => t.UrunID).HasColumnName("UrunID");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.SiraNo).HasColumnName("SiraNo");
            this.Property(t => t.SeoLink).HasColumnName("SeoLink");
            this.Property(t => t.Fiyat).HasColumnName("Fiyat");
            this.Property(t => t.KDV).HasColumnName("KDV");
            this.Property(t => t.MetaTit).HasColumnName("MetaTit");
            this.Property(t => t.MetaKey).HasColumnName("MetaKey");
            this.Property(t => t.MetaDes).HasColumnName("MetaDes");
            this.Property(t => t.Resim).HasColumnName("Resim");
            this.Property(t => t.TeknikAciklama).HasColumnName("TeknikAciklama");
            this.Property(t => t.TeknikAciklamaDevam).HasColumnName("TeknikAciklamaDevam");
            this.Property(t => t.TeknikDetay).HasColumnName("TeknikDetay");

            // Relationships
            this.HasRequired(t => t.Dil)
                .WithMany(t => t.UrunlerLs)
                .HasForeignKey(d => d.DilID);
            this.HasRequired(t => t.Urunler)
                .WithMany(t => t.UrunlerLs)
                .HasForeignKey(d => d.UrunID);

        }
    }
}
