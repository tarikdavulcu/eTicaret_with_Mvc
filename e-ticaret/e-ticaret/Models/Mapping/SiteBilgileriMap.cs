using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class SiteBilgileriMap : EntityTypeConfiguration<SiteBilgileri>
    {
        public SiteBilgileriMap()
        {
            // Primary Key
            this.HasKey(t => new { t.FirmaAdi, t.DilID });

            // Properties
            this.Property(t => t.FirmaAdi)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Adres)
                .HasMaxLength(250);

            this.Property(t => t.Ulke)
                .HasMaxLength(50);

            this.Property(t => t.Sehir)
                .HasMaxLength(50);

            this.Property(t => t.Ilce)
                .HasMaxLength(50);

            this.Property(t => t.Tel)
                .HasMaxLength(50);

            this.Property(t => t.Faks)
                .HasMaxLength(50);

            this.Property(t => t.MobilTel)
                .HasMaxLength(50);

            this.Property(t => t.Mail)
                .HasMaxLength(50);

            this.Property(t => t.URL)
                .HasMaxLength(50);

            this.Property(t => t.SiteLogo)
                .HasMaxLength(150);

            this.Property(t => t.DilID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("SiteBilgileri");
            this.Property(t => t.FirmaAdi).HasColumnName("FirmaAdi");
            this.Property(t => t.Adres).HasColumnName("Adres");
            this.Property(t => t.Ulke).HasColumnName("Ulke");
            this.Property(t => t.Sehir).HasColumnName("Sehir");
            this.Property(t => t.Ilce).HasColumnName("Ilce");
            this.Property(t => t.Tel).HasColumnName("Tel");
            this.Property(t => t.Faks).HasColumnName("Faks");
            this.Property(t => t.MobilTel).HasColumnName("MobilTel");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.KeyWords).HasColumnName("KeyWords");
            this.Property(t => t.HaritaKodu).HasColumnName("HaritaKodu");
            this.Property(t => t.SiteLogo).HasColumnName("SiteLogo");
            this.Property(t => t.DilID).HasColumnName("DilID");

            // Relationships
            this.HasRequired(t => t.Dil)
                .WithMany(t => t.SiteBilgileris)
                .HasForeignKey(d => d.DilID);

        }
    }
}
