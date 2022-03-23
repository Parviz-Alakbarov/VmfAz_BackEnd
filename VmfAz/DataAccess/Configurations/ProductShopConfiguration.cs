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
    public class ProductShopConfiguration : IEntityTypeConfiguration<ProductShop>
    {
        public void Configure(EntityTypeBuilder<ProductShop> builder)
        {
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.ShopId).IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.ProductShops).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Shop).WithMany(x => x.ProductShops).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
