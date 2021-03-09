using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class MarkalarMap : EntityTypeConfiguration<Markalar>
    {
        public MarkalarMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.MarkaAdi)
                .HasMaxLength(150);

            this.Property(t => t.Resim)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Markalar");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.MarkaAdi).HasColumnName("MarkaAdi");
            this.Property(t => t.Resim).HasColumnName("Resim");
            this.Property(t => t.SiraNo).HasColumnName("SiraNo");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
        }
    }
}
