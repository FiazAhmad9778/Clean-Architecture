using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class CultureEntityConfiguration : IEntityTypeConfiguration<Culture>
    {
        public void Configure(EntityTypeBuilder<Culture> builder)
        {
            builder.HasKey(e => e.Code);
            builder.Property(entity => entity.Code)
              .HasMaxLength(StringLengths.Default)
              .IsRequired()
              .IsUnicode(true);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(64);
            builder.ToTable("Cultures");
        }

    }
}
