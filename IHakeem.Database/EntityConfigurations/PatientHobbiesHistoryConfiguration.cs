using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class PatientHobbiesHistoryConfiguration
        : IEntityTypeConfiguration<PatientHobbiesHistory>
    {
        public void Configure(EntityTypeBuilder<PatientHobbiesHistory> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.Hobby).HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                .WithMany(a => a.PatientHobbiesHistory)
                .HasForeignKey(b => b.PatientId);
        }
    }


}
