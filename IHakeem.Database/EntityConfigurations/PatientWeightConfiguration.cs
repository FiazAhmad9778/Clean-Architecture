using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class PatientWeightConfiguration
        : IEntityTypeConfiguration<PatientWeight>
    {
        public void Configure(EntityTypeBuilder<PatientWeight> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.UnitId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.Weight).HasColumnType("FLOAT").IsRequired();
            

            builder.Property(entity => entity.PatientWeightDateAndTime).HasColumnType("DateTime").IsRequired();
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                 .WithMany(a => a.PatientWeight)
                 .HasForeignKey(b => b.PatientId);
        }
    }


}
