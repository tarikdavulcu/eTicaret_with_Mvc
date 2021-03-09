using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class EtiketMap : EntityTypeConfiguration<Etiket>
    {
        public EtiketMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Etiket");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");

            // Relationships
            this.HasMany(t => t.Urunlers)
                .WithMany(t => t.Etikets)
                .Map(m =>
                    {
                        m.ToTable("UrunEtiket");
                        m.MapLeftKey("EtiketID");
                        m.MapRightKey("UrunID");
                    });


        }
    }
}
