using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class DoctorServiceEntityConfiguration : IEntityTypeConfiguration<DoctorService>
    {
        public void Configure(EntityTypeBuilder<DoctorService> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Price).IsRequired();
            builder.HasOne(x => x.Service)
             .WithMany()
              .HasPrincipalKey(x => x.Code)
             .HasForeignKey(x => x.ServiceId);

        }
    }
}
