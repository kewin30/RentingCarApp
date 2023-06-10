using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentingCarsApi.Entity.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.ZipCode)
               .HasMaxLength(10)
               .IsRequired();
            builder.Property(x => x.Country)
               .HasMaxLength(20)
               .IsRequired();
            builder.Property(x => x.City)
               .HasMaxLength(50)
               .IsRequired();
            builder.Property(x => x.Street)
               .HasMaxLength(50)
               .IsRequired();
            builder.Property(x => x.HouseNumber)
               .HasMaxLength(30)
               .IsRequired();
        }
    }
}
