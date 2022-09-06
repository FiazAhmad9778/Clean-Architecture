using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class UserVerificationCodeConfiguration : IEntityTypeConfiguration<UserVerificationCode>
    {
        public void Configure(EntityTypeBuilder<UserVerificationCode> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Code).HasMaxLength(StringLengths.small).IsRequired();
        }
    }
}
