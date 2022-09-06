using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class PatientMedicalHistoryConfiguration
        : IEntityTypeConfiguration<PatientMedicalHistory>
    {
        public void Configure(EntityTypeBuilder<PatientMedicalHistory> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.DiseaseId).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            
            builder.Property(entity => entity.Note).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                 .WithMany(a => a.PatientMedicalHistory)
                 .HasForeignKey(b => b.PatientId);
        }
    }


}
