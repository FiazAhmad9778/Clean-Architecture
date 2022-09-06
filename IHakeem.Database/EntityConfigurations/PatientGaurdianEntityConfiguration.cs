using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    class PatientGaurdianEntityConfiguration : IEntityTypeConfiguration<PatientGaurdian>
    {
        public void Configure(EntityTypeBuilder<PatientGaurdian> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.HasOne(entity => entity.Patient)
               .WithMany(a => a.Gaurdian)
               .HasForeignKey(b => b.PatientId);

            builder.HasOne(x => x.Relation)
                  .WithMany()
                   .HasPrincipalKey(x => x.Code)
                  .HasForeignKey(x => x.RelationId);
            builder.Property(entity => entity.CellPhone).HasMaxLength(StringLengths.Phone).IsRequired();
            builder.Property(entity => entity.State).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.City).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Country).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Email).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.HomeContact).HasMaxLength(StringLengths.Phone).IsRequired();
            builder.Property(entity => entity.WorkContact).HasMaxLength(StringLengths.Phone).IsRequired();
            builder.Property(entity => entity.ZipCode).HasMaxLength(StringLengths.small).IsRequired();
        }
    }
}