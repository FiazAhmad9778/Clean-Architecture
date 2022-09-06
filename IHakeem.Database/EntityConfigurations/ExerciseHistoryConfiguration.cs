using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class ExerciseHistoryConfiguration
        : IEntityTypeConfiguration<ExerciseHistory>
    {
        public void Configure(EntityTypeBuilder<ExerciseHistory> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.NumberOfDaysPerWeek).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.ExerciseType).HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(entity => entity.HobbiesOrActivitiesNotes).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.Property(entity => entity.IsExercise).HasColumnType("bit").IsRequired();

            builder.HasOne(entity => entity.PatientDetails)
                .WithMany(a => a.ExerciseHistory)
                .HasForeignKey(b => b.PatientId);
        }
    }


}
