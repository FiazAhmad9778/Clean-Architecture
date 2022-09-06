using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class SocialInformationEntityConfiguration : IEntityTypeConfiguration<SocialInfo>
    {
        public void Configure(EntityTypeBuilder<SocialInfo> builder)
        {

            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Name).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Url).HasMaxLength(StringLengths.Default).IsRequired();
        }
    }
}
