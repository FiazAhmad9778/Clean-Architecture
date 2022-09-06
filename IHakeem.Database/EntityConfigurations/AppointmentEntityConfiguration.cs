using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class AppointmentEntityConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {

            builder.HasKey(entity => entity.Id);

            builder.HasOne(entity => entity.Doctor)
                .WithOne()
                .HasForeignKey<Appointment>(b => b.DoctorId)
                 .IsRequired()
                          .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(entity => entity.Patient)
               .WithOne()
               .HasForeignKey<Appointment>(b => b.PatientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.AppointmentStatus)
               .WithMany()
                .HasPrincipalKey(x => x.Code)
               .HasForeignKey(x => x.AppointmentStatusId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.AppointmentType)
              .WithMany()
               .HasPrincipalKey(x => x.Code)
              .HasForeignKey(x => x.AppointmentTypeId)
              .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
            builder.Property(entity => entity.ClinicLocation).HasMaxLength(StringLengths.Max).IsRequired(false);
            builder.Property(entity => entity.Notes).HasMaxLength(StringLengths.Max).IsRequired();
            builder.Property(entity => entity.AppointmentDate).HasColumnType("Date").IsRequired();
            builder.Property(entity => entity.StartTime).HasColumnType("Time").IsRequired();
            builder.Property(entity => entity.EndTime).HasColumnType("Time").IsRequired();
            builder.Property(entity => entity.FeeAmount).IsRequired();
        }

    }
}
