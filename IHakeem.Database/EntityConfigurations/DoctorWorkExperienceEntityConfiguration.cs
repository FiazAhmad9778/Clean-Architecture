using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class DoctorWorkExperienceEntityConfiguration : IEntityTypeConfiguration<DoctorWorkExperience>
    {
        public void Configure(EntityTypeBuilder<DoctorWorkExperience> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.HasOne(entity => entity.Doctor)
                 .WithMany(a => a.DoctorWorkExperience)
                 .HasForeignKey(b => b.DoctorId);


            builder.Property(entity => entity.City).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.State).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Country).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Contact).HasMaxLength(StringLengths.Phone).IsRequired();
            builder.Property(entity => entity.Email).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Fax).HasMaxLength(StringLengths.Phone).IsRequired();
            builder.Property(entity => entity.OrgnizationName).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.SuperVisor).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.OrgnizationName).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.Address).IsRequired();
            builder.Property(entity => entity.SuperVisor).IsRequired();
            builder.Property(entity => entity.StartDate).IsRequired();
            builder.Property(entity => entity.ISCurrentlyWorking).IsRequired();
            builder.Property(entity => entity.EndDate).IsRequired(false);

        }
    }
}
