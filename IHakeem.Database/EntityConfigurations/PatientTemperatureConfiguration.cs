using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class PatientTemperatureConfiguration
        : IEntityTypeConfiguration<PatientTemperature>
    {
        public void Configure(EntityTypeBuilder<PatientTemperature> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.UnitId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.Temperature).HasColumnType("FLOAT").IsRequired();
            

            builder.Property(entity => entity.PatientTemperatureDateAndTime).HasColumnType("DateTime").IsRequired();
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                 .WithMany(a => a.PatientTemperature)
                 .HasForeignKey(b => b.PatientId);
        }
    }


}
