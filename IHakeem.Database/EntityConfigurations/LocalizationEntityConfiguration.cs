using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class LocalizationEntityConfiguration : IEntityTypeConfiguration<Localization>
    {
        public void Configure(EntityTypeBuilder<Localization> builder)
        {
            builder.HasKey(e => new { e.LocalizationSetId, e.CultureCode });
            builder.Property(entity => entity.CultureCode)
               .HasMaxLength(StringLengths.Default)
               .IsRequired()
               .IsUnicode(true);
            builder.Property(entity => entity.Value)
               .HasMaxLength(StringLengths.Default)
               .IsRequired()
               .IsUnicode(true);
            builder.ToTable("Localizations");
        }

    }
}
