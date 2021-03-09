using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class BedenlerMap : EntityTypeConfiguration<Bedenler>
    {
        public BedenlerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.BedenAdi)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Bedenler");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UrunID).HasColumnName("UrunID");
            this.Property(t => t.BedenAdi).HasColumnName("BedenAdi");
            this.Property(t => t.Aktif).HasColumnName("Aktif");

            // Relationships
            this.HasOptional(t => t.Urunler)
                .WithMany(t => t.Bedenlers)
                .HasForeignKey(d => d.UrunID);

        }
    }
}
