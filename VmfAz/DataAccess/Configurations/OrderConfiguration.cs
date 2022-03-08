using Core.Enums;
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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.CityId).IsRequired();
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.LastName).HasMaxLength(25);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
            builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.UpdateDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.Note).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.OrderStatus).HasDefaultValue(OrderStatus.Accepted);

            builder.HasOne(x => x.ShippingType).WithMany(x => x.Orders).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
