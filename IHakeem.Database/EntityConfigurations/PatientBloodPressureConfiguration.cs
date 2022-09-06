using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class PatientBloodPressureConfiguration
        : IEntityTypeConfiguration<PatientBloodPressure>
    {
        public void Configure(EntityTypeBuilder<PatientBloodPressure> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.Systolic).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.Diastolic).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();


            builder.Property(entity => entity.BloodPressureDateAndTime).HasColumnType("DateTime").IsRequired();
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                 .WithMany(a => a.PatientBloodPressure)
                 .HasForeignKey(b => b.PatientId);
        }
    }


}
