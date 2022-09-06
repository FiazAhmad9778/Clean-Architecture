using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class PregnanciesHistoryConfiguration
        : IEntityTypeConfiguration<PregnanciesHistory>
    {
        public void Configure(EntityTypeBuilder<PregnanciesHistory> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.DoYouUseContraceptionId).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.Mammogram).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.BreastExam).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.PapSmear).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.KindOfContraception).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.AgeAtFirstMenses).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.MenstrualPeriods).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.AgeAtMenopause).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.HotFlashesOrOtherSymptoms).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.GynaecologicalConditionsOrProblems).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.Notes).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                .WithMany(a => a.PregnanciesHistory)
                .HasForeignKey(b => b.PatientId);
        }
    }


}
