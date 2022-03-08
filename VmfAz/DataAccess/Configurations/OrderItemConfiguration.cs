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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.CostPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.SalePrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DiscountPercent).HasDefaultValue(0);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderItems).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderItems).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
