using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class DoctorEntityConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {

            builder.HasKey(entity => entity.Id);

            builder.HasOne(entity => entity.User)
                .WithOne()
                .HasForeignKey<Doctor>(b => b.UserId)
                 .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.MaritialStatus)
               .WithMany()
                .HasPrincipalKey(x => x.Code)
               .HasForeignKey(x => x.MaritialStatusId);

            builder.Property(entity => entity.City).HasMaxLength(StringLengths.small);
            builder.Property(entity => entity.State).HasMaxLength(StringLengths.small);
            builder.Property(entity => entity.Country).HasMaxLength(StringLengths.small);
            builder.Property(entity => entity.PracticeCountry).HasMaxLength(StringLengths.small);
            builder.Property(entity => entity.HomePhoneNumber).HasMaxLength(StringLengths.Phone);
            builder.Property(entity => entity.FaxNumber).HasMaxLength(StringLengths.Phone);
            builder.Property(entity => entity.ZipCode).HasMaxLength(StringLengths.small);


        }
    }
}
