using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class PulseOximeterConfiguration
        : IEntityTypeConfiguration<PulseOximeter>
    {
        public void Configure(EntityTypeBuilder<PulseOximeter> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.BloodOxygen).HasColumnType("FLOAT").IsRequired();
            builder.Property(entity => entity.PulseRate).HasColumnType("FLOAT").IsRequired();

            builder.Property(entity => entity.PulseOximeterDateAndTime).HasColumnType("DateTime").IsRequired();
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                 .WithMany(a => a.PulseOximeter)
                 .HasForeignKey(b => b.PatientId);
        }
    }


}
