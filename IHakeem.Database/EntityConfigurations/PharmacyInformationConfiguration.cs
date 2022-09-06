using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class PharmacyInformationConfiguration
        : IEntityTypeConfiguration<PharmacyInformation>
    {
        public void Configure(EntityTypeBuilder<PharmacyInformation> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.CountryId).HasColumnType("BIGINT");
            builder.Property(entity => entity.StateId).HasColumnType("BIGINT");
            builder.Property(entity => entity.CityId).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.PharmacyName).HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(entity => entity.PharmacyAddress).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.PhoneNumber).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.Fax).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                .WithMany(a => a.PharmacyInformation)
                .HasForeignKey(b => b.PatientId);
        }
    }


}
