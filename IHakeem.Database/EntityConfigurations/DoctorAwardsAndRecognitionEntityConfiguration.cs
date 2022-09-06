using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class DoctorAwardsAndRecognitionEntityConfiguration : IEntityTypeConfiguration<DoctorAwardsAndRecognition>
    {
        public void Configure(EntityTypeBuilder<DoctorAwardsAndRecognition> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Title).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.Institute).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.City).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.State).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Country).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.AwardDate).IsRequired();

            builder.HasOne(entity => entity.Doctor)
             .WithMany(a => a.DoctorAwardsAndRecognition)
             .HasForeignKey(b => b.DoctorId);

        }
    }
}
