using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class CurrentMedicationConfiguration
        : IEntityTypeConfiguration<CurrentMedication>
    {
        public void Configure(EntityTypeBuilder<CurrentMedication> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.MedicineId).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.ReasonForTakingMedicine).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.Dose).HasColumnType("NVARCHAR(50)");
            builder.Property(entity => entity.DoseFrequentId).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.DoctorName).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.DoctorNumber).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.PharmacyName).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.PharmacyNumber).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.Note).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.Property(entity => entity.AsNeeded).HasColumnType("bit");

            builder.HasOne(entity => entity.PatientDetails)
                .WithMany(a => a.CurrentMedication)
                .HasForeignKey(b => b.PatientId);
        }
    }


}
