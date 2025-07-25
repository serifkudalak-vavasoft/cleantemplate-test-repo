using TestProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestProject.Persistence.Configurations
{
    public class AutoPartConfiguration : IEntityTypeConfiguration<AutoPart>
    {
        public void Configure(EntityTypeBuilder<AutoPart> builder)
        {
            builder.HasKey(ap => ap.AutoPartId);

            builder.Property(ap => ap.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ap => ap.Price)
                   .IsRequired();

            builder.HasOne(ap => ap.Category)
                   .WithMany(c => c.AutoParts)
                   .HasForeignKey(ap => ap.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
