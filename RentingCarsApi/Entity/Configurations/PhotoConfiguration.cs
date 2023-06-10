using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RentingCarsApi.Entity.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.PublicId)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
