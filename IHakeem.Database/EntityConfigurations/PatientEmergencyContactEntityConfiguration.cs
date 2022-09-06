using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class PatientEmergencyContactEntityConfiguration : IEntityTypeConfiguration<PatientEmergencyContact>
    {
        public void Configure(EntityTypeBuilder<PatientEmergencyContact> builder)
        {

            builder.HasKey(entity => entity.Id);
            builder.HasOne(entity => entity.Patient)
               .WithMany(a => a.EmergencyContact)
               .HasForeignKey(b => b.PatientId);
            builder.Property(entity => entity.Name).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.PhoneNumber).HasMaxLength(StringLengths.Phone).IsRequired();
        }
    }
}
