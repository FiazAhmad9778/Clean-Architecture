using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class PatientEntityConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {

            builder.HasKey(entity => entity.Id);

            builder.HasOne(entity => entity.User)
                .WithOne()
                .HasForeignKey<Patient>(b => b.UserId)
                 .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.PreferedLanguage)
               .WithMany()
                .HasPrincipalKey(x => x.Code)
               .HasForeignKey(x => x.PreferedLanguageId);
            builder.HasOne(x => x.Ethnicity)
               .WithMany()
                .HasPrincipalKey(x => x.Code)
               .HasForeignKey(x => x.EthnicityId);
            builder.HasOne(x => x.BloodGroup)
               .WithMany()
                .HasPrincipalKey(x => x.Code)
               .HasForeignKey(x => x.BloodGroupId);

            builder.HasOne(x => x.MaritialStatus)
               .WithMany()
                .HasPrincipalKey(x => x.Code)
               .HasForeignKey(x => x.MaritialStatusId);

            builder.HasOne(x => x.Country)
               .WithMany()
                .HasPrincipalKey(x => x.Code)
               .HasForeignKey(x => x.CountryId);

            builder.HasOne(x => x.State)
               .WithMany()
                .HasPrincipalKey(x => x.Code)
               .HasForeignKey(x => x.StateId);

            builder.HasOne(x => x.City)
               .WithMany()
                .HasPrincipalKey(x => x.Code)
               .HasForeignKey(x => x.CityId);


            builder.Property(entity => entity.CityId).HasMaxLength(450);
            builder.Property(entity => entity.StateId).HasMaxLength(450);
            builder.Property(entity => entity.CountryId).HasMaxLength(450);
            builder.Property(entity => entity.HomeContact).HasMaxLength(StringLengths.Phone);
            builder.Property(entity => entity.WorkContact).HasMaxLength(StringLengths.Phone);
            builder.Property(entity => entity.ZipCode).HasMaxLength(StringLengths.small);


        }
    }
}
