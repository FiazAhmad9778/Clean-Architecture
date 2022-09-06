
using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class SocialHistoryConfiguration
        : IEntityTypeConfiguration<SocialHistory>
    {
        public void Configure(EntityTypeBuilder<SocialHistory> builder)
        {
            builder.HasKey(entity => entity.Id);
           

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.SmokingId).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.CaffeineId).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.AlcoholId).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.TobaccoTypeId).HasColumnType("BIGINT");
            builder.Property(entity => entity.NumberOfYears).HasColumnType("BIGINT");
            builder.Property(entity => entity.AmountPerDay).HasColumnType("BIGINT");
            builder.Property(entity => entity.QuitYear).HasColumnType("BIGINT");
            builder.Property(entity => entity.QuitYearAlcohal).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.SmokingNotes).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.NumberOfCaffeinatedDrinksPerDay).HasColumnType("NVARCHAR(50)");
            builder.Property(entity => entity.CaffeineNotes).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.NumberOfDrinksPerWeek).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.PreferredDrink).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.AlcoholNotes).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.Property(e => e.IsDepressedAndHopeless).HasColumnType("bit");
            builder.Property(e => e.IsInterestedOrPleasure).HasColumnType("bit");

            builder.HasOne(entity => entity.PatientDetails)
                 .WithMany(a => a.SocialHistory)
                 .HasForeignKey(b => b.PatientId);
        }
    }


}
