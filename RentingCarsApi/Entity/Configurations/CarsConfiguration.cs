using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace RentingCarsApi.Entity.Configurations
{
    public class CarsConfiguration : IEntityTypeConfiguration<Cars>
    {
        public void Configure(EntityTypeBuilder<Cars> builder)
        {
            builder
               .HasOne(c => c.Photo)
               .WithOne(p => p.Cars)
               .HasForeignKey<Photo>(p => p.CarsVin);
            builder
                .HasOne(c => c.User)
                .WithMany(u => u.Cars)
                .HasForeignKey(c => c.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Property(x => x.Vin)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(x => x.GpsEnabled)
                .IsRequired();
            builder.Property(x => x.Plate)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(x => x.Model)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.CarYear)
                .HasMaxLength(6)
                .IsRequired();
            builder.Property(x => x.Color)
               .HasMaxLength(20)
               .IsRequired();
            builder.Property(x => x.Weight)
               .HasMaxLength(6)
               .IsRequired();
            builder.Property(x => x.PrizeForDay)
               .HasMaxLength(10)
               .IsRequired();
            builder.Property(x => x.PrizeForWeek)
               .HasMaxLength(12)
               .IsRequired();
            builder.Property(x => x.Place)
               .HasMaxLength(50)
               .IsRequired();


        }
    }
}
