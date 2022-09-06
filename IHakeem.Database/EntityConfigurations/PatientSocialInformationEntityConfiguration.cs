using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class PatientSocialInformationEntityConfiguration : IEntityTypeConfiguration<PatientSocialInfo>
    {
        public void Configure(EntityTypeBuilder<PatientSocialInfo> builder)
        {

            builder.HasKey(x => new { x.SocialInformationId, x.PatientId });
            builder.HasOne(entity => entity.Patient)
               .WithMany(a => a.SocialInformation)
               .HasForeignKey(b => b.PatientId);

            builder.HasOne(entity => entity.SocialInformation)
                 .WithOne()
                .HasPrincipalKey<SocialInfo>(x => x.Id)
               .HasForeignKey<PatientSocialInfo>(b => b.SocialInformationId);
        }
    }
}
