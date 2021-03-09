using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class OdemeDetayMap : EntityTypeConfiguration<OdemeDetay>
    {
        public OdemeDetayMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.OdemeTuru)
                .HasMaxLength(50);

            this.Property(t => t.Aciklama)
                .HasMaxLength(250);

            this.Property(t => t.IpAdresi)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OdemeDetay");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SepetID).HasColumnName("SepetID");
            this.Property(t => t.OdemeTuru).HasColumnName("OdemeTuru");
            this.Property(t => t.ToplamTurtar).HasColumnName("ToplamTurtar");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.IpAdresi).HasColumnName("IpAdresi");
        }
    }
}
