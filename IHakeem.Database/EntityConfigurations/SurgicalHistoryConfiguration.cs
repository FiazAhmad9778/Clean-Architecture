using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class SurgicalHistoryConfiguration
        : IEntityTypeConfiguration<SurgicalHistory>
    {
        public void Configure(EntityTypeBuilder<SurgicalHistory> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.SurgeryYear).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.SurgeryType).HasColumnType("NVARCHAR(500)").IsRequired();
            builder.Property(entity => entity.SurgeonName).HasColumnType("NVARCHAR(50)");
            builder.Property(entity => entity.SurgeryNotes).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                .WithMany(a => a.SurgicalHistory)
                .HasForeignKey(b => b.PatientId);
        }
    }


}
