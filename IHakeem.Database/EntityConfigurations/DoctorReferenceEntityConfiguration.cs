using iHakeem.Database.Utilities.Constants;
using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class DoctorReferenceEntityConfiguration : IEntityTypeConfiguration<DoctorReference>
    {
        public void Configure(EntityTypeBuilder<DoctorReference> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Name).HasMaxLength(StringLengths.Default).IsRequired();
            builder.Property(entity => entity.Email).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Contact).HasMaxLength(StringLengths.Phone).IsRequired();
            builder.Property(entity => entity.Fax).HasMaxLength(StringLengths.Phone).IsRequired();
            builder.Property(entity => entity.DurationAssociated).HasMaxLength(StringLengths.small).IsRequired();
            builder.Property(entity => entity.Address).IsRequired();
            builder.HasOne(x => x.Relation)
             .WithMany()
              .HasPrincipalKey(x => x.Code)
             .HasForeignKey(x => x.RelationId);

            builder.HasOne(entity => entity.Doctor)
           .WithMany(a => a.DoctorReference)
           .HasForeignKey(b => b.DoctorId);

        }
    }
}
