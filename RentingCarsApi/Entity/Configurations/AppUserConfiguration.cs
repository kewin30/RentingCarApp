using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace RentingCarsApi.Entity.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> modelBuilder)
        {
            modelBuilder
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();
            modelBuilder
                .HasOne(u => u.ReservedCar)
                .WithOne(c => c.UserReservation)
                .HasForeignKey<Cars>(u => u.UserReservationId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Property(x => x.Gender)
               .HasMaxLength(8)
               .IsRequired();
            modelBuilder.Property(x => x.UserName)
               .HasMaxLength(30)
               .IsRequired();
            modelBuilder.Property(x => x.Name)
               .HasMaxLength(30)
               .IsRequired();
            modelBuilder.Property(x => x.Pesel)
              .HasMaxLength(12)
              .IsRequired();
            modelBuilder.Property(x => x.UserName)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(x => x.PhoneNumber)
               .HasMaxLength(20)
               .IsRequired();
            modelBuilder.Property(x => x.IdNumber)
               .HasMaxLength(10)
               .IsRequired();
        }
    }
}
