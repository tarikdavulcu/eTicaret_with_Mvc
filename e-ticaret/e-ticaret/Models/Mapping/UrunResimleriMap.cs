using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class UrunResimleriMap : EntityTypeConfiguration<UrunResimleri>
    {
        public UrunResimleriMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Resim)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("UrunResimleri");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Resim).HasColumnName("Resim");
            this.Property(t => t.SiraNo).HasColumnName("SiraNo");
            this.Property(t => t.UrunID).HasColumnName("UrunID");

            // Relationships
            this.HasRequired(t => t.Urunler)
                .WithMany(t => t.UrunResimleris)
                .HasForeignKey(d => d.UrunID);

        }
    }
}
