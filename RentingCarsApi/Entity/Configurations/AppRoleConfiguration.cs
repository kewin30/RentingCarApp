﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentingCarsApi.Entity.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder
               .HasMany(ur => ur.UserRoles)
               .WithOne(u => u.Role)
               .HasForeignKey(u => u.RoleId)
               .IsRequired();
        }
    }
}
