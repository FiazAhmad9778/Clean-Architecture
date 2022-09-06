using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class RecreationalDrugsHistoryConfiguration
        : IEntityTypeConfiguration<RecreationalDrugsHistory>
    {
        public void Configure(EntityTypeBuilder<RecreationalDrugsHistory> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.DrugId).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.AmountPerWeek).HasColumnType("BIGINT");
            builder.Property(entity => entity.LastUsed).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.Type).HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(entity => entity.RecreationalDrugsHistoryNotes).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                 .WithMany(a => a.RecreationalDrugsHistory)
                 .HasForeignKey(b => b.PatientId);
        }
    }


}
