using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Database.EntityConfigurations
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne(entity => entity.Gender)
                .WithMany()
                .HasForeignKey(b => b.GenderId)
                .HasPrincipalKey(x=>x.Code);

            builder.HasOne(entity => entity.Title)
               .WithMany()
               .HasForeignKey(b => b.TitleId)
               .HasPrincipalKey(x => x.Code);

            builder
                 .HasOne(x => x.Photo)
                 .WithOne()
                 .HasForeignKey<UserPhotoAttachment>(x => x.UserId)
                 .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}