
using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class HospitalizationInformationConfiguration
        : IEntityTypeConfiguration<HospitalizationInformation>
    {
        public void Configure(EntityTypeBuilder<HospitalizationInformation> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.ReasonId).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.HospitalName).HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(entity => entity.HospitaliazationYear).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(entity => entity.PhoneNumber).HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(entity => entity.location).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.HospitalizaitonNotes).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                .WithMany(a => a.HospitalizationInformation)
                .HasForeignKey(b => b.PatientId);
        }
    }


}
