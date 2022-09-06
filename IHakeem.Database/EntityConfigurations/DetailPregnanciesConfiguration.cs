using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class DetailPregnanciesConfiguration
        : IEntityTypeConfiguration<DetailPregnancies>
    {
        public void Configure(EntityTypeBuilder<DetailPregnancies> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.DeliveryTypeId).HasColumnType("BIGINT").IsRequired();
            builder.Property(entity => entity.GenderId).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();

            builder.Property(entity => entity.NumberOfPregnancies).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.NumberOfLivingChildrens).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.NumberOfAbortions).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.NumberOfMiscarriages).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.Notes).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.Property(entity => entity.DeliveryDate).HasColumnType("DATETIME");

            builder.HasOne(entity => entity.PatientDetails)
                .WithMany(a => a.DetailPregnancies)
                .HasForeignKey(b => b.PatientId);
        }
    }


}
