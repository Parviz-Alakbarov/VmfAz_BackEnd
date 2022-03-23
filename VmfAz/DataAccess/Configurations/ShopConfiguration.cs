using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.RedirectUrl).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PhoneNumber1).HasMaxLength(15).IsRequired();
            builder.Property(x => x.PhoneNumber2).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Longitude).HasColumnType("decimal(9,6)").IsRequired();
            builder.Property(x => x.Latitude).HasColumnType("decimal(9,6)").IsRequired();
            builder.Property(x => x.OpenMinute).HasColumnType("tinyint");
            builder.Property(x => x.CloseHour).HasColumnType("tinyint");
            builder.Property(x => x.CloseMinute).HasColumnType("tinyint");
            builder.Property(x => x.OpenHour).HasColumnType("tinyint");
            builder.Property(x => x.Address).HasMaxLength(500).IsRequired();



        }
    }
}
