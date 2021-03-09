using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class Tedarikci_FirmalarMap : EntityTypeConfiguration<Tedarikci_Firmalar>
    {
        public Tedarikci_FirmalarMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.FirmaAdi)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Tedarikci_Firmalar");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FirmaAdi).HasColumnName("FirmaAdi");
        }
    }
}
