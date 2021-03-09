using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class Urun_YorumlariMap : EntityTypeConfiguration<Urun_Yorumlari>
    {
        public Urun_YorumlariMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.YorumuYazan)
                .HasMaxLength(50);

            this.Property(t => t.Mail)
                .HasMaxLength(50);

            this.Property(t => t.Tarih)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Urun_Yorumlari");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UrunID).HasColumnName("UrunID");
            this.Property(t => t.Yorum).HasColumnName("Yorum");
            this.Property(t => t.YorumuYazan).HasColumnName("YorumuYazan");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.Tarih).HasColumnName("Tarih");

            // Relationships
            this.HasRequired(t => t.Urunler)
                .WithMany(t => t.Urun_Yorumlari)
                .HasForeignKey(d => d.UrunID);

        }
    }
}
