using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class PatientMedicationEntityConfiguration : IEntityTypeConfiguration<PatientMedication>
    {
        public void Configure(EntityTypeBuilder<PatientMedication> builder)
        {

            builder.HasKey(entity => entity.Id);

            builder.HasOne(entity => entity.Doctor)
                .WithMany()
                .HasForeignKey(b => b.DoctorId)
                 .IsRequired()
                          .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(entity => entity.Patient)
               .WithMany()
               .HasForeignKey(b => b.PatientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(entity => entity.Appointment)
              .WithMany()
              .HasForeignKey(b => b.AppointmentId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

            builder.Property(entity => entity.Dose).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.Frequency).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.Unit).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.Medication).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.MedicationComments).HasMaxLength(StringLengths.Max);

            builder.Property(entity => entity.StartDate).HasColumnType("Date").IsRequired();
            builder.Property(entity => entity.StopDate).HasColumnType("Date").IsRequired(false);
            builder.Property(entity => entity.CreatedDate).HasColumnType("Date").IsRequired();
            builder.Property(entity => entity.CreatedBy).IsRequired();
            builder.Property(entity => entity.UpdatedDate).HasColumnType("Date").IsRequired(false);
        }

    }
}
