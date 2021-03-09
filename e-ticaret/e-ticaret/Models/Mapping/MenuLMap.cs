using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class MenuLMap : EntityTypeConfiguration<MenuL>
    {
        public MenuLMap()
        {
            // Primary Key
            this.HasKey(t => new { t.MID, t.DID, t.Adi });

            // Properties
            this.Property(t => t.MID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.SeoLink)
                .HasMaxLength(250);

            this.Property(t => t.URL)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("MenuL");
            this.Property(t => t.MID).HasColumnName("MID");
            this.Property(t => t.DID).HasColumnName("DID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.SeoLink).HasColumnName("SeoLink");
            this.Property(t => t.URL).HasColumnName("URL");

            // Relationships
            this.HasRequired(t => t.Dil)
                .WithMany(t => t.MenuLs)
                .HasForeignKey(d => d.DID);
            this.HasRequired(t => t.Menu)
                .WithMany(t => t.MenuLs)
                .HasForeignKey(d => d.MID);

        }
    }
}
