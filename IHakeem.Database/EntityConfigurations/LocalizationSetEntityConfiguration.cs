using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class LocalizationSetEntityConfiguration : IEntityTypeConfiguration<LocalizationSet>
    {
        public void Configure(EntityTypeBuilder<LocalizationSet> builder)
        {

            builder.HasKey(e => e.Id);
            builder.ToTable("LocalizationSets");


        }

    }
}
