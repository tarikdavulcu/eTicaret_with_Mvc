using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class MetinlerMap : EntityTypeConfiguration<Metinler>
    {
        public MetinlerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.GirisYazisiBaslik)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Metinler");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Hakkimizda).HasColumnName("Hakkimizda");
            this.Property(t => t.SatisSozlesmesi).HasColumnName("SatisSozlesmesi");
            this.Property(t => t.GizlilikPolitikasi).HasColumnName("GizlilikPolitikasi");
            this.Property(t => t.UyelikSozlesmesi).HasColumnName("UyelikSozlesmesi");
            this.Property(t => t.Iadeİptal).HasColumnName("Iadeİptal");
            this.Property(t => t.Bilgilendirme).HasColumnName("Bilgilendirme");
            this.Property(t => t.GirisYazisiBaslik).HasColumnName("GirisYazisiBaslik");
            this.Property(t => t.GirisYazisi).HasColumnName("GirisYazisi");
            this.Property(t => t.Vizyon).HasColumnName("Vizyon");
            this.Property(t => t.Misyon).HasColumnName("Misyon");
            this.Property(t => t.Strateji).HasColumnName("Strateji");
            this.Property(t => t.DilID).HasColumnName("DilID");

            // Relationships
            this.HasOptional(t => t.Dil)
                .WithMany(t => t.Metinlers)
                .HasForeignKey(d => d.DilID);

        }
    }
}
