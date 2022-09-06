using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class MedicalDepartmentConfiguration
        : IEntityTypeConfiguration<MedicalDepartment>
    {
        public void Configure(EntityTypeBuilder<MedicalDepartment> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.HasOne(entity => entity.Description)
                .WithOne()
                .HasForeignKey<MedicalDepartment>(b => b.DescriptionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(entity => entity.Name)
               .WithOne()
               .HasForeignKey<MedicalDepartment>(b => b.NameId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
        }
    }


}
