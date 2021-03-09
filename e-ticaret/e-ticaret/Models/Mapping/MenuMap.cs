using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Menu");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
