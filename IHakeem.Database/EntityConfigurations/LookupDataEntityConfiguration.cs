using iHakeem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iHakeem.Database.EntityConfigurations
{
    public class LookupDataEntityConfiguration : IEntityTypeConfiguration<LookupData>
    {
        public void Configure(EntityTypeBuilder<LookupData> builder)
        {
            builder.ToTable("LookupData");
            builder.HasKey(entity => entity.Id);
            builder.HasOne(entity => entity.Lookup)
                .WithMany(x => x.LookupData)
                .HasForeignKey(b => b.LookupId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}