using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class PatientAllergiesHistoryConfiguration
        : IEntityTypeConfiguration<PatientAllergiesHistory>
    {
        public void Configure(EntityTypeBuilder<PatientAllergiesHistory> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.AllergyTo).HasColumnType("NVARCHAR(500)").IsRequired();
            builder.Property(entity => entity.Reaction).HasColumnType("NVARCHAR(500)").IsRequired();
            builder.Property(entity => entity.AllergyNotes).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                .WithMany(a => a.PatientAllergiesHistory)
                .HasForeignKey(b => b.PatientId);
        }
    }


}
