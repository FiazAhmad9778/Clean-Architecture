using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class DoctorSocialInformationEntityConfiguration : IEntityTypeConfiguration<DoctorSocialInfo>
    {
        public void Configure(EntityTypeBuilder<DoctorSocialInfo> builder)
        {

            builder.HasKey(x => new { x.SocialInformationId, x.DoctorId });
            builder.HasOne(entity => entity.Doctor)
               .WithMany(a => a.SocialInformation)
               .HasForeignKey(b => b.DoctorId);

            builder.HasOne(entity => entity.SocialInformation)
               .WithOne()
               .HasForeignKey<DoctorSocialInfo>(b => b.SocialInformationId);
        }
    }
}
