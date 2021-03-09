using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class SliderMap : EntityTypeConfiguration<Slider>
    {
        public SliderMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .HasMaxLength(150);

            this.Property(t => t.Resim)
                .HasMaxLength(150);

            this.Property(t => t.BaslikIcerik)
                .HasMaxLength(150);

            this.Property(t => t.BaslikEk)
                .HasMaxLength(150);

            this.Property(t => t.ButtonName)
                .HasMaxLength(150);

            this.Property(t => t.URL)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Slider");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Resim).HasColumnName("Resim");
            this.Property(t => t.BaslikIcerik).HasColumnName("BaslikIcerik");
            this.Property(t => t.BaslikEk).HasColumnName("BaslikEk");
            this.Property(t => t.ButtonName).HasColumnName("ButtonName");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
        }
    }
}
