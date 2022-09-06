using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class DoctorMembershipEntityConfiguration : IEntityTypeConfiguration<DoctorMembership>
    {
        public void Configure(EntityTypeBuilder<DoctorMembership> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Designation).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.CurrentlyMember).IsRequired();
            builder.Property(entity => entity.City).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.State).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Country).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.StartDate).IsRequired();
            builder.Property(entity => entity.EndDate).IsRequired(false);

            builder.HasOne(entity => entity.Doctor)
             .WithMany(a => a.DoctorMembership)
             .HasForeignKey(b => b.DoctorId);

        }
    }
}
