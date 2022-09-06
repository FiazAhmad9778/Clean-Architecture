using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class MyPhysiciansConfiguration
        : IEntityTypeConfiguration<MyPhysicians>
    {
        public void Configure(EntityTypeBuilder<MyPhysicians> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).HasColumnType("BIGINT");
            builder.Property(entity => entity.PhysicianSpecialityId).HasColumnType("BIGINT");
            builder.Property(entity => entity.PatientId).HasColumnType("BIGINT").IsRequired();
            
            builder.Property(entity => entity.PhysicianName).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.PhysicianLocation).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.Hospital).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.PhysicianPhoneNo).HasColumnType("NVARCHAR(250)");
            builder.Property(entity => entity.PhysicianNotes).HasColumnType("NVARCHAR(500)");
            builder.Property(entity => entity.CreatedBy).HasColumnType("BIGINT");
            builder.Property(entity => entity.UpdatedBy).HasColumnType("BIGINT");

            builder.HasOne(entity => entity.PatientDetails)
                .WithMany(a => a.MyPhysicians)
                .HasForeignKey(b => b.PatientId);
        }
    }


}
