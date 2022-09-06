using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class DoctorSkillsAndtrainingEntityConfiguration : IEntityTypeConfiguration<DoctorSkillsAndTraining>
    {
        public void Configure(EntityTypeBuilder<DoctorSkillsAndTraining> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.HasOne(entity => entity.Doctor)
               .WithMany(a => a.DoctorSkillsAndTraining)
               .HasForeignKey(b => b.DoctorId);

            builder.HasOne(x => x.EducationType)
               .WithMany()
                .HasPrincipalKey(x => x.Code)
               .HasForeignKey(x => x.EducationTypeId);

            builder.Property(entity => entity.City).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.State).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Country).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.SkillName).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.Institute).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.Adress).IsRequired();
            builder.Property(entity => entity.SuperVisor).IsRequired();
            builder.Property(entity => entity.StartDate).IsRequired();
            builder.Property(entity => entity.EndDate).IsRequired(false);

        }
    }
}
