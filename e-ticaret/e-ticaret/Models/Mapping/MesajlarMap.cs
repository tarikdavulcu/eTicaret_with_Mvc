using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace e_ticaret.Models.Mapping
{
    public class MesajlarMap : EntityTypeConfiguration<Mesajlar>
    {
        public MesajlarMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Gonderen)
                .HasMaxLength(150);

            this.Property(t => t.Mail)
                .HasMaxLength(50);

            this.Property(t => t.Tel)
                .HasMaxLength(50);

            this.Property(t => t.Mesaj)
                .HasMaxLength(350);

            // Table & Column Mappings
            this.ToTable("Mesajlar");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Gonderen).HasColumnName("Gonderen");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.Tel).HasColumnName("Tel");
            this.Property(t => t.Mesaj).HasColumnName("Mesaj");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
