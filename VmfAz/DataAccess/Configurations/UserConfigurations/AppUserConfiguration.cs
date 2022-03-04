using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations.UserConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.LastName).HasMaxLength(25);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CityId).IsRequired();
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.HasOne(x=>x.Country).WithMany(x=>x.AppUsers).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.PasswordHash).HasColumnType("varbinary(500)").IsRequired();
            builder.Property(x => x.PasswordSalt).HasColumnType("varbinary(500)").IsRequired();

        }
    }
}
