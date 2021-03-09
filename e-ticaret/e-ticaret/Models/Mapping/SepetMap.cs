using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class SepetMap : EntityTypeConfiguration<Sepet>
    {
        public SepetMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Tarih)
                .HasMaxLength(50);

            this.Property(t => t.Cookie)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Sepet");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Tarih).HasColumnName("Tarih");
            this.Property(t => t.Cookie).HasColumnName("Cookie");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
        }
    }
}
