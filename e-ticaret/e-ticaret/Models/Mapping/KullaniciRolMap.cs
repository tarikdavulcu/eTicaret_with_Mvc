using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class KullaniciRolMap : EntityTypeConfiguration<KullaniciRol>
    {
        public KullaniciRolMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RoleName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("KullaniciRol");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
        }
    }
}
