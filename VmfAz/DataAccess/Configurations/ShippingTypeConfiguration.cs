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
    public class ShippingTypeConfiguration : IEntityTypeConfiguration<ShippingType>
    {
        public void Configure(EntityTypeBuilder<ShippingType> builder)
        {
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x=>x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.DeliveryTime).IsRequired().HasMaxLength(20);
        }
    }
}
