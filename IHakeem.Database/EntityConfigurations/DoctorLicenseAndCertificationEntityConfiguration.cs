using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class DoctorLicenseAndCertificationEntityConfiguration : IEntityTypeConfiguration<DoctorLicenseAndCertification>
    {
        public void Configure(EntityTypeBuilder<DoctorLicenseAndCertification> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.LicenseOrCertificateNo).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.City).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.State).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Country).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.DateOfIssue).IsRequired();
            builder.Property(entity => entity.DateOfExpiry).IsRequired();

            builder.HasOne(entity => entity.Doctor)
             .WithMany(a => a.DoctorLicenseAndCertification)
             .HasForeignKey(b => b.DoctorId);

            builder.HasOne(x => x.LicenseOrCertificateType)
              .WithMany()
               .HasPrincipalKey(x => x.Code)
              .HasForeignKey(x => x.LicenseOrCertificateTypeId);
        }
    }
}
