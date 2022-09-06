using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class UserPhotoAttachmentEntityConfiguration : IEntityTypeConfiguration<UserPhotoAttachment>
    {
        public void Configure(EntityTypeBuilder<UserPhotoAttachment> builder)
        {

            builder.HasKey(entity => new { entity.FileId, entity.UserId });

        }
    }
}
