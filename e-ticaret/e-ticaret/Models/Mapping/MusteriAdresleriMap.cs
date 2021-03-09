using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class MusteriAdresleriMap : EntityTypeConfiguration<MusteriAdresleri>
    {
        public MusteriAdresleriMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adres)
                .HasMaxLength(150);

            this.Property(t => t.Adres1)
                .HasMaxLength(150);

            this.Property(t => t.Sehir)
                .HasMaxLength(50);

            this.Property(t => t.Ulke)
                .HasMaxLength(50);

            this.Property(t => t.PostaKodu)
                .HasMaxLength(50);

            this.Property(t => t.Tel)
                .HasMaxLength(50);

            this.Property(t => t.Fax)
                .HasMaxLength(50);

            this.Property(t => t.Mail)
                .HasMaxLength(50);

            this.Property(t => t.Adi)
                .HasMaxLength(50);

            this.Property(t => t.Soyadi)
                .HasMaxLength(50);

            this.Property(t => t.Sirket)
                .HasMaxLength(150);

            this.Property(t => t.SirketUnvani)
                .HasMaxLength(150);

            this.Property(t => t.Adresİsmi)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MusteriAdresleri");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.MID).HasColumnName("MID");
            this.Property(t => t.Adres).HasColumnName("Adres");
            this.Property(t => t.Adres1).HasColumnName("Adres1");
            this.Property(t => t.Sehir).HasColumnName("Sehir");
            this.Property(t => t.Ulke).HasColumnName("Ulke");
            this.Property(t => t.PostaKodu).HasColumnName("PostaKodu");
            this.Property(t => t.Tel).HasColumnName("Tel");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Soyadi).HasColumnName("Soyadi");
            this.Property(t => t.Sirket).HasColumnName("Sirket");
            this.Property(t => t.SirketUnvani).HasColumnName("SirketUnvani");
            this.Property(t => t.Adresİsmi).HasColumnName("Adresİsmi");
        }
    }
}
