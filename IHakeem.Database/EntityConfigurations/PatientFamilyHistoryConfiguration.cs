using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class PatientFamilyHistoryConfiguration
        : IEntityTypeConfiguration<PatientFamilyHistory>
    {
        public void Configure(EntityTypeBuilder<PatientFamilyHistory> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.RelationId).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.DeceasedOrDeathAge).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.MedicalConditionsOrCauseOfDeath).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.Note).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                .WithMany(a => a.PatientFamilyHistory)
                .HasForeignKey(b => b.PatientId);
        }
    }


}
